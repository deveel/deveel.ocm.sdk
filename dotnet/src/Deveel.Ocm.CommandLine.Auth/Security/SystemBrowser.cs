using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;

using IdentityModel.OidcClient.Browser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

namespace Deveel.Messaging {
	public class SystemBrowser : IBrowser {
		public int Port { get; }
		private readonly string? _path;

		public SystemBrowser(short? port = null, string? path = null) {
			_path = path;

			if (!port.HasValue) {
				Port = GetRandomUnusedPort();
			} else {
				Port = port.Value;
			}
		}

		public event EventHandler? Closed;

		private int GetRandomUnusedPort() {
			var listener = new TcpListener(IPAddress.Loopback, 0);
			listener.Start();
			var port = ((IPEndPoint)listener.LocalEndpoint).Port;
			listener.Stop();
			return port;
		}

		public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken) {
			using (var listener = new LoopbackHttpListener(Port, _path)) {
				OpenBrowser(options.StartUrl);

				try {
					var result = await listener.WaitForCallbackAsync();
					if (String.IsNullOrWhiteSpace(result)) {
						return new BrowserResult { ResultType = BrowserResultType.UnknownError, Error = "Empty response." };
					}

					return new BrowserResult { Response = result, ResultType = BrowserResultType.Success };
				} catch (TaskCanceledException ex) {
					return new BrowserResult { ResultType = BrowserResultType.Timeout, Error = ex.Message };
				} catch (Exception ex) {
					return new BrowserResult { ResultType = BrowserResultType.UnknownError, Error = ex.Message };
				}
			}
		}

		public void OpenBrowser(string url) {
			Process? process;

			try {
				process = Process.Start(url);
			} catch {
				// hack because of this: https://github.com/dotnet/corefx/issues/10361
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
					url = url.Replace("&", "^&");
					process = Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
				} else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
					process = Process.Start("xdg-open", url);
				} else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
					process = Process.Start("open", url);
				} else {
					throw;
				}
			}

			if (process != null && Closed != null) {
				process.Exited += Closed;
			}
		}
	}

	public class LoopbackHttpListener : IDisposable {
		const int DefaultTimeout = 60 * 5; // 5 mins (in seconds)

		IWebHost _host;
		TaskCompletionSource<string> _source = new TaskCompletionSource<string>();
		string _url;

		public string Url => _url;

		public LoopbackHttpListener(int port, string? path = null) {
			path = path ?? String.Empty;

			if (!path.StartsWith("/"))
				path = $"/{path}";

			_url = $"http://127.0.0.1:{port}";

			_host = new WebHostBuilder()
				.UseKestrel()
				.UseUrls(_url)
				.Configure(app => Configure(app, path))
				.Build();
			_host.Start();
		}

		public void Dispose() {
			Task.Run(async () => {
				await Task.Delay(500);
				_host.Dispose();
			});
		}

		void Configure(IApplicationBuilder app, string rootPath) {
			if (!String.IsNullOrWhiteSpace(rootPath))
				app.UsePathBase(rootPath);

			app.Run(async ctx => {
				if (ctx.Request.Method == "GET") {
					await SetResultAsync(ctx.Request.QueryString.Value, ctx);
				} else {
					ctx.Response.StatusCode = 405;
				}
			});
		}

		private async Task SetResultAsync(string value, HttpContext ctx) {
			_source.TrySetResult(value);

			try {
				ctx.Response.StatusCode = 200;
				ctx.Response.ContentType = "text/html";
				await ctx.Response.WriteAsync("<h1>You can now return to the application.</h1>");
				await ctx.Response.Body.FlushAsync();
			} catch {
				ctx.Response.StatusCode = 400;
				ctx.Response.ContentType = "text/html";
				await ctx.Response.WriteAsync("<h1>Invalid request.</h1>");
				await ctx.Response.Body.FlushAsync();
			}
		}

		public Task<string> WaitForCallbackAsync(int timeoutInSeconds = DefaultTimeout) {
			Task.Run(async () => {
				await Task.Delay(timeoutInSeconds * 1000);
				_source.TrySetCanceled();
			});

			return _source.Task;
		}
	}
}
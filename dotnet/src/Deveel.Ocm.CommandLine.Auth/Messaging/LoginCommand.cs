using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.IO;

using IdentityModel.OidcClient;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Deveel.Messaging {
	public sealed class LoginCommand : Command {
		static LoginCommand() {
			UserOption = new Option<string?>(new[] { "--user", "-u" }, "The name of the user to login");
			PasswordOption = new Option<string?>(new[] { "--password", "-p" }, "A secret used to identify the user");
			ClientOption = new Option<bool?>(new[] { "--client", "-c" }, "Indicates the identity logging in is a client application");
			TenantOption = new Option<string?>(new[] { "--tenant", "-t" }, "The identifier of the tenant");
		}

		public LoginCommand()
			: base("login", "Logs the console user into the platform") {

			AddOption(UserOption);
			AddOption(PasswordOption);
			AddOption(ClientOption);
			AddOption(TenantOption);
		}

		private static Option<string?> UserOption { get; set; }

		private static Option<string?> PasswordOption { get; set; }

		public static Option<bool?> ClientOption { get; set; }

		public static Option<string?> TenantOption { get; set; }

		public new class Handler : ICommandHandler {
			private readonly IConfiguration configuration;

			public Handler(IConfiguration configuration) {
				this.configuration = configuration;
			}

			public int Invoke(InvocationContext context)
				=> InvokeAsync(context).ConfigureAwait(false).GetAwaiter().GetResult();

			public async Task<int> InvokeAsync(InvocationContext context) {
				var browser = new SystemBrowser();
				string redirectUri = string.Format($"http://127.0.0.1:{browser.Port}");

				var user = context.ParseResult.GetValueForOption(UserOption);

				if (String.IsNullOrWhiteSpace(user)) {
					var options = new OidcClientOptions {
						Authority = "https://deveel.eu.auth0.com",
						ClientId = "interactive.public.short",
						RedirectUri = redirectUri,
						Scope = "openid profile api offline_access",
						FilterClaims = false,

						Browser = browser,
						IdentityTokenValidator = new JwtHandlerIdentityTokenValidator(),
						RefreshTokenInnerHttpHandler = new SocketsHttpHandler()
					};

					var oidcClient = new OidcClient(options);
					var result = await oidcClient.LoginAsync(new LoginRequest());

					// TODO: persist the result

					if (result.IsError) {
						context.Console.Error.WriteLine($"Error while authenticating: {result.Error}");
					} else {
						await AccessTokenFileUtil.SaveTokenAsync(result.AccessToken, result.AccessTokenExpiration);
					}
				} else {
					var pass = context.ParseResult.GetValueForOption(PasswordOption);

				}

				return 0;
			}
		}
	}
}

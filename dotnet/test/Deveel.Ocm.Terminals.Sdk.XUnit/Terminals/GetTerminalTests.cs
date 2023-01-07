using System;
using System.Dynamic;
using System.Net.Http.Json;
using System.Net;

using Deveel.Testing;
using System.Web;
using FluentAssertions;

namespace Deveel.Messaging.Terminals {
	public class GetTerminalTests {
		private readonly OcmClientBuilder clientBuilder;

		public GetTerminalTests() {
			clientBuilder = OcmClientBuilder.Default
				.UseSettings(settings => settings.UseAccessToken(Guid.NewGuid().ToString("N"), DateTimeOffset.UtcNow.AddMinutes(20)));
		}

		[Fact]
		public async Task GetExistingTerminal() {
			var client = clientBuilder
				.AddTerminalManagement(terminals => terminals
					.UseSettings(settings => settings.UseHttpClient(HttpCallbackHandler.Create(request => {
						var id = request.RequestUri.GetQueryValue("id");

						return new HttpResponseMessage(HttpStatusCode.OK) {
							Content = JsonContent.Create(new {
								id,
								provider = "twilio",
								type = "phoneNumber",
								address = "+1800349944",
								role = "both"
							})
						};
					}))))
				.Build();

			var terminal = await client.GetTerminalAsync(Guid.NewGuid().ToString("N"));

			terminal.Should().NotBeNull();
			terminal.Type.Should().Be(TerminalType.PhoneNumber);
			terminal.Provider.Should().NotBeNullOrWhiteSpace().And.Be("twilio");
		}

		[Fact]
		public async Task GetNotFoundTerminal() {
			var client = clientBuilder
				.AddTerminalManagement(terminals => terminals
					.UseSettings(settings => settings.UseHttpClient(HttpCallbackHandler.Create(request => new HttpResponseMessage(HttpStatusCode.NotFound)))))
				.Build();

			var terminal = await client.GetTerminalAsync(Guid.NewGuid().ToString("N"));

			terminal.Should().BeNull();
		}

		[Fact]
		public async Task GetTerminalsPage() {
			var client = clientBuilder
				.AddTerminalManagement(terminals => terminals
				.UseSettings(settings => settings.UseHttpClient(HttpCallbackHandler.Create(request => {
					var page = request.RequestUri.GetQueryValue<int>("p");
					var count = request.RequestUri.GetQueryValue<int>("c");
					
					return new HttpResponseMessage(HttpStatusCode.OK) {
						Content = JsonContent.Create(new {
							totalItems = 12,
							request = new {
								c = count,
								p = page
							},
							items = new[] {
								new { id = Guid.NewGuid().ToString("N"), provider = "twilio", type = "phoneNumber", address = "+1800349944", role = "both" }
							} 
						})
					};
				}))))
				.Build();

			var page = await client.GetTerminalsPageAsync();

			page.Should().NotBeNull();
			page.TotalItems.Should().BeGreaterThan(0).And.Be(12);
			page.Items.Should().NotBeNullOrEmpty();
		}

		[Fact]
		public async Task GetTerminalsPageEnumerable() {
			var client = clientBuilder
				.AddTerminalManagement(terminals => terminals
				.UseSettings(settings => settings.UseHttpClient(HttpCallbackHandler.Create(request => {
					var page = request.RequestUri.GetQueryValue<int>("p");
					var count = request.RequestUri.GetQueryValue<int>("c");

					return new HttpResponseMessage(HttpStatusCode.OK) {
						Content = JsonContent.Create(new {
							totalItems = 12,
							request = new {
								p = page,
								c = count,
								type = request.RequestUri.GetQueryValue("type")
							},
							items = new[] {
								new { id = Guid.NewGuid().ToString("N"), provider = "twilio", type = "phoneNumber", address = "+1800349944", role = "both" }
							}
						})
					};
				}))))
				.Build();

			var pages = client.GetTerminalPages();

			await foreach(var page in pages) {
				page.Should().NotBeNull();
				page.TotalItems.Should().BeGreaterThan(0).And.Be(12);
				page.Items.Should().NotBeNullOrEmpty();
			}
		}

	}
}

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
						var id = HttpUtility.ParseQueryString(request.RequestUri.Query)["id"];

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
	}
}

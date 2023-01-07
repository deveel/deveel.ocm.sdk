using System;
using System.Net.Http.Json;
using System.Net;

using Deveel.Testing;
using FluentAssertions;

namespace Deveel.Messaging.Terminals {
	public class ListTerminalProvidersTests {
		private readonly OcmClientBuilder clientBuilder;

		public ListTerminalProvidersTests() {
			clientBuilder = OcmClientBuilder.Default
				.UseSettings(settings => settings.UseAccessToken(Guid.NewGuid().ToString("N"), DateTimeOffset.UtcNow.AddMinutes(20)));
		}

		[Fact]
		public async Task ListAllProviders() {
			var client = clientBuilder
				.AddTerminalManagement(terminals => terminals
					.UseSettings(settings => settings.UseHttpClient(HttpCallbackHandler.Create(request => {
						return new HttpResponseMessage(HttpStatusCode.OK) {
							Content = JsonContent.Create(new [] {
								new { code = "twilio", name = "Twilio", types = new[] { "phoneNumber" } }
							})
						};
					}))))
				.Build();

			var providers = await client.ListTerminalProvidersAsync();

			providers.Should().NotBeNullOrEmpty();
			var provider = providers.First();
			provider.Should().NotBeNull();
			provider.Code.Should().NotBeNullOrWhiteSpace().And.Be("twilio");
		}
	}
}

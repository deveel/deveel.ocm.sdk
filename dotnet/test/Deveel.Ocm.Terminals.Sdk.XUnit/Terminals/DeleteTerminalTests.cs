using System;
using System.Dynamic;
using System.Net.Http.Json;
using System.Net;

using Deveel.Testing;

namespace Deveel.Messaging.Terminals {
	public class DeleteTerminalTests {
		private readonly OcmClientBuilder clientBuilder;

		public DeleteTerminalTests() {
			clientBuilder = OcmClientBuilder.Default
				.UseSettings(settings => settings.UseAccessToken(Guid.NewGuid().ToString("N"), DateTimeOffset.UtcNow.AddMinutes(20)));
		}

		[Fact]
		public async Task DeleteExistingTerminal() {
			var client = clientBuilder
				.AddTerminalManagement(terminals => terminals
					.UseSettings(settings => settings.UseHttpClient(HttpCallbackHandler.Create(async request => {
						return new HttpResponseMessage(HttpStatusCode.NoContent);
					}))))
				.Build();

			await client.DeleteTerminalAsync(Guid.NewGuid().ToString("N"));
		}
	}
}

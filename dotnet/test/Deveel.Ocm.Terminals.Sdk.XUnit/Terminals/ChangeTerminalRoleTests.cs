using System;
using System.Net.Http.Json;
using System.Net;

using Deveel.Testing;
using System.Text.Json.Nodes;
using System.Dynamic;

namespace Deveel.Messaging.Terminals {
	public class ChangeTerminalRoleTests {
		private readonly OcmClientBuilder clientBuilder;

		public ChangeTerminalRoleTests() {
			clientBuilder = OcmClientBuilder.Default
				.UseSettings(settings => settings.UseAccessToken(Guid.NewGuid().ToString("N"), DateTimeOffset.UtcNow.AddMinutes(20)));
		}

		[Fact]
		public async Task ChangeToNewRole() {
			var client = clientBuilder
				.AddTerminalManagement(terminals => terminals
				.UseSettings(settings => settings.UseHttpClient(HttpCallbackHandler.Create(async request => {
					var id = request.RequestUri.GetQueryValue("id");
					dynamic newRole = await request.Content.ReadFromJsonAsync<ExpandoObject>();
					
					return new HttpResponseMessage(HttpStatusCode.OK) {
						Content = JsonContent.Create(new {
							id,
							provider = "twilio",
							type = "phoneNumber",
							address = "+1800349944",
							role = newRole.role
						})
					};
				}))))
				.Build();

			await client.ChangeTerminalRoleAsync(Guid.NewGuid().ToString("N"), ServerTerminalRoles.Sender);
		}
	}
}

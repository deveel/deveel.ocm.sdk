using System;
using System.Dynamic;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Nodes;

using Deveel.Messaging.Terminals.Management.Models;
using Deveel.Testing;

using FluentAssertions;

namespace Deveel.Messaging.Terminals {
	public class CreateServerTerminalTests {
		private readonly OcmClientBuilder clientBuilder;

		public CreateServerTerminalTests() {
			clientBuilder = OcmClientBuilder.Default
				.UseSettings(settings => settings.UseAccessToken(Guid.NewGuid().ToString("N"), DateTimeOffset.UtcNow.AddMinutes(20)));
		}

		[Fact]
		public async Task CreateEmail() {
			var client = clientBuilder
				.AddTerminalManagement(terminals => terminals
					.UseSettings(settings => settings.UseHttpClient(HttpCallbackHandler.Create(async request => {
						dynamic newTerminal = await request.Content.ReadFromJsonAsync<ExpandoObject>();

						return new HttpResponseMessage(HttpStatusCode.Created) {
							Content = JsonContent.Create(new {
								id = Guid.NewGuid().ToString("N"),
								provider = newTerminal.provider,
								type = newTerminal.type,
								address = newTerminal.address,
								role = newTerminal.role
							})
						};
					}))))
				.Build();

			var terminal = new ServerTerminal(TerminalType.EmailAddress, "no-reply@deveel.com", "sendgrid") {
				Roles = ServerTerminalRoles.Sender
			};

			var result = await client.CreateTerminalAsync(terminal);

			result.Should().NotBeNull();
			result.Id.Should().NotBeNullOrWhiteSpace();
			result.Provider.Should().Be("sendgrid");
			result.Type.Should().Be(TerminalType.EmailAddress);
			result.Address.Should().NotBeNullOrWhiteSpace().And.Be("no-reply@deveel.com");
			result.Roles.Should().NotBeNull().And.Be(ServerTerminalRoles.Sender);
		}

		[Fact]
		public async Task CreatePhoneNumber() {
			var client = clientBuilder
				.AddTerminalManagement(terminals => terminals
					.UseSettings(settings => settings.UseHttpClient(HttpCallbackHandler.Create(async request => {
						dynamic newTerminal = await request.Content.ReadFromJsonAsync<ExpandoObject>();

						return new HttpResponseMessage(HttpStatusCode.Created) {
							Content = JsonContent.Create(new {
								id = Guid.NewGuid().ToString("N"),
								provider = newTerminal.provider,
								type = newTerminal.type,
								address = newTerminal.address,
								role = newTerminal.role
							})
						};
					}))))
				.Build();

			var terminal = new ServerTerminal(TerminalType.PhoneNumber, "+180040567886", "twilio") {
				Roles = ServerTerminalRoles.Both
			};

			var result = await client.CreateTerminalAsync(terminal);

			result.Should().NotBeNull();
			result.Id.Should().NotBeNullOrWhiteSpace();
			result.Provider.Should().Be("twilio");
			result.Type.Should().Be(TerminalType.PhoneNumber);
			result.Address.Should().NotBeNullOrWhiteSpace().And.Be("+180040567886");
			result.Roles.Should().NotBeNull().And.Be(ServerTerminalRoles.Both);
		}

	}
}

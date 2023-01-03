using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

using Deveel.Messaging.Models;
using Deveel.Testing;

using FluentAssertions;

using Microsoft.Extensions.DependencyInjection;

namespace Deveel.Messaging {
	public static class MessageSendingTests {
		[Fact]
		public static async Task SendMessage() {
			var accessToken = Guid.NewGuid().ToString();

			var services = new ServiceCollection()
				.AddOcmClient(builder => builder
					.WithLifetime(ServiceLifetime.Transient)
					.UseSettings(settings => settings.UseAccessToken(accessToken, DateTimeOffset.UtcNow.AddMinutes(20)))
					.AddMessaging(messaging => messaging
						.UseSettings(settings => settings
							.UseHttpClient(HttpCallbackHandler.Create(request => {
								var result = JsonSerializer.SerializeToDocument(new { id = Guid.NewGuid().ToString("N") });
								var response = new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);

								response.Content = new StringContent(JsonSerializer.Serialize(result), Encoding.UTF8, "application/json");
								return response;
							})))))
				.BuildServiceProvider();

			var client = services.GetRequiredService<IOcmClient>();

			var sender = MessageTerminal.Email("info@deveel.com");
			var receiver = MessageTerminal.Email("test@example.com");
			var content = new TextContent("Hello!");
			var result = await client.SendMessageAsync(new Message("channel-1", sender, receiver, content));

			result.Should().NotBeNull();
		}
	}
}

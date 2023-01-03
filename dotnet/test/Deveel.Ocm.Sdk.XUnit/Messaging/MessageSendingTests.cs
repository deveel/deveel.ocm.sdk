using System.Text;
using System.Text.Json;

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
								var result = JsonSerializer.SerializeToDocument(new { 
									messageId = Guid.NewGuid().ToString("N") 
								});
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
			result.MessageId.Should().NotBeNullOrWhiteSpace();
			result.Fallback.Should().BeNull();
		}

		[Fact]
		public static async Task SendMessageWithFallback() {
			var accessToken = Guid.NewGuid().ToString();

			var services = new ServiceCollection()
				.AddOcmClient(builder => builder
					.WithLifetime(ServiceLifetime.Transient)
					.UseSettings(settings => settings.UseAccessToken(accessToken, DateTimeOffset.UtcNow.AddMinutes(20)))
					.AddMessaging(messaging => messaging
						.UseSettings(settings => settings
							.UseHttpClient(HttpCallbackHandler.Create(request => {
								var result = JsonSerializer.SerializeToDocument(new { 
									messageId = Guid.NewGuid().ToString("N"),
									fallback = new {
										messageId = Guid.NewGuid().ToString("N")
									}
								});
								var response = new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);

								response.Content = new StringContent(JsonSerializer.Serialize(result), Encoding.UTF8, "application/json");
								return response;
							})))))
				.BuildServiceProvider();

			var client = services.GetRequiredService<IOcmClient>();

			var sender = MessageTerminal.Email("info@deveel.com");
			var receiver = MessageTerminal.Email("test@example.com");
			var content = new TextContent("Hello!");
			var message = new Message("channel-1", sender, receiver, content) {
				Fallback = new FallbackMessage("channel-2", MessageTerminal.Phone("+474083002"), new TextContent("Hello!"))
			};

			var result = await client.SendMessageAsync(message);

			result.Should().NotBeNull();
			result.MessageId.Should().NotBeNullOrWhiteSpace();
			result.Fallback.Should().NotBeNull();
			result.Fallback.MessageId.Should().NotBeNullOrWhiteSpace();
			result.Fallback.IsRoot.Should().BeFalse();
			result.Fallback.Context.Should().BeNull();
		}

		[Fact]
		public static async Task SendMessageBatch() {
			var accessToken = Guid.NewGuid().ToString();

			var services = new ServiceCollection()
				.AddOcmClient(builder => builder
					.WithLifetime(ServiceLifetime.Transient)
					.UseSettings(settings => settings.UseAccessToken(accessToken, DateTimeOffset.UtcNow.AddMinutes(20)))
					.AddMessaging(messaging => messaging
						.UseSettings(settings => settings
							.UseHttpClient(HttpCallbackHandler.Create(request => {
								var result = JsonSerializer.SerializeToDocument(new {
									batchId = Guid.NewGuid().ToString("N"),
									messages = new[] {
										new { messageId = Guid.NewGuid().ToString("N")}
									}
								});
								var response = new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);

								response.Content = new StringContent(JsonSerializer.Serialize(result), Encoding.UTF8, "application/json");
								return response;
							})))))
				.BuildServiceProvider();

			var client = services.GetRequiredService<IOcmClient>();

			var sender = MessageTerminal.Email("info@deveel.com");
			var receiver = MessageTerminal.Email("test@example.com");
			var content = new TextContent("Hello!");
			var batch = new MessageBatch {
				new Message("channel-1", sender, receiver, content)
			};

			var result = await client.SendBatchAsync(batch);

			result.Should().NotBeNull();
			result.BatchId.Should().NotBeNullOrWhiteSpace();
			result.Messages.Should().NotBeNullOrEmpty();
		}

	}
}

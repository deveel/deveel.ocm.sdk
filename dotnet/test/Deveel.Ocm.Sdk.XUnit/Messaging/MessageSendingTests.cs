using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

using Deveel.Testing;

using FluentAssertions;

using Microsoft.Extensions.DependencyInjection;

namespace Deveel.Messaging {
	public class MessageSendingTests {
		private readonly OcmClientBuilder clientBuilder;

		public MessageSendingTests() {
			var accessToken = Guid.NewGuid().ToString();

			clientBuilder = OcmClientBuilder.Default
				.UseSettings(settings => settings.UseAccessToken(accessToken, DateTimeOffset.UtcNow.AddMinutes(20)));
		}

		[Fact]
		public async Task SendMessage() {
			var client = clientBuilder
				.AddMessaging(messaging => messaging
					.UseSettings(settings => settings
						.UseHttpClient(HttpCallbackHandler.Create(request => {
							return new HttpResponseMessage(HttpStatusCode.Accepted) {
								Content = JsonContent.Create(new {
									messageId = Guid.NewGuid().ToString("N")
								})
							};
						}))))
				.Build();

			var sender = MessageTerminal.Email("info@deveel.com");
			var receiver = MessageTerminal.Email("test@example.com");
			var content = new TextContent("Hello!");
			var result = await client.SendMessageAsync(new Message("channel-1", sender, receiver, content));

			result.Should().NotBeNull();
			result.MessageId.Should().NotBeNullOrWhiteSpace();
			result.Fallback.Should().BeNull();
		}

		[Fact]
		public async Task SendMessageWithFallback() {
			var client = clientBuilder
				.AddMessaging(messaging => messaging
					.UseSettings(settings => settings
						.UseHttpClient(HttpCallbackHandler.Create(request => {
							return new HttpResponseMessage(HttpStatusCode.Accepted) {
								Content = JsonContent.Create(new {
									messageId = Guid.NewGuid().ToString("N"),
									fallback = new {
										messageId = Guid.NewGuid().ToString("N")
									}
								})
							};
						}))))
				.Build();


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
		public async Task SendMessageBatch() {
			var client = clientBuilder
				.AddMessaging(messaging => messaging
				.UseSettings(settings => settings
					.UseHttpClient(HttpCallbackHandler.Create(request => {
						return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted) {
							Content = JsonContent.Create(new {
								batchId = Guid.NewGuid().ToString("N"),
								messages = new[] {
									new { messageId = Guid.NewGuid().ToString("N")}
								}
							})
						};
					}))))
				.Build();

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

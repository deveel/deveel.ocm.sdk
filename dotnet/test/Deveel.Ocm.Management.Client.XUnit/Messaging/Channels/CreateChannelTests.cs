using System;
using System.Dynamic;
using System.Net.Http.Json;
using System.Net;

using Deveel.Testing;
using FluentAssertions;

namespace Deveel.Messaging.Channels {
	public sealed class CreateChannelTests {
		private readonly OcmClientBuilder clientBuilder;


		public CreateChannelTests() {
			clientBuilder = OcmClientBuilder.Default
				.UseSettings(settings => settings.UseAccessToken(Guid.NewGuid().ToString("N"), DateTimeOffset.UtcNow.AddMinutes(20)));
		}

		[Fact]
		public async Task CreateTwilioChannel() {
			var client = clientBuilder
				.AddChannelManagement(channels => channels
					.UseSettings(settings => settings.UseHttpClient(HttpCallbackHandler.Create(async request => {
						var id = Guid.NewGuid().ToString("N");
						dynamic newChannel = await request.Content.ReadFromJsonAsync<ExpandoObject>();
						return new HttpResponseMessage(HttpStatusCode.Created) {
							Content = JsonContent.Create(new {
								id,
								provider = newChannel.provider,
								type = newChannel.type,
								name = newChannel.name,
								directions = newChannel.directions,
								contentTypes = newChannel.contentTypes
							})
						};
					}))))
				.Build();

			var result = await client.CreateChannelAsync(new UserChannel("channel-1", ChannelType.Sms, "twilio") {
				Directions = ChannelDirections.Duplex,
				ContentTypes = new[] { MessageContentType.Text }
			});

			result.Should().NotBeNull();
			result.Id.Should().NotBeNullOrWhiteSpace();
			result.Type.Should().Be(ChannelType.Sms);
			result.Name.Should().Be(new ChannelName("channel-1"));
			result.Provider.Should().Be(new ChannelProvider("twilio"));
			result.Directions.Should().Be(ChannelDirections.Duplex);
			result.ContentTypes.Should().NotBeNullOrEmpty().And
				.Contain(MessageContentType.Text);
		}
	}
}

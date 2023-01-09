using System;
using System.Dynamic;
using System.Net.Http.Json;
using System.Net;

using Deveel.Testing;
using FluentAssertions;

namespace Deveel.Messaging.Channels {
	public class GetUserChannelTests {
		private readonly OcmClientBuilder clientBuilder;

		public GetUserChannelTests() {
			clientBuilder = OcmClientBuilder.Default
				.UseSettings(settings => settings.UseAccessToken(Guid.NewGuid().ToString("N"), DateTimeOffset.UtcNow.AddMinutes(20)));
		}

		[Fact]
		public async Task FindExistingChannelById() {
			var channelId = Guid.NewGuid().ToString("N");
			var client = clientBuilder
				.AddChannelManagement(channels => channels
					.UseSettings(settings => settings.UseHttpClient(HttpCallbackHandler.Create(request => {
						var id = request.RequestUri.Segments[2];
						id.Should().NotBeNullOrWhiteSpace().And.Be(channelId);

						return new HttpResponseMessage(HttpStatusCode.OK) {
							Content = JsonContent.Create(new {
								id,
								provider = "twilio",
								type = "sms",
								name = "channel-1",
								directions = "duplex",
								contentTypes = new[] { "text" }
							})
						};
					}))))
				.Build();

			var result = await client.FindChannelByIdAsync(channelId);

			result.Should().NotBeNull();
			result.Id.Should().Be(channelId);
			result.Type.Should().Be(ChannelType.Sms);
			result.Provider.Should().Be(new ChannelProvider("twilio"));
			result.ContentTypes.Should().NotBeNullOrEmpty().And.Contain(MessageContentType.Text);
			result.Directions.Should().Be(ChannelDirections.Duplex);
			result.Name.Should().Be(new ChannelName("channel-1"));
		}

		[Fact]
		public async Task FindNotExistingChannelById() {
			var channelId = Guid.NewGuid().ToString("N");
			var client = clientBuilder
				.AddChannelManagement(channels => channels
					.UseSettings(settings => settings.UseHttpClient(HttpCallbackHandler.Create(request => {
						var id = request.RequestUri.Segments[2];
						id.Should().NotBeNullOrWhiteSpace().And.NotBe(channelId);

						return new HttpResponseMessage(HttpStatusCode.NotFound);
					}))))
				.Build();

			var result = await client.FindChannelByIdAsync(Guid.NewGuid().ToString());

			result.Should().BeNull();
		}

		[Fact]
		public async Task FindExistingChannelByName() {
			var channelId = Guid.NewGuid().ToString("N");
			const string channelName = "channel-1";

			var client = clientBuilder
				.AddChannelManagement(channels => channels
					.UseSettings(settings => settings.UseHttpClient(HttpCallbackHandler.Create(request => {
						var name = request.RequestUri.Segments[3];
						name.Should().NotBeNullOrWhiteSpace().And.Be(channelName);

						return new HttpResponseMessage(HttpStatusCode.OK) {
							Content = JsonContent.Create(new {
								id = channelId,
								provider = "twilio",
								type = "sms",
								name = name,
								directions = "duplex",
								contentTypes = new[] { "text" }
							})
						};
					}))))
				.Build();

			var result = await client.FindChannelByNameAsync(channelName);

			result.Should().NotBeNull();
			result.Id.Should().Be(channelId);
			result.Type.Should().Be(ChannelType.Sms);
			result.Provider.Should().Be(new ChannelProvider("twilio"));
			result.ContentTypes.Should().NotBeNullOrEmpty().And.Contain(MessageContentType.Text);
			result.Directions.Should().Be(ChannelDirections.Duplex);
			result.Name.Should().Be(new ChannelName(channelName));
		}

		[Fact]
		public async Task FindNotExistingChannelByName() {
			var channelId = Guid.NewGuid().ToString("N");
			const string channelName = "channel-1";

			var client = clientBuilder
				.AddChannelManagement(channels => channels
					.UseSettings(settings => settings.UseHttpClient(HttpCallbackHandler.Create(request => {
						var name = request.RequestUri.Segments[3];
						name.Should().NotBeNullOrWhiteSpace().And.NotBe(channelName);

						return new HttpResponseMessage(HttpStatusCode.NotFound);
					}))))
				.Build();

			var result = await client.FindChannelByNameAsync("channel-2");

			result.Should().BeNull();
		}

	}
}

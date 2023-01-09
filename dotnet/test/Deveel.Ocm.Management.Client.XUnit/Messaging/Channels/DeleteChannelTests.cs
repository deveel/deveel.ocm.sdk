using System.Net;

using Deveel.Testing;

using FluentAssertions;

namespace Deveel.Messaging.Channels {
	public sealed class DeleteChannelTests {
		private readonly OcmClientBuilder clientBuilder;

		public DeleteChannelTests() {
			clientBuilder = OcmClientBuilder.Default
				.UseSettings(settings => settings.UseAccessToken(Guid.NewGuid().ToString("N"), DateTimeOffset.UtcNow.AddMinutes(20)));
		}

		[Fact]
		public async Task DeleteExistingChannel() {
			var channelId = Guid.NewGuid().ToString("N");

			var client = clientBuilder
				.AddChannelManagement(channels => channels
					.UseSettings(settings => settings.UseHttpClient(HttpCallbackHandler.Create(request => {
						request.Method.Should().Be(HttpMethod.Delete);
						var id = request.RequestUri.Segments[2];
						id.Should().NotBeNullOrWhiteSpace().And.Be(channelId);
						return new HttpResponseMessage(HttpStatusCode.NoContent);
					}))))
				.Build();

			await client.DeleteChannelAsync(channelId);
		}

		[Fact]
		public async Task DeleteNotExistingChannel() {
			var channelId = Guid.NewGuid().ToString("N");

			var client = clientBuilder
				.AddChannelManagement(channels => channels
					.UseSettings(settings => settings.UseHttpClient(HttpCallbackHandler.Create(request => {
						request.Method.Should().Be(HttpMethod.Delete);
						var id = request.RequestUri.Segments[2];
						id.Should().NotBeNullOrWhiteSpace().And.NotBe(channelId);
						return new HttpResponseMessage(HttpStatusCode.NotFound);
					}))))
				.Build();

			await Assert.ThrowsAsync<OcmServiceException>(() => client.DeleteChannelAsync(Guid.NewGuid().ToString("N")));
		}

	}
}

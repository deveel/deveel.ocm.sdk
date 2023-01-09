using System.Net;
using System.Net.Http.Json;

using Deveel.Testing;

using FluentAssertions;

namespace Deveel.Messaging.Channels {
	public class GetChannelSchemaTests {
		private readonly OcmClientBuilder clientBuilder;

		public GetChannelSchemaTests() {
			clientBuilder = OcmClientBuilder.Default
				.UseSettings(settings => settings.UseAccessToken(Guid.NewGuid().ToString("N"), DateTimeOffset.UtcNow.AddMinutes(20)));
		}

		[Fact]
		public async Task ListSchemata() {
			var client = clientBuilder
				.AddChannelManagement(channels => channels
					.UseSettings(settings => settings.UseHttpClient(HttpCallbackHandler.Create(request => {
						return new HttpResponseMessage(HttpStatusCode.OK) {
							Content = JsonContent.Create(new [] {
								new { 
									type = "sms", 
									provider = "twilio",
									contentTypes = new []{ "text" }, 
									senderTypes= new[]{ "phoneNumber" },
									receiverTypes = new[]{"phoneNumber"}
								}
							})
						};
					}))))
				.Build();

			var schemata = await client.ListChannelSchemaAsync();

			schemata.Should().NotBeNullOrEmpty();
			schemata.Count.Should().Be(1);

			schemata[0].Should().NotBeNull();
			schemata[0].Type.Should().Be(ChannelType.Sms);
			schemata[0].Provider.Should().Be(new ChannelProvider("twilio"));
			schemata[0].ContentTypes.Should().NotBeNullOrEmpty().And.Contain(MessageContentType.Text);
			schemata[0].ReceiverTypes.Should().NotBeNullOrEmpty().And.Contain(TerminalType.PhoneNumber);
			schemata[0].SenderTypes.Should().NotBeNullOrEmpty().And.Contain(TerminalType.PhoneNumber);
		}
	}
}

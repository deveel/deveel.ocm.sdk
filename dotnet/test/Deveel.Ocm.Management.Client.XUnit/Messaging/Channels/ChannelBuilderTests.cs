using System;

using FluentAssertions;

namespace Deveel.Messaging.Channels {
	public static class ChannelBuilderTests {
		[Fact]
		public static void BuildTwilioSms() {
			var channel = new UserChannelBuilder()
				.WithName("channel-1")
				.OfType(ChannelType.Sms)
				.ProvidedBy("twilio")
				.AsDuplex()
				.HandlingText()
				.WithContext("org", "marketing")
				.With("retry.count", 3)
				.Build();

			channel.Should().NotBeNull();
			channel.Name.Should().Be(new ChannelName("channel-1"));
			channel.Type.Should().Be(ChannelType.Sms);
			channel.Directions.Should().Be(ChannelDirections.Duplex);
			channel.ContentTypes.Should().NotBeNullOrEmpty();
			channel.ContentTypes.Should().Contain(MessageContentType.Text);
			channel.Context.Should().NotBeNullOrEmpty().And
				.Contain(new KeyValuePair<string, object>("org", "marketing"));
			channel.Settings.Should().NotBeNullOrEmpty().And
				.Contain(new KeyValuePair<string, object>("retry.count", 3));
		}
	}
}

using System;

using FluentAssertions;

namespace Deveel.Messaging {
	public static class MessageBuildTests {
		[Fact]
		public static void BuildEmailWithTextContent() {
			var message = new MessageBuilder()
				.UseChannel("test-channel-1")
				.FromEmail("info@deveel.com")
				.ToEmail("antonello@example.com")
				.HasTextContent(text => text.Append("Hello! This is a test..."))
				.With("subject", "Test message")
				.WithContext("campaign", "new-sales-2022")
				.Build();

			message.Should().NotBeNull();
			message.ChannelName.Should().NotBeNullOrWhiteSpace().And.Be("test-channel-1");

			message.Sender.Should().NotBeNull();
			message.Sender.HasValue.Should().BeTrue();
			message.Sender.Value.EndPoint.Should().Be("info@deveel.com");
			message.Sender.Value.Type.Should().Be(TerminalType.EmailAddress);

			message.Receiver.EndPoint.Should().Be("antonello@example.com");
			message.Receiver.Type.Should().Be(TerminalType.EmailAddress);

			message.Content.Should().NotBeNull().And
				.BeOfType<TextContent>().Subject.Content.Should().NotBeNull().And.Be("Hello! This is a test...");

			message.Extensions.Should().NotBeNull().And.NotBeEmpty()
				.And.Subject.First().Should().BeEquivalentTo(new KeyValuePair<string, object>("subject", "Test message"));

			message.Context.Should().NotBeNull().And.NotBeEmpty()
				.And.Subject.First().Should().BeEquivalentTo(new KeyValuePair<string, object>("campaign", "new-sales-2022"));
		}

		[Fact]
		public static void BuildEmailWithTextContentFallbackToSms() {
			var message = new MessageBuilder()
				.UseChannel("test-channel-1")
				.FromEmail("info@deveel.com")
				.ToEmail("antonello@example.com")
				.HasTextContent(text => text.Append("Hello! This is a test..."))
				.With("subject", "Test message")
				.WithContext("campaign", "new-sales-2022")
				.FallbackTo(fallback => fallback
					.UseChannel("sms-1")
					.FromPhone("+18002210001")
					.ToPhone("+4740873833")
					.HasTextContent("Hello! This is a test..."))
				.Build();

			message.Should().NotBeNull();
			message.ChannelName.Should().NotBeNullOrWhiteSpace().And.Be("test-channel-1");

			message.Sender.Should().NotBeNull();
			message.Sender.HasValue.Should().BeTrue();
			message.Sender.Value.EndPoint.Should().Be("info@deveel.com");
			message.Sender.Value.Type.Should().Be(TerminalType.EmailAddress);

			message.Receiver.EndPoint.Should().Be("antonello@example.com");
			message.Receiver.Type.Should().Be(TerminalType.EmailAddress);

			message.Content.Should().NotBeNull().And
				.BeOfType<TextContent>().Subject.Content.Should().NotBeNull().And.Be("Hello! This is a test...");

			message.Extensions.Should().NotBeNull().And.NotBeEmpty()
				.And.Subject.First().Should().BeEquivalentTo(new KeyValuePair<string, object>("subject", "Test message"));

			message.Context.Should().NotBeNull().And.NotBeEmpty()
				.And.Subject.First().Should().BeEquivalentTo(new KeyValuePair<string, object>("campaign", "new-sales-2022"));

			message.Fallback.Should().NotBeNull();
			message.Fallback.ChannelName.Should().NotBeNullOrWhiteSpace().And.Be("sms-1");
			message.Fallback.Sender.Should().NotBeNull();
			message.Fallback.Sender.Value.Type.Should().Be(TerminalType.PhoneNumber);
			message.Fallback.Sender.Value.EndPoint.Should().Be("+18002210001");
			message.Fallback.Receiver.Type.Should().Be(TerminalType.PhoneNumber);
			message.Fallback.Receiver.EndPoint.Should().Be("+4740873833");
		}

	}
}

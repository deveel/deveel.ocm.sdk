using System;

using FluentAssertions;

namespace Deveel.Messaging.Terminals {
	public static class ServerTerminalBuilderTests {
		[Fact]
		public static void BuildEmail() {
			var email = new ServerTerminalBuilder()
				.AsEmail("no-reply@deveel.com")
				.ProvidedBy("sendgrid")
				.AsSender()
				.Build();

			email.Should().NotBeNull();
			email.Address.Should().NotBeNullOrWhiteSpace().And.Be("no-reply@deveel.com");
			email.Type.Should().Be(TerminalType.EmailAddress);
			email.Provider.Should().Be("sendgrid");
		}

		[Fact]
		public static void BuildPhone() {
			var phone = new ServerTerminalBuilder()
				.AsPhone("+18002933933")
				.ProvidedBy("twilio")
				.AsSender()
				.AsReceiver()
				.Build();

			phone.Should().NotBeNull();
			phone.Address.Should().NotBeNullOrWhiteSpace().And.Be("+18002933933");
			phone.Provider.Should().Be("twilio");
			phone.Type.Should().Be(TerminalType.PhoneNumber);
		}
	}
}

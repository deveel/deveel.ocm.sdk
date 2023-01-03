using System;

namespace Deveel.Messaging.Terminals {
	public sealed class ServerTerminalBuilder {
		private ServerTerminalRoles? terminalRoles;
		private TerminalType? terminalType;
		private string? terminalAddress;
		private string? provider;
		// TODO: private IDictionary<string, object?>? context;

		public ServerTerminalBuilder OfType(TerminalType type) {
			this.terminalType = type;
			return this;
		}

		public ServerTerminalBuilder WithAddress(string address) {
			if (string.IsNullOrWhiteSpace(address)) 
				throw new ArgumentException($"'{nameof(address)}' cannot be null or whitespace.", nameof(address));

			this.terminalAddress = address;

			return this;
		}

		public ServerTerminalBuilder AsEmail(string email)
			=> OfType(TerminalType.EmailAddress).WithAddress(email);

		public ServerTerminalBuilder AsPhone(string number)
			=> OfType(TerminalType.PhoneNumber).WithAddress(number);

		public ServerTerminalBuilder ProvidedBy(string provider) {
			if (string.IsNullOrWhiteSpace(provider)) 
				throw new ArgumentException($"'{nameof(provider)}' cannot be null or whitespace.", nameof(provider));

			this.provider = provider;

			return this;
		}

		// TODO:
		//public ServerTerminalBuilder WithContext(IDictionary<string, object?> context) {
		//	this.context = context ?? throw new ArgumentNullException(nameof(context));

		//	return this;
		//}

		//public ServerTerminalBuilder WithContext(string key, object? value) {
		//	if (string.IsNullOrWhiteSpace(key)) 
		//		throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));

		//	if (context == null)
		//		context = new Dictionary<string, object?>();

		//	context[key] = value;

		//	return this;
		//}

		public ServerTerminalBuilder WithRoles(ServerTerminalRoles roles) {
			if (terminalRoles == null) {
				terminalRoles = roles;
			} else {
				terminalRoles |= roles;
			}

			return this;
		}

		public ServerTerminalBuilder AsSender()
			=> WithRoles(ServerTerminalRoles.Sender);

		public ServerTerminalBuilder AsReceiver()
			=> WithRoles(ServerTerminalRoles.Receiver);

		public ServerTerminal Build() {
			if (terminalType == null)
				throw new InvalidOperationException("The terminal type is missing");
			if (String.IsNullOrWhiteSpace(terminalAddress))
				throw new InvalidOperationException("The address is missing");
			if (String.IsNullOrWhiteSpace(provider))
				throw new InvalidOperationException("The provider is not specified");

			return new ServerTerminal(terminalType.Value, terminalAddress, provider) {
				Roles = terminalRoles,
				// TODO: Context = context?.ToDictionary(x => x.Key, x => x.Value)
			};
		}
	}
}

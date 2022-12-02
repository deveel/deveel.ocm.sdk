using System;

using Deveel.Messaging.Terminals.Management;
using Deveel.Messaging.Terminals.Management.Models;

using Microsoft.Extensions.DependencyInjection;

namespace Deveel.Messaging.Terminals {
	public sealed class CreateTerminalCommandBuilder : IClientCommandBuilder<CreateTerminalCommand, ServerTerminal> {
		private string? address;
		private TerminalRoles? roles;
		private ServerTerminalType? type;
		private string? provider;

		public CreateTerminalCommandBuilder OfType(ServerTerminalType type) {
			this.type = type;
			return this;
		}

		public CreateTerminalCommandBuilder WithRoles(TerminalRoles roles) {
			if (this.roles == null) {
				this.roles = roles;
			} else {
				this.roles = (this.roles.Value | roles);
			}

			return this;
		}

		public CreateTerminalCommandBuilder AsSender()
			=> WithRoles(TerminalRoles.Sender);

		public CreateTerminalCommandBuilder AdReceiver()
			=> WithRoles(TerminalRoles.Receiver);

		public CreateTerminalCommandBuilder WithAddress(string address) {
			if (String.IsNullOrWhiteSpace(address))
				throw new ArgumentException($"'{nameof(address)}' cannot be null or whitespace.", nameof(address));

			this.address = address;

			return this;
		}

		public CreateTerminalCommandBuilder ByProvider(string provider) {
			if (String.IsNullOrWhiteSpace(provider))
				throw new ArgumentException($"'{nameof(provider)}' cannot be null or whitespace.", nameof(provider));

			this.provider = provider;

			return this;
		}

		private ServerTerminalType Type => type ?? throw new MessagingClientException("The terminal type was not set");

		private TerminalRoles Roles => roles ?? throw new MessagingClientException("The terminal roles were not set");

		private string Address => String.IsNullOrWhiteSpace(address) ? throw new MessagingClientException("The address was not set") : address;

		private string Provider => String.IsNullOrWhiteSpace(provider) ? throw new MessagingClientException("The provider was not set") : provider;

		public CreateTerminalCommand Build() {
			return new CreateTerminalCommand(Type, Address, Provider, Roles);
		}
	}
}

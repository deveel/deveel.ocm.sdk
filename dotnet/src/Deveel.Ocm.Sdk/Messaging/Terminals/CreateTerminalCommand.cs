﻿using Deveel.Messaging.Terminals.Management.Models;

namespace Deveel.Messaging.Terminals {
	public sealed class CreateTerminalCommand : IClientCommand<ServerTerminal> {
		public CreateTerminalCommand(ServerTerminalType type, string address, string provider, TerminalRoles roles) {
			if (String.IsNullOrWhiteSpace(address))
				throw new ArgumentException($"'{nameof(address)}' cannot be null or whitespace.", nameof(address));
			if (String.IsNullOrWhiteSpace(provider))
				throw new ArgumentException($"'{nameof(provider)}' cannot be null or whitespace.", nameof(provider));

			Type = type;
			Address = address;
			Provider = provider;
			Roles = roles;
		}

		public string Address { get; }

		public ServerTerminalType Type { get; }

		public string Provider { get; }

		public TerminalRoles Roles { get; }

		private Management.Models.ServerTerminalType GetServerTerminalType()
			=> Type switch {
				ServerTerminalType.Email => Management.Models.ServerTerminalType.Email,
				ServerTerminalType.AlphaNumeric => Management.Models.ServerTerminalType.AlphaNumeric,
				ServerTerminalType.PhoneNumber => Management.Models.ServerTerminalType.PhoneNumber,
				_ => throw new MessagingClientException("Invalid server terminal type")
			};

		private Management.Models.TerminalRoles GetTerminalRoles() {
			if (Roles.HasFlag(TerminalRoles.Sender) &&
				Roles.HasFlag(TerminalRoles.Receiver)) {
				return Management.Models.TerminalRoles.Both;
			} else if (Roles.HasFlag(TerminalRoles.Receiver)) {
				return Management.Models.TerminalRoles.Receiver;
			} else if (Roles.HasFlag(TerminalRoles.Sender)) {
				return Management.Models.TerminalRoles.Sender;
			} else {
				throw new MessagingClientException("Invalid terminal roles");
			}
		}
	}
}

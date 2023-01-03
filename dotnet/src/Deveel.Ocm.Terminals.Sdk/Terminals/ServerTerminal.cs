using System;

using Deveel.Messaging.Terminals.Management.Models;

namespace Deveel.Messaging.Terminals {
	public sealed class ServerTerminal {
		public ServerTerminal(TerminalType type, string address, string provider) {
			if (string.IsNullOrWhiteSpace(address)) 
				throw new ArgumentException($"'{nameof(address)}' cannot be null or whitespace.", nameof(address));
			if (string.IsNullOrWhiteSpace(provider)) 
				throw new ArgumentException($"'{nameof(provider)}' cannot be null or whitespace.", nameof(provider));

			Type = type;
			Address = address;
			Provider = provider;
		}

		public string? Id { get; private set; }

		public TerminalType Type { get; }

		public string Address { get; }

		public string Provider { get; }

		public ServerTerminalRoles? Roles { get; set; }

		// TODO: public IDictionary<string, object?>? Context { get; set; }

		private static Management.Models.ServerTerminalType AsClientServerTerminalType(TerminalType type) {
			return type switch {
				TerminalType.EmailAddress => ServerTerminalType.Email,
				TerminalType.AlphaNumeric => ServerTerminalType.AlphaNumeric,
				TerminalType.PhoneNumber => ServerTerminalType.PhoneNumber,
				_ => throw new MessagingClientException("Invalid server terminal type")
			};
		}

		private static Management.Models.TerminalRoles AsClientTerminalRoles(ServerTerminalRoles? roles) {
			if (roles == null)
				return Management.Models.TerminalRoles.Default;

			if (roles.Value.HasFlag(ServerTerminalRoles.Sender) &&
				roles.Value.HasFlag(ServerTerminalRoles.Receiver)) {
				return Management.Models.TerminalRoles.Both;
			} else if (roles.Value.HasFlag(ServerTerminalRoles.Receiver)) {
				return Management.Models.TerminalRoles.Receiver;
			} else if (roles.Value.HasFlag(ServerTerminalRoles.Sender)) {
				return Management.Models.TerminalRoles.Sender;
			} else {
				throw new MessagingClientException("Invalid terminal roles");
			}
		}

		internal Management.Models.NewServerTerminal AsNewServerTerminal() {
			// TODO: set the context to append on ever message sent/received through the terminal... 
			return new NewServerTerminal(Provider, AsClientTerminalRoles(Roles), AsClientServerTerminalType(Type), Address) {
			};
		}
	}
}

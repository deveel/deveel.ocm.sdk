using System;

using Deveel.Messaging.Terminals.Management.Models;

namespace Deveel.Messaging.Terminals {
	static class ServerTerminalTypeExtensions {
		public static Management.Models.ServerTerminalType AsClientServerTerminalType(this TerminalType type) {
			return type switch {
				TerminalType.EmailAddress => ServerTerminalType.Email,
				TerminalType.AlphaNumeric => ServerTerminalType.AlphaNumeric,
				TerminalType.PhoneNumber => ServerTerminalType.PhoneNumber,
				_ => throw new MessagingClientException($"Invalid server terminal type '{type}'")
			};
		}

		public static TerminalType AsTerminalType(this Management.Models.ServerTerminalType terminalType) {
			return terminalType.ToString() switch {
				var x when x == Management.Models.ServerTerminalType.Email => TerminalType.EmailAddress,
				var x when x == Management.Models.ServerTerminalType.PhoneNumber => TerminalType.PhoneNumber,
				var x when x == Management.Models.ServerTerminalType.AlphaNumeric => TerminalType.AlphaNumeric,
				_ => throw new MessagingClientException($"Invalid server terminal type '{terminalType}'")
			};
		}
	}
}

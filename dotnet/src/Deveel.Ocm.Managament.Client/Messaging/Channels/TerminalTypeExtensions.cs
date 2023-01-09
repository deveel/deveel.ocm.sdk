using System;

namespace Deveel.Messaging.Channels {
	static class TerminalTypeExtensions {
		public static TerminalType AsTerminalType(this Management.Models.TerminalType terminalType)
			=> terminalType.ToString() switch {
				var x when x == Management.Models.TerminalType.Email => TerminalType.EmailAddress,
				var x when x == Management.Models.TerminalType.PhoneNumber => TerminalType.PhoneNumber,
				_ => throw new NotSupportedException($"The terminal type '{terminalType}' is not supported")
			};

		public static Management.Models.TerminalType AsClientTerminalType(this TerminalType terminalType)
			=> terminalType switch {
				TerminalType.EmailAddress => Management.Models.TerminalType.Email,
				TerminalType.PhoneNumber => Management.Models.TerminalType.PhoneNumber,
				_ => throw new NotSupportedException($"The terminal type '{terminalType}' is not supported")
			};
	}
}

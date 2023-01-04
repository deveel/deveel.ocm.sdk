using System;

namespace Deveel.Messaging.Terminals {
	internal static class ServerTerminalRolesExtensions {
		public static ServerTerminalRoles? AsTerminalRoles(this Management.Models.TerminalRoles roles) {
			return roles switch {
				var x when x == Management.Models.TerminalRoles.Default => null,
				var x when x == Management.Models.TerminalRoles.Receiver => ServerTerminalRoles.Receiver,
				var x when x == Management.Models.TerminalRoles.Sender => ServerTerminalRoles.Sender,
				var x when x == Management.Models.TerminalRoles.Both => ServerTerminalRoles.Both,
				_ => throw new NotSupportedException($"Terminal type '{roles}' is not supported")
			};
		}

		public static Management.Models.TerminalRoles AsClientTerminalRoles(this ServerTerminalRoles? roles) {
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

	}
}

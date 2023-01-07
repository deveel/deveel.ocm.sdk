using System;

using Deveel.Messaging.Commands;

namespace Deveel.Messaging.Terminals.Commands {
	class ChangeTerminalRoleCommand : IClientCommand {
		public ChangeTerminalRoleCommand(string terminalId, ServerTerminalRoles newRole) {
			if (string.IsNullOrWhiteSpace(terminalId)) 
				throw new ArgumentException($"'{nameof(terminalId)}' cannot be null or whitespace.", nameof(terminalId));

			TerminalId = terminalId;
			NewRole = newRole;
		}

		public string TerminalId { get; }

		public ServerTerminalRoles NewRole { get; }
	}
}

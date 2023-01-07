using System;

using Deveel.Messaging.Commands;
using Deveel.Messaging.Terminals.Management;

namespace Deveel.Messaging.Terminals.Commands {
	class ChangeTerminalRoleCommandHandler : IClientCommandHandler<ChangeTerminalRoleCommand> {
		private readonly TerminalClient client;

		public ChangeTerminalRoleCommandHandler(TerminalClient client) {
			this.client = client;
		}

		public async Task HandleAsync(ChangeTerminalRoleCommand command, CancellationToken cancellationToken = default) {
			var newRole = ServerTerminalRolesExtensions.AsClientTerminalRoles(command.NewRole);
			await client.ChangeTerminalRoleAsync(command.TerminalId, new Management.Models.NewTerminalRole(newRole), cancellationToken);
		}
	}
}

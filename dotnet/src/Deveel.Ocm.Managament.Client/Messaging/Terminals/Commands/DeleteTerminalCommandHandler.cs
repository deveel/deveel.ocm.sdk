using System;

using Deveel.Messaging.Commands;
using Deveel.Messaging.Terminals.Management;

namespace Deveel.Messaging.Terminals.Commands {
	class DeleteTerminalCommandHandler : IClientCommandHandler<DeleteTerminalCommand> {
		private readonly TerminalClient client;

		public DeleteTerminalCommandHandler(TerminalClient client) {
			this.client = client;
		}

		public async Task HandleAsync(DeleteTerminalCommand command, CancellationToken cancellationToken = default) {
			await client.RemoveTerminalAsync(command.TerminalId, cancellationToken);
		}
	}
}

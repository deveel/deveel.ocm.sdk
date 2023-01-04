using System;

using Deveel.Messaging.Commands;
using Deveel.Messaging.Terminals.Management;

namespace Deveel.Messaging.Terminals.Commands {
	class GetTerminalCommandHandler : IClientCommandHandler<GetTerminalCommand, ServerTerminal?> {
		private readonly TerminalClient client;

		public GetTerminalCommandHandler(TerminalClient client) {
			this.client = client;
		}

		public async Task<ServerTerminal?> HandleAsync(GetTerminalCommand command, CancellationToken cancellationToken = default) {
			var result = await client.GetTerminalAsync(command.TerminalId, cancellationToken);
			if (result == null || result.Value == null || result.GetRawResponse().Status == 404)
				return null;

			return ServerTerminal.FromClient(result);
		}
	}
}

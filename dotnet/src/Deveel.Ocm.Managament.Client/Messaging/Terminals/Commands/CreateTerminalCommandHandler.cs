using System;

using Deveel.Messaging.Commands;
using Deveel.Messaging.Terminals.Management;

namespace Deveel.Messaging.Terminals.Commands {
	class CreateTerminalCommandHandler : IClientCommandHandler<CreateTerminalCommand, ServerTerminal> {
		private readonly TerminalClient client;

		public CreateTerminalCommandHandler(TerminalClient client) {
			this.client = client;
		}

		public async Task<ServerTerminal> HandleAsync(CreateTerminalCommand request, CancellationToken cancellationToken) {
			var result = await client.CreateTerminalAsync(request.Terminal.AsNewServerTerminal(), cancellationToken);

			return ServerTerminal.FromClient(result);
		}
	}
}

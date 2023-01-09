using System;

using Deveel.Messaging.Commands;
using Deveel.Messaging.Terminals.Management;

namespace Deveel.Messaging.Terminals.Commands {
	class GetTerminalsPageCommandHandler : IClientCommandHandler<GetTerminalsPageCommand, PagedResult<ServerTerminal>> {
		private readonly TerminalClient client;

		public GetTerminalsPageCommandHandler(TerminalClient client) {
			this.client = client;
		}

		public async Task<PagedResult<ServerTerminal>> HandleAsync(GetTerminalsPageCommand command, CancellationToken cancellationToken = default) {
			var page = await client.GetTerminalPageAsync(command.Type, command.Page.Number, command.Page.Size, command.Sort, cancellationToken);

			var result = page.Value;
			return PagedResult<ServerTerminal>.Create(command.Page, result.TotalItems, result.Items?.Select(x => ServerTerminal.FromClient(x)));
		}
	}
}

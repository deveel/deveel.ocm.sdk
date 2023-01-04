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
			var page = await client.GetTerminalPageAsync(command.Type, command.PageNumber, command.PageSize, command.Sort, cancellationToken);

			return PagedResult<ServerTerminal>.Create(page.Value.TotalItems, page.Value.Items?.Select(x => ServerTerminal.FromClient(x)));
		}
	}
}

using System;

using Deveel.Messaging.Commands;
using Deveel.Messaging.Terminals.Management;

namespace Deveel.Messaging.Terminals.Commands {
	class ListProvidersCommandHandler : IClientCommandHandler<ListProvidersCommand, IReadOnlyList<TerminalProvider>> {
		private readonly TerminalClient client;

		public ListProvidersCommandHandler(TerminalClient client) {
			this.client = client;
		}

		public async Task<IReadOnlyList<TerminalProvider>> HandleAsync(ListProvidersCommand command, CancellationToken cancellationToken = default) {
			var result = await client.ListProvidersAsync(command.Type, cancellationToken);
			return result.Value.Select(x => TerminalProvider.FromClient(x)).ToList().AsReadOnly();
		}
	}
}

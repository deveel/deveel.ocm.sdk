using System;

using Deveel.Messaging.Commands;

namespace Deveel.Messaging.Terminals.Commands {
	class ListProvidersCommand : IClientCommand<IReadOnlyList<TerminalProvider>> {
		public ListProvidersCommand(string? type) {
			Type = type;
		}

		public string? Type { get; }
	}
}

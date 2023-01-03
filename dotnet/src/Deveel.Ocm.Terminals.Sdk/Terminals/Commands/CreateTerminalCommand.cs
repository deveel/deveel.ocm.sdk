using Deveel.Messaging.Commands;
using Deveel.Messaging.Terminals.Management.Models;

namespace Deveel.Messaging.Terminals.Commands {
	public sealed class CreateTerminalCommand : IClientCommand<ServerTerminal> {
		public CreateTerminalCommand(ServerTerminal terminal) {
			Terminal = terminal ?? throw new ArgumentNullException(nameof(terminal));
		}

		public ServerTerminal Terminal { get; set; }
	}
}

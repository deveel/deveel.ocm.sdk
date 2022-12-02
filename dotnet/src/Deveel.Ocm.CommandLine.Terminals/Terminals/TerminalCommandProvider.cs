using System;

namespace Deveel.Messaging.Terminals {
	class TerminalCommandProvider : ICommandProvider {
		public void RegisterCommands(CommandRegistry registry) {
			registry.AddCommand<NewTerminalCommand, NewTerminalCommand.Handler>();
		}
	}
}

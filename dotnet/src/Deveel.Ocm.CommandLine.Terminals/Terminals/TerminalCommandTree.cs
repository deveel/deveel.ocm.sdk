using System;
using System.CommandLine;

namespace Deveel.Messaging.Terminals {
	class TerminalCommandTree : ICommandTree {
		public void AppendTo(RootCommand root) {
		var newCommand = root.Subcommands.OfType<NewCommand>().FirstOrDefault();
			if (newCommand != null) {
				newCommand.AddCommand(new NewTerminalCommand());
			}
		}
	}
}

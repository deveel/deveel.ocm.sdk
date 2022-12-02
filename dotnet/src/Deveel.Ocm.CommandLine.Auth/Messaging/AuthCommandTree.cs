using System;
using System.CommandLine;

namespace Deveel.Messaging {
	class AuthCommandTree : ICommandTree {
		public void AppendTo(RootCommand root) {
			root.AddCommand(new LoginCommand());
		}
	}
}

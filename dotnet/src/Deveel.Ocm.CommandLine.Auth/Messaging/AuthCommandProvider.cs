using System;

namespace Deveel.Messaging {
	class AuthCommandProvider : ICommandProvider {
		public void RegisterCommands(CommandRegistry registry) {
			registry.AddCommand<LoginCommand, LoginCommand.Handler>();
		}
	}
}

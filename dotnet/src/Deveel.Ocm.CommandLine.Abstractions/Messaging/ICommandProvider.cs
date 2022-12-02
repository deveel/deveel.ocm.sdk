using System;

namespace Deveel.Messaging {
	public interface ICommandProvider {
		void RegisterCommands(CommandRegistry registry);
	}
}

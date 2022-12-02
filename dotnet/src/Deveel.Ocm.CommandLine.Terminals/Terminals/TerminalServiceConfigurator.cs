using System;

using Deveel.Messaging.Terminals.Management;

using Microsoft.Extensions.DependencyInjection;

namespace Deveel.Messaging.Terminals {
	class TerminalServiceConfigurator : IServiceConfigurator {
		public void ConfigureServices(IServiceCollection services) {
			services.AddSingleton<TerminalClient>(provider => {
				return new TerminalClient(new OcmConsoleCredemtials());
			});
		}
	}
}

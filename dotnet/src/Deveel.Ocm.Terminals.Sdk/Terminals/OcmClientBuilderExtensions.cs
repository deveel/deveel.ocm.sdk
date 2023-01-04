using System;

using Deveel.Messaging.Terminals.Commands;
using Deveel.Messaging.Terminals.Management;

namespace Deveel.Messaging.Terminals {
	public static class OcmClientBuilderExtensions {
		public static OcmClientBuilder AddTerminalManagement(this OcmClientBuilder builder, Action<ServiceClientBuilder<TerminalClient>>? configure = null) {
			builder.ConfigureClientServices(services => {
				services.AddCommandHandler<CreateTerminalCommand, ServerTerminal, CreateTerminalCommandHandler>();
				services.AddCommandHandler<DeleteTerminalCommand, DeleteTerminalCommandHandler>();
				services.AddCommandHandler<GetTerminalCommand, ServerTerminal?, GetTerminalCommandHandler>();
				services.AddCommandHandler<GetTerminalsPageCommand, PagedResult<ServerTerminal>, GetTerminalsPageCommandHandler>();
			});

			builder.AddServiceClient<TerminalClient>(client => client
				.UseFactory<TerminalClientFactory>()
				.Configure(configure));


			return builder;
		}
	}
}

using System;

using Deveel.Messaging.Channels;
using Deveel.Messaging.Channels.Commands;
using Deveel.Messaging.Channels.Management;
using Deveel.Messaging.Terminals;
using Deveel.Messaging.Terminals.Commands;
using Deveel.Messaging.Terminals.Management;

namespace Deveel.Messaging {
	public static class OcmClientBuilderExtensions {
		public static OcmClientBuilder AddTerminalManagement(this OcmClientBuilder builder, Action<ServiceClientBuilder<TerminalClient>>? configure = null) {
			builder.ConfigureClientServices(services => {
				services.AddCommandHandler<CreateTerminalCommand, ServerTerminal, CreateTerminalCommandHandler>();
				services.AddCommandHandler<DeleteTerminalCommand, DeleteTerminalCommandHandler>();
				services.AddCommandHandler<GetTerminalCommand, ServerTerminal?, GetTerminalCommandHandler>();
				services.AddCommandHandler<GetTerminalsPageCommand, PagedResult<ServerTerminal>, GetTerminalsPageCommandHandler>();
				services.AddCommandHandler<ChangeTerminalRoleCommand, ChangeTerminalRoleCommandHandler>();
				services.AddCommandHandler<ListProvidersCommand, IReadOnlyList<TerminalProvider>, ListProvidersCommandHandler>();
			});

			builder.AddServiceClient<TerminalClient>(client => client
				.UseFactory<TerminalClientFactory>()
				.Configure(configure));


			return builder;
		}

		public static OcmClientBuilder AddChannelManagement(this OcmClientBuilder builder, Action<ServiceClientBuilder<ChannelClient>>? configure = null) {
			builder.ConfigureClientServices(services => {
				services.AddCommandHandler<ListChannelSchemaCommand, IReadOnlyList<ChannelSchema>, ListChannelSchemaCommandHandler>();
				services.AddCommandHandler<GetUserChannelCommand, UserChannel?, GetUserChannelCommandHandler>();
			});

			builder.AddServiceClient<ChannelClient>(client => client.UseFactory<ChannelClientFactory>().Configure(configure));

			return builder;
		}
	}
}

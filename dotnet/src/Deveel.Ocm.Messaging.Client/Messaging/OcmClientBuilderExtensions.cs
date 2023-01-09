using System;

using Deveel.Messaging.Commands;

using Microsoft.Extensions.DependencyInjection;

namespace Deveel.Messaging {
	public static class OcmClientBuilderExtensions {
		public static OcmClientBuilder AddMessaging(this OcmClientBuilder builder, Action<ServiceClientBuilder<MessageClient>>? configure = null) {

			builder.ConfigureClientServices(services => {
				services.AddCommandHandler<SendMessageCommand, MessageResult, SendMessageCommandHandler>();
				services.AddCommandHandler<SendBatchCommand, MessageBatchResult, SendBatchCommandHandler>();
			});

			builder.AddServiceClient<MessageClient>(client => client
				.UseFactory<MessageClientFactory>()
				.Configure(configure));

			return builder;
		}
	}
}

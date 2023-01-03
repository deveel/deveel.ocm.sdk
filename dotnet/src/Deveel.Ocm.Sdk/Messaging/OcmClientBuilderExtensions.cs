using System;

using Deveel.Messaging.Commands;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace Deveel.Messaging {
	public static class OcmClientBuilderExtensions {
		public static OcmClientBuilder AddMessaging(this OcmClientBuilder builder, Action<ServiceClientBuilder<MessageClient>>? configure = null) {

			builder.ConfigureClientServices(services => {
				services.AddMediatR(typeof(SendMessageCommand));
				//services.AddTransient<IRequestHandler<SendMessageCommand, MessageResult>, SendMessageCommandHandler>();
				//services.AddTransient<IRequestHandler<SendBatchCommand, MessageBatchResult>, SendBatchCommandHandler>();
			});

			builder.AddServiceClient<MessageClient>(client => client
				.UseFactory<MessageClientFactory>()
				.Configure(configure));

			return builder;
		}
	}
}

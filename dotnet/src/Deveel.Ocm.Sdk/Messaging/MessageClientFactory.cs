using System;

namespace Deveel.Messaging {
	class MessageClientFactory : IServiceClientFactory<MessageClient> {
		public MessageClient CreateClient(ServiceClientContext<MessageClient> context) {
			var options = new MessageClientOptions();
			if (context.Settings.Retry != null) {
				context.Settings.Retry.SetOptions(options.Retry);
			}

			if (context.Settings.Transport != null) {
				options.Transport = context.Settings.Transport;
			}

			if (context.Settings.Authentication.TryAsAzureKeyCredential(out var apiKey)) {
				return new MessageClient(apiKey, context.Settings.BaseUrl, options);
			} else if (context.Settings.Authentication.TryAsTokenCredential(context.Services, out var token)) {
				return new MessageClient(token, context.Settings.BaseUrl, options);
			}

			throw new NotSupportedException("Could not construct the message client without authentication");
		}
	}
}

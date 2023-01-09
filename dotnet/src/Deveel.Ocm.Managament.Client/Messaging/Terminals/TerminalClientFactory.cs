using System;

using Deveel.Messaging.Terminals.Management;

namespace Deveel.Messaging.Terminals {
	class TerminalClientFactory : IServiceClientFactory<TerminalClient> {
		public TerminalClient CreateClient(ServiceClientContext<TerminalClient> context) {
			var options = new TerminalClientOptions();
			if (context.Settings.Retry != null) {
				context.Settings.Retry.SetOptions(options.Retry);
			}

			if (context.Settings.Transport != null) {
				options.Transport = context.Settings.Transport;
			}

			if (context.Settings.Authentication.TryAsAzureKeyCredential(out var apiKey)) {
				return new TerminalClient(apiKey, context.Settings.BaseUrl, options);
			} else if (context.Settings.Authentication.TryAsTokenCredential(context.Services, out var token)) {
				return new TerminalClient(token, context.Settings.BaseUrl, options);
			}

			throw new NotSupportedException("Could not construct the terminal client without authentication");

		}
	}
}

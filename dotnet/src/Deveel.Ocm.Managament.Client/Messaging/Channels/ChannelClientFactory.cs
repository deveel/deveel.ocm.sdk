using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Deveel.Messaging.Channels.Management;
using Deveel.Messaging.Terminals.Management;

namespace Deveel.Messaging.Channels {
	class ChannelClientFactory : IServiceClientFactory<ChannelClient> {
		public ChannelClient CreateClient(ServiceClientContext<ChannelClient> context) {
			var options = new ChannelClientOptions();
			if (context.Settings.Retry != null) {
				context.Settings.Retry.SetOptions(options.Retry);
			}

			if (context.Settings.Transport != null) {
				options.Transport = context.Settings.Transport;
			}

			if (context.Settings.Authentication.TryAsAzureKeyCredential(out var apiKey)) {
				return new ChannelClient(apiKey, context.Settings.BaseUrl, options);
			} else if (context.Settings.Authentication.TryAsTokenCredential(context.Services, out var token)) {
				return new ChannelClient(token, context.Settings.BaseUrl, options);
			}

			throw new NotSupportedException("Could not construct the terminal client without authentication");
		}
	}
}

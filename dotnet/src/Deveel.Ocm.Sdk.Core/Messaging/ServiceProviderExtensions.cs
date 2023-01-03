using System;

using Microsoft.Extensions.DependencyInjection;

namespace Deveel.Messaging {
	public static class ServiceProviderExtensions {
		public static ServiceClientSettings<TClient> GetClientSettings<TClient>(this IServiceProvider provider) 
			where TClient : class {
			var settings = provider.GetService<ServiceClientSettings<TClient>>();
			var defaultSettings = provider.GetService<OcmClientSettings>();

			if (settings == null) {
				settings = new ServiceClientSettings<TClient>(defaultSettings);
			} else {
				settings.DefaultSettings = defaultSettings;
			}

			return settings;
		}
	}
}

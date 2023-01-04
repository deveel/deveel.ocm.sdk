using System;

using Microsoft.Extensions.DependencyInjection;

namespace Deveel.Messaging {
	public sealed class OcmClient : IOcmClient {
		public OcmClient(OcmClientSettings settings, IServiceProvider? services = null) {
			Settings = settings ?? throw new ArgumentNullException(nameof(settings));

			if (services != null) {
				Services = services;
			} else if (settings.Services!= null) {
				Services = settings.Services.BuildServiceProvider();
			} else {
				throw new ArgumentException("The service collection for the client are not configured");
			}
		}

		public OcmClientSettings Settings { get; }

		public IServiceProvider Services { get; }
	}
}

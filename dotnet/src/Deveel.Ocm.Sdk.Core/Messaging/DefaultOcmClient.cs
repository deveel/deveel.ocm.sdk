using System;

namespace Deveel.Messaging {
	class DefaultOcmClient : IOcmClient {
		public DefaultOcmClient(OcmClientSettings settings, IServiceProvider services) {
			Settings = settings ?? throw new ArgumentNullException(nameof(settings));
			Services = services ?? throw new ArgumentNullException(nameof(services));
		}

		public OcmClientSettings Settings { get; }

		public IServiceProvider Services { get; }
	}
}

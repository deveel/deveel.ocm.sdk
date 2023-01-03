using System;

namespace Deveel.Messaging {
	public sealed class ServiceClientContext<TClient> where TClient : class {
		internal ServiceClientContext(IServiceProvider services, ServiceClientSettings<TClient> settings) {
			Services = services;
			Settings = settings;
		}

		public IServiceProvider Services { get; }

		public ServiceClientSettings<TClient> Settings { get; }
	}
}

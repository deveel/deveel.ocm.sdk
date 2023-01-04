using System;
using System.Collections.Immutable;
using System.Net.Security;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Deveel.Messaging {
	public sealed class ServiceClientBuilder<TClient> where TClient : class {
		private readonly IServiceCollection services;
		private ServiceLifetime lifetime;

		internal ServiceClientBuilder(IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Singleton) {
			this.services = services;
			this.lifetime = lifetime;

			RegisterClient();
		}

		public ServiceClientBuilder<TClient> WithLifetime(ServiceLifetime lifetime) {
			this.lifetime = lifetime;

			services.RemoveAll<TClient>();
			services.RemoveAll<IServiceClientFactory<TClient>>();

			RegisterClient();

			return this;
		}

		private void RegisterClient() {
			services.Add(new ServiceDescriptor(typeof(TClient), typeof(TClient), lifetime));
		}

		public ServiceClientBuilder<TClient> UseFactory<TFactory>()
			where TFactory : class, IServiceClientFactory<TClient> {

			services.Add(new ServiceDescriptor(typeof(IServiceClientFactory<TClient>), typeof(TFactory), lifetime));
			services.Add(new ServiceDescriptor(typeof(TFactory), typeof(TFactory), lifetime));

			var serviceFactory = (IServiceProvider provider) => {
				var clientFactory = provider.GetRequiredService<TFactory>();
				var settings = provider.GetClientSettings<TClient>();

				return clientFactory.CreateClient(new ServiceClientContext<TClient>(provider, settings));
			};

			services.Add(new ServiceDescriptor(typeof(TClient), serviceFactory, lifetime));

			return this;
		}

		public ServiceClientBuilder<TClient> UseFactory(Func<ServiceClientContext<TClient>, TClient> factory) {
			var serviceFactory = (IServiceProvider provider) => {
				var settings = provider.GetClientSettings<TClient>();
				return factory(new ServiceClientContext<TClient>(provider, settings));
			};

			services.Add(new ServiceDescriptor(typeof(IServiceClientFactory<TClient>), serviceFactory, lifetime));

			return this;
		}

		// TODO: make settings specific for an instance of the client (decorator?)
		public ServiceClientBuilder<TClient> UseSettings(Action<ServiceClientSettingsBuilder<TClient>> configure) {
			var builder = new ServiceClientSettingsBuilder<TClient>();
			configure(builder);

			services.AddServiceClientSettings(builder.Settings);

			return this;
		}

		public ServiceClientBuilder<TClient> Configure(Action<ServiceClientBuilder<TClient>>? configure) {
			configure?.Invoke(this);

			return this;
		}
	}
}

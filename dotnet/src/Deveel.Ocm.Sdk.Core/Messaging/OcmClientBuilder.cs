using System;

using MediatR.Registration;
using MediatR;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Sockets;

namespace Deveel.Messaging {
	public sealed class OcmClientBuilder {
		private readonly IServiceCollection services;
		private ServiceLifetime lifetime;

		public OcmClientBuilder(IServiceCollection services, ServiceLifetime lifetime) {
			this.services = services;
			this.lifetime = lifetime;

			RegisterMediator();
			RegisterClient();
		}

		private void RegisterMediator() {
			ServiceRegistrar.AddRequiredServices(services, new MediatRServiceConfiguration());
		}

		private void RegisterClient() {
			services.Add(new ServiceDescriptor(typeof(IOcmClient), typeof(DefaultOcmClient), lifetime));
		}

		public OcmClientBuilder WithLifetime(ServiceLifetime lifetime) {
			this.lifetime = lifetime;

			services.RemoveAll<IOcmClient>();

			RegisterClient();

			return this;
		}

		public OcmClientBuilder UseSettings(Action<OcmClientSettingsBuilder> configure) {
			var builder = new OcmClientSettingsBuilder();
			configure(builder);

			services.AddOcmClientSettings(builder.Build());

			return this;
		}

		public OcmClientBuilder AddServiceClient<TClient>(Action<ServiceClientBuilder<TClient>>? configure = null)
			where TClient : class {
			var builder = new ServiceClientBuilder<TClient>(services);
			configure?.Invoke(builder);

			return this;
		}

		public OcmClientBuilder ConfigureClientServices(Action<IServiceCollection> configure) {
			configure(services);

			return this;
		}
	}
}

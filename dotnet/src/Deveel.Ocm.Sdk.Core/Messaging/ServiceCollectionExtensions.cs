using System.Net;
using System.Net.Sockets;
using System.Reflection;

using Azure;
using Azure.Core;

using Deveel.Security;

using IdentityModel;

using Microsoft.Extensions.DependencyInjection;

namespace Deveel.Messaging {
	public static class ServiceCollectionExtensions {
		public static IServiceCollection AddAccessTokenReader<TReader>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Singleton) 
			where TReader : class, IAccessTokenReader{
			services.Add(new ServiceDescriptor(typeof(IAccessTokenReader), typeof(TReader), lifetime));
			services.Add(new ServiceDescriptor(typeof(TReader), typeof(TReader), lifetime));

			return services;
		}

		public static IServiceCollection AddAccessTokenReader<TReader>(this IServiceCollection services, TReader reader)
			where TReader : class, IAccessTokenReader {
			services.AddSingleton<IAccessTokenReader>(reader);
			services.AddSingleton(reader);

			return services;
		}

		public static IServiceCollection AddServiceClient<TClient>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Singleton)
			where TClient : class {

			Func<IServiceProvider, TClient> factory = (provider) => ConstructClient<TClient>(provider);

			services.Add(new ServiceDescriptor(typeof(TClient), factory, lifetime));

			return services;
		}

		private static TClient ConstructClient<TClient>(IServiceProvider provider) where TClient : class {
			var defaultSettings = provider.GetRequiredService<OcmClientSettings>();
			var clientFactory = provider.GetService<IServiceClientFactory<TClient>>();
			if (clientFactory != null) {
				var serviceSettings = provider.GetClientSettings<TClient>();

				return clientFactory.CreateClient(new ServiceClientContext<TClient>(provider, serviceSettings));
			}

			var credentials = GetCredentials(provider, defaultSettings.Authentication);
			return ConstructClient<TClient>(credentials, defaultSettings.BaseUrl);
		}

		private static TClient ConstructClient<TClient>(object credentials, Uri? baseUrl) where TClient : class {
			Type[] argTypes;
			if (credentials is AzureKeyCredential apiKey) {
				argTypes = new[] { typeof(AzureKeyCredential), typeof(Uri) };
			} else if (credentials is TokenCredential) {
				argTypes = new[] { typeof(TokenCredential), typeof(Uri) }; 
			} else {
				throw new NotSupportedException("Unsupported credentials");
			}

			var ctor = typeof(TClient).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, argTypes);
			if (ctor == null) {
				var newArgTypes = new Type[argTypes.Length + 1];
				Array.Copy(argTypes, newArgTypes, argTypes.Length);
				throw new InvalidOperationException($"Unable to construct the client of type '{typeof(TClient)}'");
			}

			return (TClient)ctor.Invoke(new[] { credentials, baseUrl });
		}

		private static TClient ConstructClient<TClient>(Type[] argTypes, object[] args)
			where TClient : class {
			var ctor = typeof(TClient).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, argTypes);
			if (ctor == null)
				throw new InvalidOperationException($"Unable to construct the client of type '{typeof(TClient)}'");

			return (TClient)ctor.Invoke(args);
		}

		private static object GetCredentials(IServiceProvider provider, IClientAuthentication? authentication) {
			if (authentication is ApiKeyAuthentication apiKey) {
				return new AzureKeyCredential(apiKey.ApiKey);
			} else if (authentication is ClientCredentialsAuthentication clientCredentials) {
				var clientFactory = provider.GetRequiredService<IHttpClientFactory>();
				return new OcmClientCredentials(clientFactory, clientCredentials.ClientId, clientCredentials.ClientSecret, clientCredentials.Scopes);
			} else if (authentication is SessionAccessTokenAuthentication) {
				var reader = provider.GetRequiredService<IAccessTokenReader>();
				return new OcmAccessTokenCredentials(reader);
			} else if (authentication is AccessTokenAuthentication accessToken) {
				var reader = new StaticAccessTokenReader(new AccessToken(accessToken.AccessToken, accessToken.ExpiresAt));
				return new OcmAccessTokenCredentials(reader);
			}

			throw new NotSupportedException();
		}

		public static IServiceCollection AddOcmClientSettings(this IServiceCollection services, OcmClientSettings settings) {
			services.AddSingleton(settings);

			return services;
		}

		public static IServiceCollection AddOcmClientSettings(this IServiceCollection services, Action<OcmClientSettingsBuilder> configure) {
			var builder = new OcmClientSettingsBuilder();
			configure(builder);

			return services.AddOcmClientSettings(builder.Build());
		}

		public static IServiceCollection AddServiceClientSettings<TClient>(this IServiceCollection services, ServiceClientSettings<TClient> settings) 
			where TClient : class {
			services.AddSingleton(settings);

			return services;
		}

		public static IServiceCollection AddServiceClientSettings<TClient>(this IServiceCollection services, Action<ServiceClientSettingsBuilder<TClient>> configure)
			where TClient : class {
			var builder = new ServiceClientSettingsBuilder<TClient>();
			configure(builder);

			return services.AddServiceClientSettings(builder.Settings);
		}


		public static IServiceCollection AddOcmClient(this IServiceCollection services, Action<OcmClientBuilder> configure) {
			var builder = new OcmClientBuilder(services, ServiceLifetime.Singleton);
			configure(builder);

			return services;
		}

		public static IServiceCollection AddOcmClient<TClient>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Singleton) 
			where TClient : class, IOcmClient {

			services.Add(new ServiceDescriptor(typeof(IOcmClient), typeof(TClient), lifetime));
			services.Add(new ServiceDescriptor(typeof(TClient), typeof(TClient), lifetime));

			return services;
		}
	}
}

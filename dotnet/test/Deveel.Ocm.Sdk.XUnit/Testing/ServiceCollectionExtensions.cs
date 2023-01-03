using System;

using Microsoft.Extensions.DependencyInjection;

namespace Deveel.Testing {
	public static class ServiceCollectionExtensions {
		public static IServiceCollection AddTestHttpClientFactory(this IServiceCollection services, IHttpMessageCallback callback) {
			return services.AddSingleton<IHttpClientFactory>(new HttpCallbackClientFactory(callback));
		}

		public static IServiceCollection AddTestHttpClientFactory(this IServiceCollection services, Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> callback)
			=> services.AddTestHttpClientFactory(new DelegatedHttpMessageCallback(callback));

		public static IServiceCollection AddTestHttpClientFactory(this IServiceCollection services, Func<HttpRequestMessage, Task<HttpResponseMessage>> callback)
			=> services.AddTestHttpClientFactory(new DelegatedHttpMessageCallback(callback));

		public static IServiceCollection AddTestHttpClientFactory(this IServiceCollection services, Func<HttpRequestMessage, HttpResponseMessage> callback)
			=> services.AddTestHttpClientFactory(new DelegatedHttpMessageCallback(callback));

	}
}

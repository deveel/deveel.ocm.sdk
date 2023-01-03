using System;

using Azure.Core.Pipeline;

namespace Deveel.Messaging {
	public sealed class ServiceClientSettingsBuilder<TClient> where TClient : class {
		private readonly ServiceClientSettings<TClient> settings;

		public ServiceClientSettingsBuilder() {
			settings = new ServiceClientSettings<TClient>();
		}

		public ServiceClientSettingsBuilder<TClient> UseBaseUrl(Uri url) {
			if (url is null)
				throw new ArgumentNullException(nameof(url));

			settings.BaseUrl= url;
			return this;
		}

		public ServiceClientSettingsBuilder<TClient> UseRetry(RetryPolicy policy) {
			if (policy is null) 
				throw new ArgumentNullException(nameof(policy));

			settings.Retry = policy;

			return this;
		}

		public ServiceClientSettingsBuilder<TClient> UseTransport(HttpPipelineTransport transport) {
			if (transport is null) 
				throw new ArgumentNullException(nameof(transport));

			settings.Transport = transport;
			return this;
		}

		public ServiceClientSettingsBuilder<TClient> UseHttpClient(HttpClient httpClient) {
			if (httpClient is null) 
				throw new ArgumentNullException(nameof(httpClient));

			settings.Transport = new HttpClientTransport(httpClient);

			return this;
		}

		public ServiceClientSettingsBuilder<TClient> UseHttpClient(HttpMessageHandler handler) {
			if (handler is null)
				throw new ArgumentNullException(nameof(handler));

			settings.Transport = new HttpClientTransport(handler);

			return this;
		}

		public ServiceClientSettings<TClient> Settings => settings;
	}
}

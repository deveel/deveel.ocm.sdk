using System;

using Azure.Core;
using Azure.Core.Pipeline;

namespace Deveel.Messaging {
	public sealed class ServiceClientSettings<TClient> where TClient : class {
		private RetryPolicy? retry;
		private HttpPipelineTransport? transport;
		private IClientAuthentication? authentication;
		private Uri? baseUrl;

		public ServiceClientSettings(OcmClientSettings? defaultSettings = null) {
			DefaultSettings = defaultSettings;
		}

		public OcmClientSettings? DefaultSettings { get; internal set; }

		public Uri? BaseUrl {
			get => baseUrl ?? DefaultSettings?.BaseUrl;
			set => baseUrl = value;
		}

		public IClientAuthentication? Authentication {
			get => authentication ?? DefaultSettings?.Authentication;
			set => authentication = value;
		}

		public HttpPipelineTransport? Transport {
			get => transport ?? DefaultSettings?.Transport;
			set => transport = value;
		}

		public RetryPolicy? Retry {
			get => retry ?? DefaultSettings?.Retry;
			set => retry = value;
		}
	}
}

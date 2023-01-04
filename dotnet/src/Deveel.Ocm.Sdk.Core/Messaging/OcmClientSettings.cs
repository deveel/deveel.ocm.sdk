using System;

using Azure.Core;
using Azure.Core.Pipeline;

using Microsoft.Extensions.DependencyInjection;

namespace Deveel.Messaging {
	public sealed class OcmClientSettings {
		public Uri? BaseUrl { get; set; }

		public IClientAuthentication? Authentication { get; set; }

		public RetryPolicy? Retry { get; set; }

		public HttpPipelineTransport? Transport { get; set; }

		public IServiceCollection? Services { get; set; } = new ServiceCollection();

		public void AddOAuthScopes(IList<string> scopes) {
			// TODO: instead of throwing an exception, should we set a default flow?
			if (Authentication == null)
				throw new InvalidOperationException("The authentication was not set");

			if (!(Authentication is OAuthFlowAuthentication oauth))
				throw new InvalidOperationException("The authentication type is not an OAuth flow");

			oauth.AddScopes(scopes);
		}
	}
}

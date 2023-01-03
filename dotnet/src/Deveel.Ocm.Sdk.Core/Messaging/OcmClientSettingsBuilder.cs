using System;

using Azure.Core;
using Azure.Core.Pipeline;

using Microsoft.Extensions.DependencyInjection;

namespace Deveel.Messaging {
	public sealed class OcmClientSettingsBuilder {
		internal OcmClientSettingsBuilder() {
			settings = new OcmClientSettings();
		}

		private readonly OcmClientSettings settings;

		public OcmClientSettingsBuilder UseAccessToken() {
			settings.Authentication = new SessionAccessTokenAuthentication();

			return this;
		}

		public OcmClientSettingsBuilder UseAccessToken(string accessToken, DateTimeOffset expiresAtUtc) {
			if (string.IsNullOrWhiteSpace(accessToken))
				throw new ArgumentException($"'{nameof(accessToken)}' cannot be null or whitespace.", nameof(accessToken));
			if (expiresAtUtc <= DateTimeOffset.UtcNow)
				throw new ArgumentException("The expiration of the token is behind now", nameof(expiresAtUtc));

			settings.Authentication = new AccessTokenAuthentication(accessToken, expiresAtUtc);

			return this;
		}

		public OcmClientSettingsBuilder UseApiKey(string apiKey) {
			if (string.IsNullOrWhiteSpace(apiKey))
				throw new ArgumentException($"'{nameof(apiKey)}' cannot be null or whitespace.", nameof(apiKey));

			settings.Authentication = new ApiKeyAuthentication(apiKey);

			return this;
		}

		public OcmClientSettingsBuilder UseClientCredentials(string clientId, string clientSecret, params string[] scopes) {
			if (string.IsNullOrWhiteSpace(clientId))
				throw new ArgumentException($"'{nameof(clientId)}' cannot be null or whitespace.", nameof(clientId));
			if (string.IsNullOrWhiteSpace(clientSecret))
				throw new ArgumentException($"'{nameof(clientSecret)}' cannot be null or whitespace.", nameof(clientSecret));

			var auth = new ClientCredentialsAuthentication(clientId, clientSecret);
			if (scopes != null)
				auth.AddScopes(scopes);

			settings.Authentication = auth;

			return this;
		}

		public OcmClientSettingsBuilder UseBaseUrl(string url) {
			if (string.IsNullOrWhiteSpace(url)) 
				throw new ArgumentException($"'{nameof(url)}' cannot be null or whitespace.", nameof(url));

			if (!Uri.TryCreate(url, UriKind.Absolute, out var rserviceUrl))
				throw new ArgumentException($"The provided URL '{url}' is not valid");

			settings.BaseUrl = rserviceUrl;

			return this;
		}

		internal OcmClientSettings Build() {
			return settings;
		}
	}
}

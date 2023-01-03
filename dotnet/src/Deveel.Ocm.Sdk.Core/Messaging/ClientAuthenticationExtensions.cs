using System;
using System.Diagnostics.CodeAnalysis;

using Azure;
using Azure.Core;

using Deveel.Security;

using Microsoft.Extensions.DependencyInjection;

namespace Deveel.Messaging {
	public static class ClientAuthenticationExtensions {
		public static bool TryAsAzureKeyCredential(this IClientAuthentication? authentication, [MaybeNullWhen(false)] out AzureKeyCredential? credential) {
			if (authentication == null) {
				credential = null;
				return false;
			}

			if (authentication is ApiKeyAuthentication apiKey) {
				credential = new AzureKeyCredential(apiKey.ApiKey);
				return true;
			}

			credential = null;
			return false;
		}

		public static bool TryAsTokenCredential(this IClientAuthentication? authentication, IServiceProvider services, [MaybeNullWhen(false)]out TokenCredential? credential) {
			if (authentication == null) {
				credential = null;
				return false;
			}

			if (authentication is ClientCredentialsAuthentication clientCredentials) {
				var clientFactory = services.GetRequiredService<IHttpClientFactory>();
				credential = new OcmClientCredentials(clientFactory, clientCredentials.ClientId, clientCredentials.ClientSecret, clientCredentials.Scopes);
				return true;
			} else if (authentication is SessionAccessTokenAuthentication) {
				var reader = services.GetRequiredService<IAccessTokenReader>();
				credential = new OcmAccessTokenCredentials(reader);
				return true;
			} else if (authentication is AccessTokenAuthentication accessToken) {
				var reader = new StaticAccessTokenReader(new AccessToken(accessToken.AccessToken, accessToken.ExpiresAt));
				credential = new OcmAccessTokenCredentials(reader);
				return true;
			}

			credential = null;
			return false;
		}
	}
}

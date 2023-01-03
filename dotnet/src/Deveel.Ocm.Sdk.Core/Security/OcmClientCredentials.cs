using System;

using Azure.Core;

using IdentityModel.Client;

namespace Deveel.Security {
	class OcmClientCredentials : TokenCredential {
		private readonly IHttpClientFactory clientFactory;
		private readonly string clientId;
		private readonly string clientSecret;
		private readonly IList<string> scopes;

		public OcmClientCredentials(IHttpClientFactory clientFactory, string clientId, string clientSecret, IList<string> scopes) {
			this.clientFactory = clientFactory;
			this.clientId = clientId;
			this.clientSecret = clientSecret;
			this.scopes = scopes;
		}

		public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) {
			return GetTokenAsync(requestContext, cancellationToken)
				.ConfigureAwait(false).GetAwaiter().GetResult();
		}

		public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) {
			var client = clientFactory.CreateClient();
			var result = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest {
				// TODO: configure this
				Address = "https://deveel.eu.auth0.com/token",
				Method = HttpMethod.Post,
				ClientCredentialStyle = ClientCredentialStyle.PostBody,
				ClientId = clientId,
				ClientSecret = clientSecret,
				Scope = GetScope(requestContext.Scopes),
				// TODO: configure this
				Resource = new[] { "api.ocm.deveel.com" }
			}, cancellationToken);

			// TODO: throw a specific exception
			if (result.IsError) {
				if (result.ErrorType == ResponseErrorType.Exception)
					throw result.Exception;

				if (result.ErrorType == ResponseErrorType.Http)
					throw new InvalidOperationException($"Error obtaining the access token: {result.Error} -> {result.ErrorDescription}");

				throw new InvalidOperationException("Error obtaining the access token");
			}

			return new AccessToken(result.AccessToken, DateTimeOffset.FromUnixTimeSeconds(result.ExpiresIn));
		}

		private string GetScope(string[] scopesInContext) {
			var finalList = new List<string>();
			foreach (var scope in scopes) {
				if (!finalList.Contains(scope))
					finalList.Add(scope);
			}

			if (scopesInContext != null) {
				foreach (var scope in scopesInContext) {
					if (!finalList.Contains(scope))
						finalList.Add(scope);
				}
			}

			return String.Join(" ", finalList);
		}
	}
}

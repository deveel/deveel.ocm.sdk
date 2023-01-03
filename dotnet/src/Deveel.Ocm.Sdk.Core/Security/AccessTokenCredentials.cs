using System;

using Azure.Core;

namespace Deveel.Security {
	internal class OcmAccessTokenCredentials : TokenCredential {
		private readonly IAccessTokenReader accessTokenReader;

		public OcmAccessTokenCredentials(IAccessTokenReader accessTokenReader) {
			this.accessTokenReader = accessTokenReader;
		}

		public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) {
			return GetTokenAsync(requestContext, cancellationToken)
				.ConfigureAwait(false).GetAwaiter().GetResult();
		}

		public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) {
			return await accessTokenReader.ReadAccessToken(cancellationToken);
		}
	}
}

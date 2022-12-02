using System;

using Azure.Core;

namespace Deveel.Messaging {
	public sealed class OcmConsoleCredemtials : TokenCredential {
		public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) {
			return GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
		}

		public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) {
			// TODO: load the token from a safe filte ...
			throw new NotImplementedException();
		}
	}
}

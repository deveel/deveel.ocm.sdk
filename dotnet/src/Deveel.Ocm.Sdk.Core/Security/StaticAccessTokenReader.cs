using System;

using Azure.Core;

namespace Deveel.Security {
	class StaticAccessTokenReader : IAccessTokenReader {
		private readonly AccessToken accessToken;

		public StaticAccessTokenReader(AccessToken accessToken) {
			this.accessToken = accessToken;
		}

		public ValueTask<AccessToken> ReadAccessToken(CancellationToken cancellationToken = default) {
			return ValueTask.FromResult(accessToken);
		}
	}
}

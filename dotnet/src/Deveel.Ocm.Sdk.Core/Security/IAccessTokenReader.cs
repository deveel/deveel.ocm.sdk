using System;

using Azure.Core;

namespace Deveel.Security {
	public interface IAccessTokenReader {
		ValueTask<AccessToken> ReadAccessToken(CancellationToken cancellationToken = default);
	}
}

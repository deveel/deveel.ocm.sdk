using System;

namespace Deveel.Messaging {
	public sealed class AccessTokenAuthentication : IClientAuthentication {
		public AccessTokenAuthentication(string accessToken, DateTimeOffset expiresAt) {
			if (string.IsNullOrWhiteSpace(accessToken))
				throw new ArgumentException($"'{nameof(accessToken)}' cannot be null or whitespace.", nameof(accessToken));

			AccessToken = accessToken;
			ExpiresAt = expiresAt;
		}

		public string AccessToken { get; }

		public DateTimeOffset ExpiresAt { get; }
	}
}

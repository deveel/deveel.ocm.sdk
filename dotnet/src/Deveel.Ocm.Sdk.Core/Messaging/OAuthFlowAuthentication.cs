using System;

namespace Deveel.Messaging {
	public abstract class OAuthFlowAuthentication : IClientAuthentication {
		protected OAuthFlowAuthentication(string clientId, string clientSecret) {
			if (string.IsNullOrWhiteSpace(clientId))
				throw new ArgumentException($"'{nameof(clientId)}' cannot be null or whitespace.", nameof(clientId));
			if (string.IsNullOrWhiteSpace(clientSecret))
				throw new ArgumentException($"'{nameof(clientSecret)}' cannot be null or whitespace.", nameof(clientSecret));

			ClientId = clientId;
			ClientSecret = clientSecret;
		}

		public string ClientId { get; }

		public string ClientSecret { get; }

		public IList<string>? Scopes { get; set; }

		public void AddScopes(IList<string> scopes) {
			if (Scopes == null)
				Scopes = new List<string>();

			foreach (var scope in scopes) {
				if (!Scopes.Contains(scope))
					Scopes.Add(scope);
			}
		}
	}
}

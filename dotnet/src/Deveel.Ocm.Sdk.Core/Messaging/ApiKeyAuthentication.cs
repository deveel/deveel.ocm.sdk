using System;

namespace Deveel.Messaging {
	public sealed class ApiKeyAuthentication : IClientAuthentication {
		public ApiKeyAuthentication(string apiKey) {
			if (string.IsNullOrWhiteSpace(apiKey)) 
				throw new ArgumentException($"'{nameof(apiKey)}' cannot be null or whitespace.", nameof(apiKey));

			ApiKey = apiKey;
		}

		public string ApiKey { get; }
	}
}

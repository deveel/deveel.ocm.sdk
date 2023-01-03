using System;

namespace Deveel.Messaging {
	public sealed class AuthorizationCodeAuthentication : OAuthFlowAuthentication {
		public AuthorizationCodeAuthentication(string clientId, string clientSecret) 
			: base(clientId, clientSecret) {
		}
	}
}

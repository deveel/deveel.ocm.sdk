using System;

namespace Deveel.Messaging {
	public sealed class ClientCredentialsAuthentication : OAuthFlowAuthentication {
		public ClientCredentialsAuthentication(string clientId, string clientSecret) 
			: base(clientId, clientSecret) {
		}
	}
}

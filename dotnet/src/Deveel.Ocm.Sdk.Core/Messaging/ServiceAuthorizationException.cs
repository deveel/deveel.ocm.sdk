using System;

namespace Deveel.Messaging {
	public sealed class ServiceAuthorizationException : OcmServiceException {
		internal ServiceAuthorizationException(string message, Exception? innerException) 
			: base(message, innerException) {
		}
	}
}

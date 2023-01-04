using System;

using Azure;

namespace Deveel.Messaging {
	public sealed class ServiceAuthenticationException : OcmServiceException {
		internal ServiceAuthenticationException(string message, Exception? innerException) 
			: base(message, innerException) {
		}
	}
}

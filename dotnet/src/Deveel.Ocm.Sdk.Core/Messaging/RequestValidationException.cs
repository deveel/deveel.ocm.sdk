using System;

namespace Deveel.Messaging {
	public class RequestValidationException : OcmServiceException {
		internal RequestValidationException(string message, Exception? innerException)
			: base(message, innerException) {

		}
	}
}

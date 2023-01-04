using System;

namespace Deveel.Messaging {
	public class OcmClientException : Exception {
		public OcmClientException() {
		}

		public OcmClientException(string? message) : base(message) {
		}

		public OcmClientException(string? message, Exception? innerException) : base(message, innerException) {
		}
	}
}

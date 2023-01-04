using System;
using System.Runtime.Serialization;

namespace Deveel.Messaging {
	public class MessagingClientException : OcmClientException {
		public MessagingClientException() {
		}

		public MessagingClientException(string? message) : base(message) {
		}

		public MessagingClientException(string? message, Exception? innerException) : base(message, innerException) {
		}
	}
}

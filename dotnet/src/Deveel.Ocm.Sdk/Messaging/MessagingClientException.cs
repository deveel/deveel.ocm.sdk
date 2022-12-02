using System;
using System.Runtime.Serialization;

namespace Deveel.Messaging {
	public class MessagingClientException : Exception {
		public MessagingClientException() {
		}

		public MessagingClientException(string? message) : base(message) {
		}

		public MessagingClientException(string? message, Exception? innerException) : base(message, innerException) {
		}
	}
}

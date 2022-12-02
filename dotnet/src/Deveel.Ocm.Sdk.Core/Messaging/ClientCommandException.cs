using System;
using System.Runtime.Serialization;

namespace Deveel.Messaging {
	public class ClientCommandException : Exception {
		public ClientCommandException() {
		}

		public ClientCommandException(string? message) : base(message) {
		}

		public ClientCommandException(string? message, Exception? innerException) : base(message, innerException) {
		}
	}
}

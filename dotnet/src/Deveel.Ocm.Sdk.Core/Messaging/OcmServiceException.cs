using System;

using Azure;

namespace Deveel.Messaging {
	public class OcmServiceException : Exception {
		public OcmServiceException() {
		}

		public OcmServiceException(string? message) : base(message) {
		}

		public OcmServiceException(string? message, Exception? innerException) : base(message, innerException) {
			if (innerException is RequestFailedException reqFailed) {
				ErrorCode = reqFailed.ErrorCode;
				HttpStatus = reqFailed.Status;
				// TODO: use .Data for accessing the additional properties of the ProblemDetails?
			}
		}

		public string? ErrorCode { get; }

		public int? HttpStatus { get; }
	}
}

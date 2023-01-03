using System;

using Deveel.Messaging.Models;

namespace Deveel.Messaging {
	public sealed class MessageResult {
		private readonly string messageId;
		private readonly IReadOnlyDictionary<string, object>? context;
		private readonly MessageResult? fallback;

		internal MessageResult(Models.MessageResult result) {
			this.messageId = result.MessageId;
			this.context = result.Context;
			fallback = result.Fallback != null ? new MessageResult(result.Fallback) : null;
			IsRoot = true;
		}

		private MessageResult(Models.FallbackMessageResult result) {
			this.messageId = result.MessageId;
			this.fallback = result.Fallback != null ? new MessageResult(result.Fallback) : null;
		}

		public string MessageId => messageId;

		public MessageResult? Fallback => fallback;

		public IReadOnlyDictionary<string, object>? Context => context;

		public bool IsRoot { get; }
	}
}

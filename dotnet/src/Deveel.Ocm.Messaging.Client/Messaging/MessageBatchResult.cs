using System;

namespace Deveel.Messaging {
	public sealed class MessageBatchResult {
		private readonly Models.MessageBatchResult result;

		public MessageBatchResult(Models.MessageBatchResult result) {
			this.result = result;
		}

		public string BatchId => result.BatchId;

		public IReadOnlyList<MessageResult> Messages => result.Messages.Select(x => new MessageResult(x)).ToList();

		public IReadOnlyDictionary<string, object> Context => result.Context;
	}
}

using System;

namespace Deveel.Messaging.Commands {
	public sealed class SendBatchCommand : IClientCommand<MessageBatchResult> {
		public SendBatchCommand(MessageBatch batch) {
			Batch = batch ?? throw new ArgumentNullException(nameof(batch));
		}

		public MessageBatch Batch { get; }
	}
}

using System;

namespace Deveel.Messaging.Commands {
	class SendBatchCommandHandler : IClientCommandHandler<SendBatchCommand, MessageBatchResult> {
		private readonly MessageClient client;

		public SendBatchCommandHandler(MessageClient client) {
			this.client = client;
		}

		public async Task<MessageBatchResult> HandleAsync(SendBatchCommand request, CancellationToken cancellationToken) {
			var result = await client.BatchSendAsync(request.Batch.AsClientBatch(), cancellationToken);

			return new MessageBatchResult(result);
		}
	}
}

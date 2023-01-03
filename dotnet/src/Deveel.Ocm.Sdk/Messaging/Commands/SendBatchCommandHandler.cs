using System;

using MediatR;

namespace Deveel.Messaging.Commands {
	class SendBatchCommandHandler : IRequestHandler<SendBatchCommand, MessageBatchResult> {
		private readonly MessageClient client;

		public SendBatchCommandHandler(MessageClient client) {
			this.client = client;
		}

		public async Task<MessageBatchResult> Handle(SendBatchCommand request, CancellationToken cancellationToken) {
			var result = await client.BatchSendAsync(request.Batch.AsClientBatch(), cancellationToken);

			return new MessageBatchResult(result);
		}
	}
}

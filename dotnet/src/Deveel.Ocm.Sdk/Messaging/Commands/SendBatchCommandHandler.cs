using System;

using MediatR;

namespace Deveel.Messaging.Commands {
	class SendBatchCommandHandler : IRequestHandler<SendBatchCommand, MessageBatchResult> {
		private readonly MessageClient client;

		public SendBatchCommandHandler(MessageClient client) {
			this.client = client;
		}

		public Task<MessageBatchResult> Handle(SendBatchCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
	}
}

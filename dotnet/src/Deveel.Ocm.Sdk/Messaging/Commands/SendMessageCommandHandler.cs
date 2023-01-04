using System;

namespace Deveel.Messaging.Commands {
	public sealed class SendMessageCommandHandler : IClientCommandHandler<SendMessageCommand, MessageResult> {
		private readonly MessageClient client;

		public SendMessageCommandHandler(MessageClient client) {
			this.client = client;
		}

		// TODO: RequestFailedException should be handled by the PipelineBehavior
		public async Task<MessageResult> HandleAsync(SendMessageCommand request, CancellationToken cancellationToken) {
			var result = await client.SendAsync(request.Message.AsClientMessage(), cancellationToken);

			return new MessageResult(result.Value);
		}
	}
}

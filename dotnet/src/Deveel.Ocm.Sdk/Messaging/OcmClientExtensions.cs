using System;

using Deveel.Messaging.Commands;

namespace Deveel.Messaging {
	public static class OcmClientExtensions {
		public static Task<MessageResult> SendMessageAsync(this IOcmClient client, Message message, CancellationToken cancellationToken = default) 
			=> client.ExecuteAsync<SendMessageCommand, MessageResult>(new SendMessageCommand(message), cancellationToken);

		public static Task<MessageResult> SendMessageAsync(this IOcmClient client, Action<MessageBuilder> message, CancellationToken cancellationToken = default) {
			var builder = new MessageBuilder();
			message(builder);

			return client.SendMessageAsync(builder.Build(), cancellationToken);
		}

		public static Task<MessageBatchResult> SendBatchAsync(this IOcmClient client, MessageBatch batch, CancellationToken cancellationToken = default)
			=> client.ExecuteAsync<SendBatchCommand, MessageBatchResult>(new SendBatchCommand(batch), cancellationToken);
	}
}

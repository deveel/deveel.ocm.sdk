using System;

namespace Deveel.Messaging.Commands {
	public sealed class SendMessageCommand : IClientCommand<MessageResult> {
		public SendMessageCommand(Message message) {
			Message = message ?? throw new ArgumentNullException(nameof(message));
		}

		public Message Message { get; }
	}
}

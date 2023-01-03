using System;

namespace Deveel.Messaging {
	public sealed class FallbackMessage : MessageBase {
		public FallbackMessage(string channelName, MessageTerminal sender, MessageTerminal receiver, MessageContentBase content) 
			: base(channelName, sender, receiver, content) {
		}

		public FallbackMessage(string channelName, MessageTerminal receiver, MessageContentBase content)
			: base(channelName, null, receiver, content) {
		}

		internal Models.FallbackMessage AsClientMessage() {
			var message = new Models.FallbackMessage(AsClientTerminal(Receiver), Content.AsClientContent(), ChannelName) {
				Sender = AsClientSenderTerminal(Sender),
				Options = Options,
			};

			if (Extensions != null) {
				// TODO: set the AdditionalProperties
			}

			if (Fallback != null)
				message.Fallback = Fallback.AsClientMessage();

			return message;

		}
	}
}

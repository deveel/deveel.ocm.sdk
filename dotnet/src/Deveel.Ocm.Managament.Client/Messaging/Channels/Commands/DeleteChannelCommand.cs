using System;

using Deveel.Messaging.Commands;

namespace Deveel.Messaging.Channels.Commands {
	class DeleteChannelCommand : IClientCommand {
		public DeleteChannelCommand(string channelId) {
			if (string.IsNullOrWhiteSpace(channelId)) 
				throw new ArgumentException($"'{nameof(channelId)}' cannot be null or whitespace.", nameof(channelId));

			ChannelId = channelId;
		}

		public string ChannelId { get; set; }
	}
}

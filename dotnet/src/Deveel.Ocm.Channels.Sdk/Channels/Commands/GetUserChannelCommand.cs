using System;

using Deveel.Messaging.Commands;

namespace Deveel.Messaging.Channels.Commands {
	public sealed class GetUserChannelCommand : IClientCommand<UserChannel?> {
		public GetUserChannelCommand(string channelId) {
			if (string.IsNullOrWhiteSpace(channelId)) 
				throw new ArgumentException($"'{nameof(channelId)}' cannot be null or whitespace.", nameof(channelId));

			ChannelId = channelId;
		}

		public GetUserChannelCommand(ChannelName channelName) {
			ChannelName = channelName;
		}

		public string? ChannelId { get; }

		public ChannelName? ChannelName { get; }
	}
}

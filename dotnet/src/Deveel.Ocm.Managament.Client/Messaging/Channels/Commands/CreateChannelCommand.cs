using System;

using Deveel.Messaging.Commands;

namespace Deveel.Messaging.Channels.Commands {
	internal class CreateChannelCommand : IClientCommand<UserChannel> {
		public CreateChannelCommand(UserChannel channel) {
			Channel = channel;
		}

		public UserChannel Channel { get; }
	}
}

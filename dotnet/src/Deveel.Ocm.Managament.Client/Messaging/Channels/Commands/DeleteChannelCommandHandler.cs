using System;

using Deveel.Messaging.Channels.Management;
using Deveel.Messaging.Commands;

namespace Deveel.Messaging.Channels.Commands {
	class DeleteChannelCommandHandler : IClientCommandHandler<DeleteChannelCommand> {
		private readonly ChannelClient client;

		public DeleteChannelCommandHandler(ChannelClient client) {
			this.client = client;
		}

		public async Task HandleAsync(DeleteChannelCommand command, CancellationToken cancellationToken = default) {
			await client.DeleteChannelAsync(command.ChannelId, cancellationToken);
		}
	}
}

using Deveel.Messaging.Channels.Management;
using Deveel.Messaging.Commands;

namespace Deveel.Messaging.Channels.Commands {
	internal class CreateChannelCommandHandler : IClientCommandHandler<CreateChannelCommand, UserChannel> {
		private readonly ChannelClient client;

		public CreateChannelCommandHandler(ChannelClient client) {
			this.client = client;
		}

		public async Task<UserChannel> HandleAsync(CreateChannelCommand command, CancellationToken cancellationToken = default) {
			var result = await client.CreateChannelAsync(command.Channel.ToNewChannel(), cancellationToken);

			return UserChannel.FromClient(result);
		}
	}
}

using System;

using Deveel.Messaging.Channels.Management;

using MediatR;

namespace Deveel.Messaging.Channels.Commands {
	class GetUserChannelCommandHandler : IRequestHandler<GetUserChannelCommand, UserChannel?> {
		private readonly ChannelClient client;

		public GetUserChannelCommandHandler(ChannelClient client) {
			this.client = client;
		}

		public async Task<UserChannel?> Handle(GetUserChannelCommand request, CancellationToken cancellationToken) {
			Deveel.Messaging.Channels.Management.Models.UserChannel? result = null;

			if (request.ChannelName != null) {
				result = await client.GetChannelByNameAsync(request.ChannelName, cancellationToken);
			} else if (!String.IsNullOrWhiteSpace(request.ChannelId)) { 
				result = await client.GetChannelAsync(request.ChannelId, cancellationToken);
			} else {
				throw new InvalidOperationException("Invalid type of command");
			}

			if (result == null)
				return null;

			return UserChannel.FromClient(result);
		}
	}
}

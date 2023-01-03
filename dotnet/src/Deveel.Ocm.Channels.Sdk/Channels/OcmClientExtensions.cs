using System;

using Deveel.Messaging.Channels.Commands;

namespace Deveel.Messaging.Channels {
	public static class OcmClientExtensions {
		public static Task<UserChannel?> FindChannelByIdAsync(this IOcmClient client, string channelId, CancellationToken cancellationToken = default)
			=> client.ExecuteAsync<GetUserChannelCommand, UserChannel?>(new GetUserChannelCommand(channelId), cancellationToken);

		public static Task<UserChannel?> FindChannelByNameAsync(this IOcmClient client, ChannelName channelName, CancellationToken cancellationToken = default)
			=> client.ExecuteAsync<GetUserChannelCommand, UserChannel?>(new GetUserChannelCommand(channelName), cancellationToken);

		public static Task<IReadOnlyList<ChannelSchema>> ListChannelSchemaAsync(this IOcmClient client, string? provider = null, CancellationToken cancellationToken = default)
			=> client.ExecuteAsync<ListChannelSchemaCommand, IReadOnlyList<ChannelSchema>>(new ListChannelSchemaCommand(provider), cancellationToken);
	}
}

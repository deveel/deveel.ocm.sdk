using Deveel.Messaging.Channels.Management.Models;

namespace Deveel.Messaging.Channels {
	public sealed class UserChannel {
		public UserChannel(ChannelName name, ChannelType type, ChannelProvider provider) {
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));

			// TODO: validate the name for a fast-fail on the client-side

			Name = name;
			Type = type;
			Provider = provider;
		}

		public ChannelName Name { get; }

		public ChannelType Type { get; }

		public ChannelProvider Provider { get; }

		public ChannelDirections? Directions { get; set; }

		public IList<MessageContentType>? ContentTypes { get; set; }

		public IDictionary<string, object>? Context { get; set; }

		public IDictionary<string, object>? Settings { get; set; }

		public string? Id { get; private set; }

		internal static UserChannel FromClient(Management.Models.UserChannel channel) {
			return new UserChannel(channel.Name, channel.Type.AsChannelType(), channel.Provider) {
				Id = channel.Id,
				ContentTypes = channel.ContentTypes?.Select(x => x.AsMessageContentType()).ToArray(),
				Context = channel.Context?.ToDictionary(x => x.Key, y => y.Value),
				Settings = channel.Settings?.ToDictionary(x => x.Key, y => y.Value),
				Directions = channel.Directions?.AsChannelDirections()
			};
		}

		internal static Management.Models.NewUserChannel ToNewChannel(UserChannel channel) {
			return new NewUserChannel(channel.Name, channel.Type.AsClientChannelType(), AsClientChannelProvider(channel.Provider), channel.Directions.AsClientDirections()) {
				Context = channel.Context,
				Settings = channel.Settings,
				ContentTypes = channel.ContentTypes?.Select(x => x.AsClientMessageContentType()).ToArray(),
			};
		}

		private static Management.Models.ChannelProvider AsClientChannelProvider(ChannelProvider provider) {
			// TODO: the remote list of providers might be more scalable than a finite enumeration...
			return new Management.Models.ChannelProvider(provider);
		}
	}
}

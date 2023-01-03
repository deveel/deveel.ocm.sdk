using System;

namespace Deveel.Messaging.Channels {
	public sealed class UserChannel {
		public UserChannel(string name, ChannelType type, ChannelProvider provider) {
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));

			// TODO: validate the name for a fast-fail on the client-side

			Name = name;
			Type = type;
			Provider = provider;
		}

		public string Name { get; }

		public ChannelType Type { get; }

		public ChannelProvider Provider { get; }
	}
}

using System;

using Deveel.Messaging.Commands;

namespace Deveel.Messaging.Channels.Commands {
	public sealed class ListChannelSchemaCommand : IClientCommand<IReadOnlyList<ChannelSchema>> {
		public ListChannelSchemaCommand(string? provider = null) {
			Provider = provider;
		}

		public string? Provider { get; set; }
	}
}

using System;

using Deveel.Messaging.Channels.Management;
using Deveel.Messaging.Commands;

namespace Deveel.Messaging.Channels.Commands {
	class ListChannelSchemaCommandHandler : IClientCommandHandler<ListChannelSchemaCommand, IReadOnlyList<ChannelSchema>> {
		private readonly ChannelClient client;

		public ListChannelSchemaCommandHandler(ChannelClient client) {
			this.client = client;
		}

		public async Task<IReadOnlyList<ChannelSchema>> HandleAsync(ListChannelSchemaCommand request, CancellationToken cancellationToken) {
			var result = await client.GetAllChannelSchemaAsync(request.Provider, cancellationToken);

			return result.Value.Select(x => new ChannelSchema(x)).ToList().AsReadOnly();
		}
	}
}

using System;

using Deveel.Messaging.Channels.Management;

using MediatR;

namespace Deveel.Messaging.Channels.Commands {
	class ListChannelSchemaCommandHandler : IRequestHandler<ListChannelSchemaCommand, IReadOnlyList<ChannelSchema>> {
		private readonly ChannelClient client;

		public ListChannelSchemaCommandHandler(ChannelClient client) {
			this.client = client;
		}

		public async Task<IReadOnlyList<ChannelSchema>> Handle(ListChannelSchemaCommand request, CancellationToken cancellationToken) {
			var result = await client.GetAllChannelSchemaAsync(request.Provider, cancellationToken);

			return result.Value.Select(x => new ChannelSchema(x)).ToList().AsReadOnly();
		}
	}
}

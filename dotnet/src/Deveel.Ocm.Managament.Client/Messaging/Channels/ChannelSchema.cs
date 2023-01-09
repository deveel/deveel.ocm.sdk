using System;

namespace Deveel.Messaging.Channels {
	public sealed class ChannelSchema {
		private Management.Models.ChannelSchema schema;

		internal ChannelSchema(Management.Models.ChannelSchema schema) {
			this.schema = schema;
		}

		public ChannelProvider Provider => new ChannelProvider(schema.Provider.ToString());

		public ChannelType Type => schema.Type.AsChannelType();

		public IReadOnlyList<MessageContentType> ContentTypes => 
			schema.ContentTypes.Select(x => x.AsMessageContentType()).ToList().AsReadOnly();

		public ChannelDirections Directions => schema.Directions.AsChannelDirections();

		public bool SupportsContentType(MessageContentType contentType)
			=> ContentTypes?.Any(x => x == contentType) ?? false;

		public bool SupportsDirection(ChannelDirections directions)
			=> (Directions & directions) != 0;

		public bool SupportsOutbound() => SupportsDirection(ChannelDirections.Outbound);

		public bool SupportsInbound() => SupportsDirection(ChannelDirections.Inbound);

		public IReadOnlyList<string> Settings => schema.Settings;

		public bool SupportsSetting(string key) => Settings?.Contains(key) ?? false;

		public IReadOnlyList<TerminalType> ReceiverTypes => 
			schema.ReceiverTypes.Select(x => x.AsTerminalType()).ToList().AsReadOnly();

		public bool SupportsReceiverType(TerminalType terminalType) => ReceiverTypes?.Any(x =>x == terminalType) ?? false;

		public IReadOnlyList<TerminalType> SenderTypes =>
			schema.SenderTypes.Select(x => x.AsTerminalType()).ToList().AsReadOnly();

		public bool SupportsSenderType(TerminalType terminalType) => SenderTypes?.Any(x =>x == terminalType) ?? false;
	}
}

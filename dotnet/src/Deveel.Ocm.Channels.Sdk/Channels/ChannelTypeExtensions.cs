using System;

namespace Deveel.Messaging.Channels {
	static class ChannelTypeExtensions {
		public static Management.Models.ChannelType AsClientChannelType(this ChannelType channelType)
			=> channelType switch {
				ChannelType.Email => Management.Models.ChannelType.Email,
				ChannelType.WhatsApp => Management.Models.ChannelType.Whatsapp,
				ChannelType.Sms => Management.Models.ChannelType.Sms,
				ChannelType.Telegram => Management.Models.ChannelType.Telegram,
				ChannelType.Facebook => Management.Models.ChannelType.Messenger,
				ChannelType.Push => Management.Models.ChannelType.Push,
				_ => throw new NotSupportedException($"Channel type '{channelType}' not supported by the client")
			};

		public static ChannelType AsChannelType(this Management.Models.ChannelType channelType)
			=> channelType.ToString() switch {
				var x when x == Management.Models.ChannelType.Sms => ChannelType.Sms,
				var x when x == Management.Models.ChannelType.Email => ChannelType.Email,
				var x when x == Management.Models.ChannelType.Whatsapp => ChannelType.WhatsApp,
				var x when x == Management.Models.ChannelType.Messenger => ChannelType.Facebook,
				var x when x == Management.Models.ChannelType.Telegram => ChannelType.Telegram,
				var x when x == Management.Models.ChannelType.Push => ChannelType.Push,
				_ => throw new NotSupportedException($"The channel type '{channelType}' is not supported")
			};
	}
}

using System;

namespace Deveel.Messaging.Channels {
	[Flags]
	public enum ChannelDirections {
		Inbound = 1,
		Outbound = 2,
		Duplex = Inbound | Outbound
	}
}

using System;

namespace Deveel.Messaging.Channels {
	internal static class ChannelDirectionsExtensions {
		public static Management.Models.ChannelDirections AsClientDirections(this ChannelDirections? directions) {
			return directions switch {
				ChannelDirections.Inbound => Management.Models.ChannelDirections.In,
				ChannelDirections.Outbound => Management.Models.ChannelDirections.Out,
				ChannelDirections.Duplex => Management.Models.ChannelDirections.Duplex,
				null => Management.Models.ChannelDirections.Default,
				_ => throw new NotSupportedException()
			};
		}

		public static ChannelDirections AsChannelDirections(this Management.Models.ChannelDirections directions) {
			if (directions == Management.Models.ChannelDirections.In)
				return ChannelDirections.Inbound;
			if (directions == Management.Models.ChannelDirections.Out)
				return ChannelDirections.Outbound;
			if (directions == Management.Models.ChannelDirections.Duplex)
				return ChannelDirections.Duplex;

			throw new NotSupportedException($"The direction '{directions}' is not supported");
		}

	}
}

using System;

using Deveel.Messaging.Models;

namespace Deveel.Messaging {
	public abstract class MessageContentBase {
		internal abstract MessageContentType ContentType { get; }

		internal abstract MessageContent AsClientContent();
	}
}

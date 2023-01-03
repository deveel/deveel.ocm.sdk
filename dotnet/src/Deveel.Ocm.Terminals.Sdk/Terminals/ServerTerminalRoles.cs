using System;

namespace Deveel.Messaging.Terminals {
	[Flags]
	public enum ServerTerminalRoles {
		Sender = 1,
		Receiver = 2,
		Both = Sender | Receiver
	}
}

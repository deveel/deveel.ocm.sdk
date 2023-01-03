using System;

namespace Deveel.Messaging {
	public interface IOcmClient {
		IServiceProvider Services { get; }

		OcmClientSettings Settings { get; }
	}
}

using System;

using Azure.Core;

namespace Deveel.Messaging {
	public sealed class RetryPolicy {
		public int? MaxRetried { get; set; }

		public TimeSpan? Delay { get; set; }

		public TimeSpan? MaxDelay { get; set; }

		public TimeSpan? NetworkTimeout { get; set; }

		public RetryMode? Mode { get; set; }

		public void SetOptions(RetryOptions options) {
			if (Mode != null)
				options.Mode = Mode.Value;
			if (MaxRetried != null)
				options.MaxRetries = MaxRetried.Value;
			if (Delay != null)
				options.Delay = Delay.Value;
			if (MaxDelay != null)
				options.MaxDelay = MaxDelay.Value;
			if (NetworkTimeout != null)
				options.NetworkTimeout= NetworkTimeout.Value;
		}
	}
}

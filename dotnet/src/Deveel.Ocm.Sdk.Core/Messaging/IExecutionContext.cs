using System;

namespace Deveel.Messaging {
	public interface IExecutionContext {
		IServiceProvider Services { get; }
	}
}

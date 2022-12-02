using System;
using System.CommandLine.Invocation;

namespace Deveel.Messaging {
	public interface ICommandExecutionContext : IExecutionContext {
		InvocationContext InvocationContext { get; }
	}
}

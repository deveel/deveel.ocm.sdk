using System;
using System.CommandLine.Invocation;

namespace Deveel.Messaging {
	public abstract class DefaultCommandHandler : ICommandHandler {
		protected virtual int ExitCode { get; set; } = 0;

		protected virtual void Execute(InvocationContext context) {
			ExecuteAsync(context).ConfigureAwait(false).GetAwaiter().GetResult();
		}

		protected virtual Task ExecuteAsync(InvocationContext context, CancellationToken cancellationToken = default) {
			return Task.CompletedTask;
		}

		int ICommandHandler.Invoke(InvocationContext context) {
			Execute(context);
			return ExitCode;
		}

		async Task<int> ICommandHandler.InvokeAsync(InvocationContext context) {
			await ExecuteAsync(context, context.GetCancellationToken());
			return ExitCode;
		}
	}
}

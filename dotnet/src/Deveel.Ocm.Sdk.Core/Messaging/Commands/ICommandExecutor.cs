using System;

namespace Deveel.Messaging.Commands {
	public interface ICommandExecutor {
		Task<TResult> ExecuteAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken)
			where TCommand : IClientCommand<TResult>;
	}
}

using System;

namespace Deveel.Messaging.Commands {
	public interface IClientCommandHandler<TCommand, TResponse>
		where TCommand : class, IClientCommand<TResponse> {
		Task<TResponse> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
	}
}

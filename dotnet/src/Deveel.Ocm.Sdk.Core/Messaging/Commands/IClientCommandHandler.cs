using System;

namespace Deveel.Messaging.Commands {
	public interface IClientCommandHandler<TCommand>
		where TCommand : class, IClientCommand {
		Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
	}
}

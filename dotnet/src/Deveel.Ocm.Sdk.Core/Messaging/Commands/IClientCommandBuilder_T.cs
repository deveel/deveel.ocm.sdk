using System;

namespace Deveel.Messaging.Commands {
	public interface IClientCommandBuilder<TCommand, TResult>
		where TCommand : class, IClientCommand<TResult> {
		TCommand Build();
	}
}

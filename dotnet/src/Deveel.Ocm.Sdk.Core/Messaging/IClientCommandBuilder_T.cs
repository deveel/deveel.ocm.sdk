using System;

namespace Deveel.Messaging {
	public interface IClientCommandBuilder<TCommand, TResult> 
		where TCommand : class, IClientCommand<TResult> {
		TCommand Build();
	}
}

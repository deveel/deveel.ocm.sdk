using System;

using MediatR;

namespace Deveel.Messaging {
	public interface IClientCommandBuilder<TCommand> : IClientCommandBuilder<TCommand, Unit>
		where TCommand : class, IClientCommand {
	}
}

using System;

using MediatR;

namespace Deveel.Messaging.Commands {
	public interface IClientCommandBuilder<TCommand> : IClientCommandBuilder<TCommand, Unit>
		where TCommand : class, IClientCommand {
	}
}

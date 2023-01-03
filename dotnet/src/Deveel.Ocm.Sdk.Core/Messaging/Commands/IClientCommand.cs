using System;

using MediatR;

namespace Deveel.Messaging.Commands {
	public interface IClientCommand : IClientCommand<Unit>, IRequest {
	}
}

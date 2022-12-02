using System;

using MediatR;

namespace Deveel.Messaging {
	public interface IClientCommand : IClientCommand<Unit>, IRequest {
	}
}

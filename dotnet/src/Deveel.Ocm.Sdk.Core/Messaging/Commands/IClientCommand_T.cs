using System;

using MediatR;

namespace Deveel.Messaging.Commands {
	public interface IClientCommand<out TResult> : IRequest<TResult> {
	}
}

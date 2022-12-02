using System;

using MediatR;

namespace Deveel.Messaging {
	public interface IClientCommand<out TResult> : IRequest<TResult> {
	}
}

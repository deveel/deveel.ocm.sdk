using System;

using Deveel.Messaging.Commands;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace Deveel.Messaging {
	public static class OcmClientExtensions {
		public static async Task<TResult> ExecuteAsync<TCommand, TResult>(this IOcmClient client, TCommand command, CancellationToken cancellationToken)
			where TCommand : IClientCommand<TResult> {
			var mediator = client.Services.GetRequiredService<IMediator>();
			return await mediator.Send(command, cancellationToken);
		}

		public static async Task ExecuteAsync<TCommand>(this IOcmClient client, TCommand command, CancellationToken cancellationToken)
			where TCommand : IClientCommand {
			var mediator = client.Services.GetRequiredService<IMediator>();
			await mediator.Send(command, cancellationToken);
		}
	}
}

using System;

using Deveel.Messaging.Terminals.Management;

using MediatR;

namespace Deveel.Messaging.Terminals.Commands {
	class CreateTerminalCommandHandler : IRequestHandler<CreateTerminalCommand, ServerTerminal> {
		private readonly TerminalClient client;

		public CreateTerminalCommandHandler(TerminalClient client) {
			this.client = client;
		}

		public Task<ServerTerminal> Handle(CreateTerminalCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
	}
}

using System;

using Deveel.Messaging.Commands;

namespace Deveel.Messaging.Terminals.Commands {
	class DeleteTerminalCommand : IClientCommand {
		public DeleteTerminalCommand(string terminalId) {
			if (string.IsNullOrWhiteSpace(terminalId)) 
				throw new ArgumentException($"'{nameof(terminalId)}' cannot be null or whitespace.", nameof(terminalId));

			TerminalId = terminalId;
		}

		public string TerminalId { get; }
	}
}

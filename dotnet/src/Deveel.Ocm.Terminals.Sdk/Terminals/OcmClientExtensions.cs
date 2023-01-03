using System;

using Deveel.Messaging.Terminals.Commands;

namespace Deveel.Messaging.Terminals {
	public static class OcmClientExtensions {
		public static Task<ServerTerminal> CreateTerminalAsync(this IOcmClient client, ServerTerminal terminal, CancellationToken cancellationToken = default)
			=> client.ExecuteAsync<CreateTerminalCommand, ServerTerminal>(new CreateTerminalCommand(terminal), cancellationToken);

		public static async Task<ServerTerminal> CreateTerminalAsync(this IOcmClient client, Action<ServerTerminalBuilder> configure, CancellationToken cancellationToken = default) {
			var builder = new ServerTerminalBuilder();
			configure(builder);
			return await client.CreateTerminalAsync(builder.Build(), cancellationToken);
		}
	}
}

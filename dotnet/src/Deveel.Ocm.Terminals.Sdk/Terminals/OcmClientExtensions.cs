using System;

using Deveel.Messaging.Terminals.Commands;

namespace Deveel.Messaging.Terminals {
	public static class OcmClientExtensions {
		public static async Task<ServerTerminal> CreateTerminalAsync(this IOcmClient client, ServerTerminal terminal, CancellationToken cancellationToken = default)
			=> await client.ExecuteAsync<CreateTerminalCommand, ServerTerminal>(new CreateTerminalCommand(terminal), cancellationToken);

		public static async Task<ServerTerminal> CreateTerminalAsync(this IOcmClient client, Action<ServerTerminalBuilder> configure, CancellationToken cancellationToken = default) {
			var builder = new ServerTerminalBuilder();
			configure(builder);
			return await client.CreateTerminalAsync(builder.Build(), cancellationToken);
		}

		public static async Task DeleteTerminalAsync(this IOcmClient client, string terminalId, CancellationToken cancellationToken = default)
			=> await client.ExecuteAsync(new DeleteTerminalCommand(terminalId), cancellationToken);

		public static async Task<ServerTerminal?> GetTerminalAsync(this IOcmClient client, string terminalId, CancellationToken cancellationToken = default)
			=> await client.ExecuteAsync<GetTerminalCommand, ServerTerminal?>(new GetTerminalCommand(terminalId), cancellationToken);

		public static async Task<PagedResult<ServerTerminal>> GetTerminalsPageAsync(this IOcmClient client, int page = 1, int size = 10, string? type = null, IList<string>? sort = null, CancellationToken cancellationToken = default)
			=> await client.ExecuteAsync<GetTerminalsPageCommand, PagedResult<ServerTerminal>>(new GetTerminalsPageCommand(new PageRef(page, size), type, sort), cancellationToken);

		public static IAsyncEnumerable<PagedResult<ServerTerminal>> GetTerminalPages(this IOcmClient client, string? type = null) {
			return new PageEnumerable<ServerTerminal>(async number => await client.GetTerminalsPageAsync(number, 10, type));
		}

		public static async Task ChangeTerminalRoleAsync(this IOcmClient client, string terminalId, ServerTerminalRoles newRole, CancellationToken cancellationToken = default)
			=> await client.ExecuteAsync(new ChangeTerminalRoleCommand(terminalId, newRole), cancellationToken);

		public static async Task<IReadOnlyList<TerminalProvider>> ListTerminalProvidersAsync(this IOcmClient client, string? type = null, CancellationToken cancellationToken = default)
			=> await client.ExecuteAsync<ListProvidersCommand, IReadOnlyList<TerminalProvider>>(new ListProvidersCommand(type), cancellationToken);
	}
}

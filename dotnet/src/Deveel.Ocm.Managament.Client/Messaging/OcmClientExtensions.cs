using System;

using Deveel.Messaging.Channels;
using Deveel.Messaging.Channels.Commands;
using Deveel.Messaging.Terminals.Commands;
using Deveel.Messaging.Terminals;

namespace Deveel.Messaging {
	public static class OcmClientExtensions {
		#region Terminals

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

		#endregion

		#region Channels

		public static Task<UserChannel> CreateChannelAsync(this IOcmClient client, UserChannel channel, CancellationToken cancellationToken = default)
			=> client.ExecuteAsync<CreateChannelCommand, UserChannel>(new CreateChannelCommand(channel), cancellationToken);

		public static async Task<UserChannel> CreateChannelAsync(this IOcmClient client, Action<UserChannelBuilder> configure, CancellationToken cancellationToken = default) {
			var builder = new UserChannelBuilder();
			configure(builder);

			return await client.CreateChannelAsync(builder.Build(), cancellationToken);
		}

		public static Task<UserChannel?> FindChannelByIdAsync(this IOcmClient client, string channelId, CancellationToken cancellationToken = default)
			=> client.ExecuteAsync<GetUserChannelCommand, UserChannel?>(new GetUserChannelCommand(channelId), cancellationToken);

		public static Task<UserChannel?> FindChannelByNameAsync(this IOcmClient client, ChannelName channelName, CancellationToken cancellationToken = default)
			=> client.ExecuteAsync<GetUserChannelCommand, UserChannel?>(new GetUserChannelCommand(channelName), cancellationToken);

		public static Task<IReadOnlyList<ChannelSchema>> ListChannelSchemaAsync(this IOcmClient client, string? provider = null, CancellationToken cancellationToken = default)
			=> client.ExecuteAsync<ListChannelSchemaCommand, IReadOnlyList<ChannelSchema>>(new ListChannelSchemaCommand(provider), cancellationToken);

		public static Task DeleteChannelAsync(this IOcmClient client, string channelId, CancellationToken cancellationToken = default)
			=> client.ExecuteAsync(new DeleteChannelCommand(channelId), cancellationToken);

		#endregion
	}
}

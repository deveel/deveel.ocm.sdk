using System;

using Azure;

using Deveel.Messaging.Terminals.Management.Models;

namespace Deveel.Messaging.Terminals {
	public sealed class ServerTerminal {
		public ServerTerminal(TerminalType type, string address, string provider) {
			if (string.IsNullOrWhiteSpace(address)) 
				throw new ArgumentException($"'{nameof(address)}' cannot be null or whitespace.", nameof(address));
			if (string.IsNullOrWhiteSpace(provider)) 
				throw new ArgumentException($"'{nameof(provider)}' cannot be null or whitespace.", nameof(provider));

			Type = type;
			Address = address;
			Provider = provider;
		}

		public string? Id { get; private set; }

		public TerminalType Type { get; }

		public string Address { get; }

		public string Provider { get; }

		public ServerTerminalRoles? Roles { get; set; }

		public IDictionary<string, object>? Context { get; set; }

		public bool Active { get; private set; }

		internal static ServerTerminal FromClient(Management.Models.ServerTerminal result)
			=> new ServerTerminal(result.Type.AsTerminalType(), result.Address, result.Provider) {
				Id = result.Id,
				Roles = result.Role.AsTerminalRoles(),
				Active = result.Status == Management.Models.TerminalStatus.Active,
				Context = result.Context?.ToDictionary(x => x.Key, y => y.Value)
			};

		internal Management.Models.NewServerTerminal AsNewServerTerminal() {
			return new NewServerTerminal(Provider, Roles.AsClientTerminalRoles(), Type.AsClientServerTerminalType(), Address) {
				Context = Context
			};
		}
	}
}

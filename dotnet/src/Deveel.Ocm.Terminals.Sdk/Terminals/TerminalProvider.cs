using System;

namespace Deveel.Messaging.Terminals {
	public sealed class TerminalProvider {
		private TerminalProvider(string code, string name, TerminalType[] terminalTypes) {
			Code = code;
			Name = name;
			TerminalTypes = terminalTypes;
		}

		public string Name { get; }

		public string Code { get; }

		public TerminalType[] TerminalTypes { get; }

		internal static TerminalProvider FromClient(Management.Models.TerminalProvider provider) 
			=> new TerminalProvider(provider.Code, provider.Name, provider.TerminalTypes?.Select(x => x.AsTerminalType()).ToArray() ?? new TerminalType[0]);
	}
}

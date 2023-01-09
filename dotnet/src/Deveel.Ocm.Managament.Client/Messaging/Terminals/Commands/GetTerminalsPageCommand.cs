using System;

using Deveel.Messaging.Commands;

namespace Deveel.Messaging.Terminals.Commands {
	class GetTerminalsPageCommand : IClientCommand<PagedResult<ServerTerminal>> {
		public GetTerminalsPageCommand(PageRef page, string? type = null, IList<string>? sort = null) {
			Page = page;
			Type = type;
			Sort = sort;
		}

		public PageRef Page { get; }

		public string? Type { get; set; }

		public IList<string>? Sort { get; set; }
	}
}

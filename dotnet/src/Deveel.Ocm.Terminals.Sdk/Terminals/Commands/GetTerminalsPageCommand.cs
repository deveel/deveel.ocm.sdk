using System;

using Deveel.Messaging.Commands;

namespace Deveel.Messaging.Terminals.Commands {
	class GetTerminalsPageCommand : IClientCommand<PagedResult<ServerTerminal>> {
		public GetTerminalsPageCommand(int pageNumber, int pageSize, string? type = null, IList<string>? sort = null) {
			PageNumber = pageNumber;
			PageSize = pageSize;
			Type = type;
			Sort = sort;
		}

		public int PageSize { get; }

		public int PageNumber { get; }

		public string? Type { get; set; }

		public IList<string>? Sort { get; set; }
	}
}

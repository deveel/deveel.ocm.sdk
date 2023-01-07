using System;

namespace Deveel {
	public sealed class PageEnumerable<TItem> : IAsyncEnumerable<PagedResult<TItem>> {
		private readonly Func<int, Task<PagedResult<TItem>>> iterator;

		public PageEnumerable(Func<int, Task<PagedResult<TItem>>> iterator) {
			this.iterator = iterator;
		}

		public IAsyncEnumerator<PagedResult<TItem>> GetAsyncEnumerator(CancellationToken cancellationToken = default) { 
			return new PageEnumerator<TItem>(iterator,cancellationToken);
		}
	}
}

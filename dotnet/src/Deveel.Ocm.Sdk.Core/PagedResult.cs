using System;
using System.Collections;

namespace Deveel {
	public sealed class PagedResult<TItem> : IEnumerable<TItem> {
		public PagedResult(PageRef page, int totalItems, IReadOnlyList<TItem> items) {
			if (totalItems < 0)
				throw new ArgumentOutOfRangeException(nameof(totalItems), "The total count of items should be greater or equal than zero");
			
			Page = page;
			TotalItems = totalItems;
			Items = items;
		}

		public IReadOnlyList<TItem> Items { get; }

		public PageRef Page { get; }

		public int TotalItems { get; }

		public int TotalPages => (int)Math.Ceiling((double)TotalItems / Page.Size);

		public IEnumerator<TItem> GetEnumerator() => Items.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public bool HasNextPage => Page.Number < TotalPages;

		public int? NextPage => HasNextPage ? Page.Number + 1 : null;

		public static PagedResult<TItem> Create(PageRef page, int totalItems, IEnumerable<TItem>? items)
			=> new PagedResult<TItem>(page, totalItems, items?.ToList().AsReadOnly() ?? new List<TItem>().AsReadOnly());
	}
}

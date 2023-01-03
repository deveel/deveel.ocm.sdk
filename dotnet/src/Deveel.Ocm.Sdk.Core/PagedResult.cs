﻿using System;
using System.Collections;

namespace Deveel {
	public sealed class PagedResult<TItem> : IEnumerable<TItem> {
		public IReadOnlyList<TItem> Items { get; }

		public PagedResult(int totalItems, IReadOnlyList<TItem> items) {
			TotalItems = totalItems;
			Items = items;
		}

		public int TotalItems { get; }

		public IEnumerator<TItem> GetEnumerator() => Items.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		// TODO: next page
	}
}

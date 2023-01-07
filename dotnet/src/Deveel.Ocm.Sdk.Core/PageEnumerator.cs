using System;

namespace Deveel {
	class PageEnumerator<TItem> : IAsyncEnumerator<PagedResult<TItem>> {
		private Func<int, Task<PagedResult<TItem>>> iterator;
		private PagedResult<TItem>? current;
		private bool disposed;
		private readonly CancellationToken cancellationToken;

		public PageEnumerator(Func<int, Task<PagedResult<TItem>>> iterator, CancellationToken cancellationToken) {
			this.iterator = iterator;
			this.cancellationToken = cancellationToken;
		}

		private void ThrowIfDisposed() {
			if (disposed)
				throw new ObjectDisposedException(GetType().Name);
		}

		public PagedResult<TItem> Current { 
			get {
				ThrowIfDisposed();
				cancellationToken.ThrowIfCancellationRequested();
				return current;
			}
		}

		public ValueTask DisposeAsync() {
			disposed = true;
			iterator = null;
			return ValueTask.CompletedTask;
		}

		public async ValueTask<bool> MoveNextAsync() {
			ThrowIfDisposed();
			cancellationToken.ThrowIfCancellationRequested();

			if (current != null && !current.HasNextPage) {
				return false;
			}

			if (current == null) {
				current = await iterator.Invoke(1);
			} else {
				current = await iterator.Invoke(current.NextPage.Value);
			}

			return true;
		}
	}
}

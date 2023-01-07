using System;
using System.Diagnostics;

namespace Deveel {
	[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
	public readonly struct PageRef : IEquatable<PageRef> {
		public PageRef(int number, int size) : this() {
			if (number < 1)
				throw new ArgumentOutOfRangeException(nameof(number), "The page number must be greater or equal to 1");
			if (size < 0)
				throw new ArgumentOutOfRangeException(nameof(size), "The page size must be greater or equal to zero");

			Number = number;
			Size = size;
		}

		public int Number { get; }

		public int Size { get; }

		public override bool Equals(object? obj) => obj is PageRef @ref && Equals(@ref);

		public bool Equals(PageRef other) => Number == other.Number && Size == other.Size;

		public static bool operator ==(PageRef left, PageRef right) => left.Equals(right);

		public static bool operator !=(PageRef left, PageRef right) => !(left == right);

		public override int GetHashCode() => HashCode.Combine(Number, Size);

		private string GetDebuggerDisplay() => this.ToString();

		public override string? ToString() => $"page({this.Number},{this.Size})";
	}
}

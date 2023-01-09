using System;
using System.Diagnostics;

namespace Deveel.Messaging.Channels {
	/// <summary>
	/// References a provider of messaging services supported by the platform
	/// </summary>
	[DebuggerDisplay("{ToString()}")]
	public readonly struct ChannelProvider : IEquatable<ChannelProvider>, IEquatable<string> {
		private readonly string name;

		/// <summary>
		/// Constructs a new reference to the provider
		/// </summary>
		/// <param name="name">The unique name of the provider</param>
		/// <exception cref="ArgumentException">
		/// Thrown if the provided name is <c>null</c> or an empty string
		/// </exception>
		public ChannelProvider(string name) {
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));

			this.name = name;
		}

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is ChannelProvider provider && name == provider.name;

		/// <inheritdoc/>
		public override string ToString() => name;

		/// <inheritdoc/>
		public override int GetHashCode() {
			return name.GetHashCode();
		}

		/// <inheritdoc/>
		public bool Equals(ChannelProvider other) => other.Equals((object) this);

		/// <inheritdoc/>
		public bool Equals(string? other) => this.name == other;

		public static bool operator ==(ChannelProvider left, ChannelProvider right) {
			return left.Equals(right);
		}

		public static bool operator !=(ChannelProvider left, ChannelProvider right) {
			return !(left == right);
		}

		public static implicit operator String(ChannelProvider provider) => provider.name;

		public static implicit operator ChannelProvider(string name) => new ChannelProvider(name);
	}
}

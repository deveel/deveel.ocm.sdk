using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

using Microsoft.Extensions.Primitives;

namespace Deveel.Messaging {
	[DebuggerDisplay("{ToString()}")]
	public struct ChannelName : IEquatable<string>, IEquatable<ChannelName> {
		private readonly string name;

		private static readonly string _namePattern = "^[a-zA-Z0-9_.-]+$";
		private static Regex _nameRegex = new Regex(_namePattern);

		public ChannelName(string name) {
			if (string.IsNullOrWhiteSpace(name)) 
				throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));

			ValidateName(name);

			this.name = new string(name.AsSpan());
		}

		public static void ValidateName(string name) {
			// TODO: use an efficient regex to validate the name is valid
			if (!IsValid(name))
				throw new ArgumentException($"The name '{name}' is invalid for a channel", nameof(name));
		}

		public static bool IsValid(string name) {
			var m = _nameRegex!.Match(name);

			return (m.Success && m.Index == 0 && m.Length == name.Length);
		}

		public static implicit operator ChannelName(string s)
			=> new ChannelName(s);

		public static implicit operator string(ChannelName name)
			=> name.name;

		public override string ToString() => name.ToString();

		public bool Equals(string? other) => !String.IsNullOrWhiteSpace(other) && String.Equals(name, other, StringComparison.Ordinal);

		public bool Equals(ChannelName other) => String.Equals(name, other.name, StringComparison.Ordinal);

		public override bool Equals([NotNullWhen(true)] object? obj) => 
			obj is ChannelName channelName && 
			String.Equals(name, channelName.name, StringComparison.Ordinal);

		public override int GetHashCode() => name.GetHashCode();
	}
}

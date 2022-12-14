// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Deveel.Messaging.Terminals.Management.Models
{
    /// <summary> The ServerTerminalType. </summary>
    public readonly partial struct ServerTerminalType : IEquatable<ServerTerminalType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ServerTerminalType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ServerTerminalType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string EmailValue = "email";
        private const string PhoneNumberValue = "phoneNumber";
        private const string AlphaNumericValue = "alphaNumeric";

        /// <summary> email. </summary>
        public static ServerTerminalType Email { get; } = new ServerTerminalType(EmailValue);
        /// <summary> phoneNumber. </summary>
        public static ServerTerminalType PhoneNumber { get; } = new ServerTerminalType(PhoneNumberValue);
        /// <summary> alphaNumeric. </summary>
        public static ServerTerminalType AlphaNumeric { get; } = new ServerTerminalType(AlphaNumericValue);
        /// <summary> Determines if two <see cref="ServerTerminalType"/> values are the same. </summary>
        public static bool operator ==(ServerTerminalType left, ServerTerminalType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ServerTerminalType"/> values are not the same. </summary>
        public static bool operator !=(ServerTerminalType left, ServerTerminalType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ServerTerminalType"/>. </summary>
        public static implicit operator ServerTerminalType(string value) => new ServerTerminalType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ServerTerminalType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ServerTerminalType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Deveel.Messaging.Management.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines values for TerminalSource.
    /// </summary>
    /// <summary>
    /// Determine base value for a given allowed value if exists, else return
    /// the value itself
    /// </summary>
    [JsonConverter(typeof(TerminalSourceConverter))]
    public struct TerminalSource : System.IEquatable<TerminalSource>
    {
        private TerminalSource(string underlyingValue)
        {
            UnderlyingValue=underlyingValue;
        }

        public static readonly TerminalSource Unknown = "unknown";

        public static readonly TerminalSource Inventory = "inventory";

        public static readonly TerminalSource Customer = "customer";


        /// <summary>
        /// Underlying value of enum TerminalSource
        /// </summary>
        private readonly string UnderlyingValue;

        /// <summary>
        /// Returns string representation for TerminalSource
        /// </summary>
        public override string ToString()
        {
            return UnderlyingValue == null ? null : UnderlyingValue.ToString();
        }

        /// <summary>
        /// Compares enums of type TerminalSource
        /// </summary>
        public bool Equals(TerminalSource e)
        {
            return UnderlyingValue.Equals(e.UnderlyingValue);
        }

        /// <summary>
        /// Implicit operator to convert string to TerminalSource
        /// </summary>
        public static implicit operator TerminalSource(string value)
        {
            return new TerminalSource(value);
        }

        /// <summary>
        /// Implicit operator to convert TerminalSource to string
        /// </summary>
        public static implicit operator string(TerminalSource e)
        {
            return e.UnderlyingValue;
        }

        /// <summary>
        /// Overriding == operator for enum TerminalSource
        /// </summary>
        public static bool operator == (TerminalSource e1, TerminalSource e2)
        {
            return e2.Equals(e1);
        }

        /// <summary>
        /// Overriding != operator for enum TerminalSource
        /// </summary>
        public static bool operator != (TerminalSource e1, TerminalSource e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>
        /// Overrides Equals operator for TerminalSource
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is TerminalSource && Equals((TerminalSource)obj);
        }

        /// <summary>
        /// Returns for hashCode TerminalSource
        /// </summary>
        public override int GetHashCode()
        {
            return UnderlyingValue.GetHashCode();
        }

    }
}
// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Deveel.Messaging.Management.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines values for LogicalOperator.
    /// </summary>
    /// <summary>
    /// Determine base value for a given allowed value if exists, else return
    /// the value itself
    /// </summary>
    [JsonConverter(typeof(LogicalOperatorConverter))]
    public struct LogicalOperator : System.IEquatable<LogicalOperator>
    {
        private LogicalOperator(string underlyingValue)
        {
            UnderlyingValue=underlyingValue;
        }

        public static readonly LogicalOperator And = "and";

        public static readonly LogicalOperator Or = "or";


        /// <summary>
        /// Underlying value of enum LogicalOperator
        /// </summary>
        private readonly string UnderlyingValue;

        /// <summary>
        /// Returns string representation for LogicalOperator
        /// </summary>
        public override string ToString()
        {
            return UnderlyingValue == null ? null : UnderlyingValue.ToString();
        }

        /// <summary>
        /// Compares enums of type LogicalOperator
        /// </summary>
        public bool Equals(LogicalOperator e)
        {
            return UnderlyingValue.Equals(e.UnderlyingValue);
        }

        /// <summary>
        /// Implicit operator to convert string to LogicalOperator
        /// </summary>
        public static implicit operator LogicalOperator(string value)
        {
            return new LogicalOperator(value);
        }

        /// <summary>
        /// Implicit operator to convert LogicalOperator to string
        /// </summary>
        public static implicit operator string(LogicalOperator e)
        {
            return e.UnderlyingValue;
        }

        /// <summary>
        /// Overriding == operator for enum LogicalOperator
        /// </summary>
        public static bool operator == (LogicalOperator e1, LogicalOperator e2)
        {
            return e2.Equals(e1);
        }

        /// <summary>
        /// Overriding != operator for enum LogicalOperator
        /// </summary>
        public static bool operator != (LogicalOperator e1, LogicalOperator e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>
        /// Overrides Equals operator for LogicalOperator
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is LogicalOperator && Equals((LogicalOperator)obj);
        }

        /// <summary>
        /// Returns for hashCode LogicalOperator
        /// </summary>
        public override int GetHashCode()
        {
            return UnderlyingValue.GetHashCode();
        }

    }
}
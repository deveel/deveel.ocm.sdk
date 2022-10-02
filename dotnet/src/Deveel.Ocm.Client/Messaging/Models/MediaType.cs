// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Deveel.Messaging.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines values for MediaType.
    /// </summary>
    /// <summary>
    /// Determine base value for a given allowed value if exists, else return
    /// the value itself
    /// </summary>
    [JsonConverter(typeof(MediaTypeConverter))]
    public struct MediaType : System.IEquatable<MediaType>
    {
        private MediaType(string underlyingValue)
        {
            UnderlyingValue=underlyingValue;
        }

        public static readonly MediaType Unknown = "unknown";

        public static readonly MediaType File = "file";

        public static readonly MediaType Image = "image";

        public static readonly MediaType Audio = "audio";

        public static readonly MediaType Video = "video";


        /// <summary>
        /// Underlying value of enum MediaType
        /// </summary>
        private readonly string UnderlyingValue;

        /// <summary>
        /// Returns string representation for MediaType
        /// </summary>
        public override string ToString()
        {
            return UnderlyingValue == null ? null : UnderlyingValue.ToString();
        }

        /// <summary>
        /// Compares enums of type MediaType
        /// </summary>
        public bool Equals(MediaType e)
        {
            return UnderlyingValue.Equals(e.UnderlyingValue);
        }

        /// <summary>
        /// Implicit operator to convert string to MediaType
        /// </summary>
        public static implicit operator MediaType(string value)
        {
            return new MediaType(value);
        }

        /// <summary>
        /// Implicit operator to convert MediaType to string
        /// </summary>
        public static implicit operator string(MediaType e)
        {
            return e.UnderlyingValue;
        }

        /// <summary>
        /// Overriding == operator for enum MediaType
        /// </summary>
        public static bool operator == (MediaType e1, MediaType e2)
        {
            return e2.Equals(e1);
        }

        /// <summary>
        /// Overriding != operator for enum MediaType
        /// </summary>
        public static bool operator != (MediaType e1, MediaType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>
        /// Overrides Equals operator for MediaType
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is MediaType && Equals((MediaType)obj);
        }

        /// <summary>
        /// Returns for hashCode MediaType
        /// </summary>
        public override int GetHashCode()
        {
            return UnderlyingValue.GetHashCode();
        }

    }
}
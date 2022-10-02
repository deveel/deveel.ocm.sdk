// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Deveel.Messaging.Management.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Range
    {
        /// <summary>
        /// Initializes a new instance of the Range class.
        /// </summary>
        public Range()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Range class.
        /// </summary>
        public Range(FilterValue lower = default(FilterValue), FilterValue upper = default(FilterValue))
        {
            Lower = lower;
            Upper = upper;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lower")]
        public FilterValue Lower { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "upper")]
        public FilterValue Upper { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Lower != null)
            {
                Lower.Validate();
            }
            if (Upper != null)
            {
                Upper.Validate();
            }
        }
    }
}
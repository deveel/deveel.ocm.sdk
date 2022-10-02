// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Deveel.Messaging.Management.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// A rule used to match the configuration for the routing of a message
    /// </summary>
    public partial class RouteMatchRule
    {
        /// <summary>
        /// Initializes a new instance of the RouteMatchRule class.
        /// </summary>
        public RouteMatchRule()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RouteMatchRule class.
        /// </summary>
        public RouteMatchRule(TextMatch text = default(TextMatch), Terminal receiver = default(Terminal))
        {
            Text = text;
            Receiver = receiver;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public TextMatch Text { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "receiver")]
        public Terminal Receiver { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Text != null)
            {
                Text.Validate();
            }
            if (Receiver != null)
            {
                Receiver.Validate();
            }
        }
    }
}
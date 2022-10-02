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
    /// The request to change the status of a message route
    /// </summary>
    public partial class MessageRouteStatusUpdate
    {
        /// <summary>
        /// Initializes a new instance of the MessageRouteStatusUpdate class.
        /// </summary>
        public MessageRouteStatusUpdate()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the MessageRouteStatusUpdate class.
        /// </summary>
        /// <param name="active">Wether or not the message route should be
        /// active or not</param>
        public MessageRouteStatusUpdate(bool active)
        {
            Active = active;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets wether or not the message route should be active or
        /// not
        /// </summary>
        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            //Nothing to validate
        }
    }
}
// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Deveel.Messaging.Management.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Describes a channel that receives and routes
    /// inbound messages
    /// </summary>
    public partial class RouteChannel
    {
        /// <summary>
        /// Initializes a new instance of the RouteChannel class.
        /// </summary>
        public RouteChannel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RouteChannel class.
        /// </summary>
        /// <param name="name">The name of the channel instance</param>
        /// <param name="type">Possible values include: 'sms', 'messenger',
        /// 'whatsapp', 'email', 'viber', 'rcs', 'push', 'telegram',
        /// 'sandbox'</param>
        /// <param name="id">The unique identifier of the channel</param>
        public RouteChannel(string name, ChannelType type, string id)
        {
            Name = name;
            Type = type;
            Id = id;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the name of the channel instance
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'sms', 'messenger',
        /// 'whatsapp', 'email', 'viber', 'rcs', 'push', 'telegram', 'sandbox'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public ChannelType Type { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the channel
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
            if (Id == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Id");
            }
        }
    }
}

// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Deveel.Messaging.Management.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The request to create a new route to receive inbound messages
    /// </summary>
    public partial class NewMessageRoute
    {
        /// <summary>
        /// Initializes a new instance of the NewMessageRoute class.
        /// </summary>
        public NewMessageRoute()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the NewMessageRoute class.
        /// </summary>
        /// <param name="channel">The name of the channel transporting the
        /// inbound messages</param>
        /// <param name="name">A descriptive name of the route (for
        /// display)</param>
        /// <param name="destinationUrl">The HTTP URL address where the inbound
        /// message
        /// will be delivered</param>
        /// <param name="active">Whether the route must be set as immediately
        /// active</param>
        /// <param name="retryCount">The number of retries to deliver the
        /// inbound message</param>
        /// <param name="secret">A secret code that is used to sign the
        /// webhooks</param>
        /// <param name="context">A context that is appended to the message
        /// before
        /// the delivery (useful for correlation)</param>
        /// <param name="match">A list of rules that are used to match a
        /// message to the given route</param>
        public NewMessageRoute(string channel, string name, string destinationUrl, bool? active = default(bool?), int? retryCount = default(int?), string secret = default(string), IDictionary<string, object> context = default(IDictionary<string, object>), IList<RouteMatchRule> match = default(IList<RouteMatchRule>))
        {
            Channel = channel;
            Name = name;
            DestinationUrl = destinationUrl;
            Active = active;
            RetryCount = retryCount;
            Secret = secret;
            Context = context;
            Match = match;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the name of the channel transporting the inbound
        /// messages
        /// </summary>
        [JsonProperty(PropertyName = "channel")]
        public string Channel { get; set; }

        /// <summary>
        /// Gets or sets a descriptive name of the route (for display)
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the HTTP URL address where the inbound message
        /// will be delivered
        /// </summary>
        [JsonProperty(PropertyName = "destinationUrl")]
        public string DestinationUrl { get; set; }

        /// <summary>
        /// Gets or sets whether the route must be set as immediately active
        /// </summary>
        [JsonProperty(PropertyName = "active")]
        public bool? Active { get; set; }

        /// <summary>
        /// Gets or sets the number of retries to deliver the inbound message
        /// </summary>
        [JsonProperty(PropertyName = "retryCount")]
        public int? RetryCount { get; set; }

        /// <summary>
        /// Gets or sets a secret code that is used to sign the webhooks
        /// </summary>
        [JsonProperty(PropertyName = "secret")]
        public string Secret { get; set; }

        /// <summary>
        /// Gets or sets a context that is appended to the message before
        /// the delivery (useful for correlation)
        /// </summary>
        [JsonProperty(PropertyName = "context")]
        public IDictionary<string, object> Context { get; set; }

        /// <summary>
        /// Gets or sets a list of rules that are used to match a message to
        /// the given route
        /// </summary>
        [JsonProperty(PropertyName = "match")]
        public IList<RouteMatchRule> Match { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Channel == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Channel");
            }
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
            if (DestinationUrl == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DestinationUrl");
            }
            if (Match != null)
            {
                foreach (var element in Match)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}
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
    /// The subscription to the notification of an event
    /// </summary>
    public partial class WebhookSubscription
    {
        /// <summary>
        /// Initializes a new instance of the WebhookSubscription class.
        /// </summary>
        public WebhookSubscription()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the WebhookSubscription class.
        /// </summary>
        /// <param name="destinationUrl">The HTTP URL address where the
        /// notifications
        /// are delivered (as webhooks)</param>
        /// <param name="id">The unique identider of the subscription</param>
        /// <param name="events">The list of message event types
        /// subscribed</param>
        /// <param name="name">A descriptive name of the subscription (for
        /// display)</param>
        /// <param name="active">The active state of the subscription</param>
        /// <param name="secret">An optional secret string used to sign the
        /// webhooks
        /// delivered to the subscriber</param>
        /// <param name="headers">A set of additional headers attached to the
        /// HTTP request
        /// fired towards the destination URL (typically used for
        /// context)</param>
        /// <param name="retryCount">The number of attempts to perform when
        /// trying to deliver
        /// the webhook, before failing</param>
        /// <param name="filters">An optional set of filters used to restrict
        /// the
        /// delivery of webhooks</param>
        /// <param name="metadata">A list of metadata associated to the
        /// subscription</param>
        public WebhookSubscription(string destinationUrl, string id, IList<string> events, string name, bool active, string secret = default(string), IDictionary<string, string> headers = default(IDictionary<string, string>), int? retryCount = default(int?), IList<Filter> filters = default(IList<Filter>), IDictionary<string, object> metadata = default(IDictionary<string, object>))
        {
            DestinationUrl = destinationUrl;
            Secret = secret;
            Headers = headers;
            Id = id;
            Events = events;
            Name = name;
            Active = active;
            RetryCount = retryCount;
            Filters = filters;
            Metadata = metadata;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the HTTP URL address where the notifications
        /// are delivered (as webhooks)
        /// </summary>
        [JsonProperty(PropertyName = "destinationUrl")]
        public string DestinationUrl { get; set; }

        /// <summary>
        /// Gets or sets an optional secret string used to sign the webhooks
        /// delivered to the subscriber
        /// </summary>
        [JsonProperty(PropertyName = "secret")]
        public string Secret { get; set; }

        /// <summary>
        /// Gets or sets a set of additional headers attached to the HTTP
        /// request
        /// fired towards the destination URL (typically used for context)
        /// </summary>
        [JsonProperty(PropertyName = "headers")]
        public IDictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Gets or sets the unique identider of the subscription
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the list of message event types subscribed
        /// </summary>
        [JsonProperty(PropertyName = "events")]
        public IList<string> Events { get; set; }

        /// <summary>
        /// Gets or sets a descriptive name of the subscription (for display)
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the active state of the subscription
        /// </summary>
        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the number of attempts to perform when trying to
        /// deliver
        /// the webhook, before failing
        /// </summary>
        [JsonProperty(PropertyName = "retryCount")]
        public int? RetryCount { get; set; }

        /// <summary>
        /// Gets or sets an optional set of filters used to restrict the
        /// delivery of webhooks
        /// </summary>
        [JsonProperty(PropertyName = "filters")]
        public IList<Filter> Filters { get; set; }

        /// <summary>
        /// Gets or sets a list of metadata associated to the subscription
        /// </summary>
        [JsonProperty(PropertyName = "metadata")]
        public IDictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (DestinationUrl == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DestinationUrl");
            }
            if (Id == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Id");
            }
            if (Events == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Events");
            }
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
            if (Filters != null)
            {
                foreach (var element in Filters)
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
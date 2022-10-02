// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Deveel.Messaging.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The result of to the request to enqueue a message
    /// </summary>
    public partial class MessageResult
    {
        /// <summary>
        /// Initializes a new instance of the MessageResult class.
        /// </summary>
        public MessageResult()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the MessageResult class.
        /// </summary>
        /// <param name="messageId">The unique identifier of the message within
        /// the system</param>
        /// <param name="context">The context provided when requesting the
        /// enqueue of the message (for correlation)</param>
        public MessageResult(string messageId, IDictionary<string, object> context = default(IDictionary<string, object>), FallbackMessageResult fallback = default(FallbackMessageResult))
        {
            MessageId = messageId;
            Context = context;
            Fallback = fallback;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the unique identifier of the message within the system
        /// </summary>
        [JsonProperty(PropertyName = "messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets the context provided when requesting the enqueue of
        /// the message (for correlation)
        /// </summary>
        [JsonProperty(PropertyName = "context")]
        public IDictionary<string, object> Context { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "fallback")]
        public FallbackMessageResult Fallback { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (MessageId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "MessageId");
            }
            if (Fallback != null)
            {
                Fallback.Validate();
            }
        }
    }
}
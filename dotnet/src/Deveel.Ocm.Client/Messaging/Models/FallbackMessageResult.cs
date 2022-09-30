// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Deveel.Messaging.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The result to the request to send a fallback message
    /// </summary>
    public partial class FallbackMessageResult
    {
        /// <summary>
        /// Initializes a new instance of the FallbackMessageResult class.
        /// </summary>
        public FallbackMessageResult()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the FallbackMessageResult class.
        /// </summary>
        /// <param name="messageId">The unique identifier of the message within
        /// the system</param>
        public FallbackMessageResult(string messageId, FallbackMessageResult fallback = default(FallbackMessageResult))
        {
            MessageId = messageId;
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

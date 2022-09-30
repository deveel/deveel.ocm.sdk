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
    /// An inbound message sent from an individual
    /// </summary>
    public partial class InboundMessage
    {
        /// <summary>
        /// Initializes a new instance of the InboundMessage class.
        /// </summary>
        public InboundMessage()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the InboundMessage class.
        /// </summary>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="context">A custom-defined context of the message
        /// (typically used to correlate).</param>
        public InboundMessage(Terminal sender, Terminal receiver, MessageContent content, System.DateTimeOffset timeStamp, IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), MessageChannel channel = default(MessageChannel), string id = default(string), IDictionary<string, object> context = default(IDictionary<string, object>))
        {
            AdditionalProperties = additionalProperties;
            Channel = channel;
            Id = id;
            Sender = sender;
            Receiver = receiver;
            Content = content;
            TimeStamp = timeStamp;
            Context = context;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets unmatched properties from the message are deserialized
        /// this collection
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "channel")]
        public MessageChannel Channel { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sender")]
        public Terminal Sender { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "receiver")]
        public Terminal Receiver { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "content")]
        public MessageContent Content { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "timeStamp")]
        public System.DateTimeOffset TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets a custom-defined context of the message (typically
        /// used to correlate).
        /// </summary>
        [JsonProperty(PropertyName = "context")]
        public IDictionary<string, object> Context { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Sender == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Sender");
            }
            if (Receiver == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Receiver");
            }
            if (Content == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Content");
            }
            if (Channel != null)
            {
                Channel.Validate();
            }
            if (Sender != null)
            {
                Sender.Validate();
            }
            if (Receiver != null)
            {
                Receiver.Validate();
            }
            if (Content != null)
            {
                Content.Validate();
            }
        }
    }
}

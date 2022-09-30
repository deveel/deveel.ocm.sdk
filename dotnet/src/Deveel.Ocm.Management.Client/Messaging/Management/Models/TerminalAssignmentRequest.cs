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

    public partial class TerminalAssignmentRequest
    {
        /// <summary>
        /// Initializes a new instance of the TerminalAssignmentRequest class.
        /// </summary>
        public TerminalAssignmentRequest()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TerminalAssignmentRequest class.
        /// </summary>
        public TerminalAssignmentRequest(RequestedTerminal terminal, string requester, System.DateTimeOffset timeStamp, string id, TerminalAssignmentResponse response = default(TerminalAssignmentResponse), TerminalAssignment assignment = default(TerminalAssignment))
        {
            Terminal = terminal;
            Requester = requester;
            TimeStamp = timeStamp;
            Response = response;
            Id = id;
            Assignment = assignment;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "terminal")]
        public RequestedTerminal Terminal { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "requester")]
        public string Requester { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "timeStamp")]
        public System.DateTimeOffset TimeStamp { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "response")]
        public TerminalAssignmentResponse Response { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "assignment")]
        public TerminalAssignment Assignment { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Terminal == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Terminal");
            }
            if (Requester == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Requester");
            }
            if (Id == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Id");
            }
            if (Terminal != null)
            {
                Terminal.Validate();
            }
            if (Response != null)
            {
                Response.Validate();
            }
            if (Assignment != null)
            {
                Assignment.Validate();
            }
        }
    }
}

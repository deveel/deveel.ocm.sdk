// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Deveel.Messaging.Management.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class NewTerminalAssignmentRequest
    {
        /// <summary>
        /// Initializes a new instance of the NewTerminalAssignmentRequest
        /// class.
        /// </summary>
        public NewTerminalAssignmentRequest()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the NewTerminalAssignmentRequest
        /// class.
        /// </summary>
        /// <param name="role">Possible values include: 'default', 'sender',
        /// 'receiver', 'both'</param>
        public NewTerminalAssignmentRequest(TerminalRoles? role = default(TerminalRoles?), string type = default(string), string address = default(string), string terminalId = default(string))
        {
            Role = role;
            Type = type;
            Address = address;
            TerminalId = terminalId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets possible values include: 'default', 'sender',
        /// 'receiver', 'both'
        /// </summary>
        [JsonProperty(PropertyName = "role")]
        public TerminalRoles? Role { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "terminalId")]
        public string TerminalId { get; set; }

    }
}
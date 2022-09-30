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

    public partial class NewServerTerminal
    {
        /// <summary>
        /// Initializes a new instance of the NewServerTerminal class.
        /// </summary>
        public NewServerTerminal()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the NewServerTerminal class.
        /// </summary>
        /// <param name="role">Possible values include: 'default', 'sender',
        /// 'receiver', 'both'</param>
        /// <param name="type">Possible values include: 'email', 'phoneNumber',
        /// 'alphaNumeric'</param>
        public NewServerTerminal(string provider, TerminalRoles role, ServerTerminalType type, string address, IDictionary<string, object> settings = default(IDictionary<string, object>))
        {
            Settings = settings;
            Provider = provider;
            Role = role;
            Type = type;
            Address = address;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "settings")]
        public IDictionary<string, object> Settings { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "provider")]
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'default', 'sender',
        /// 'receiver', 'both'
        /// </summary>
        [JsonProperty(PropertyName = "role")]
        public TerminalRoles Role { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'email', 'phoneNumber',
        /// 'alphaNumeric'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public ServerTerminalType Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Provider == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Provider");
            }
            if (Address == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Address");
            }
        }
    }
}

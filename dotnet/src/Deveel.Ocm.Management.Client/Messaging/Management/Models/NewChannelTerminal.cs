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
    /// The request to associate a terminal to the channel
    /// </summary>
    public partial class NewChannelTerminal
    {
        /// <summary>
        /// Initializes a new instance of the NewChannelTerminal class.
        /// </summary>
        public NewChannelTerminal()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the NewChannelTerminal class.
        /// </summary>
        /// <param name="id">The unique identifier of the terminal (if not
        /// provided, the terminal type and address will be used for the
        /// resolution)</param>
        /// <param name="type">Possible values include: 'phoneNumber', 'email',
        /// 'alphaNumeric', 'conversation', 'postalAddress', 'user', 'app',
        /// 'url'</param>
        /// <param name="address">The address of the terminal to assign (if not
        /// provided,
        /// the terminal identifier will be used for the resolution)</param>
        public NewChannelTerminal(string id = default(string), TerminalType? type = default(TerminalType?), string address = default(string))
        {
            Id = id;
            Type = type;
            Address = address;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the unique identifier of the terminal (if not
        /// provided, the terminal type and address will be used for the
        /// resolution)
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'phoneNumber', 'email',
        /// 'alphaNumeric', 'conversation', 'postalAddress', 'user', 'app',
        /// 'url'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public TerminalType? Type { get; set; }

        /// <summary>
        /// Gets or sets the address of the terminal to assign (if not
        /// provided,
        /// the terminal identifier will be used for the resolution)
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

    }
}
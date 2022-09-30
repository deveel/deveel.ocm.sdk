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

    public partial class Client
    {
        /// <summary>
        /// Initializes a new instance of the Client class.
        /// </summary>
        public Client()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Client class.
        /// </summary>
        public Client(string name, string id, string clientId, string clientSecret, bool active, string tenantId = default(string), IList<GrantType?> grantTypes = default(IList<GrantType?>), IDictionary<string, object> properties = default(IDictionary<string, object>), string consentType = default(string))
        {
            Name = name;
            TenantId = tenantId;
            Id = id;
            ClientId = clientId;
            GrantTypes = grantTypes;
            ClientSecret = clientSecret;
            Properties = properties;
            ConsentType = consentType;
            Active = active;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tenantId")]
        public string TenantId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "clientId")]
        public string ClientId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "grantTypes")]
        public IList<GrantType?> GrantTypes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "clientSecret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public IDictionary<string, object> Properties { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "consentType")]
        public string ConsentType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

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
            if (ClientId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ClientId");
            }
            if (ClientSecret == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ClientSecret");
            }
        }
    }
}

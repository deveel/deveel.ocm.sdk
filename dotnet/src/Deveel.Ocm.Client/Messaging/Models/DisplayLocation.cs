// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Deveel.Messaging.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The specifications of the location to
    /// display when a button is clicked
    /// </summary>
    public partial class DisplayLocation
    {
        /// <summary>
        /// Initializes a new instance of the DisplayLocation class.
        /// </summary>
        public DisplayLocation()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DisplayLocation class.
        /// </summary>
        /// <param name="lon">The longitude of the location point</param>
        /// <param name="lat">The latitude of the location point</param>
        /// <param name="description">An optional description of the location
        /// to display</param>
        public DisplayLocation(double lon, double lat, string description = default(string))
        {
            Lon = lon;
            Lat = lat;
            Description = description;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the longitude of the location point
        /// </summary>
        [JsonProperty(PropertyName = "lon")]
        public double Lon { get; set; }

        /// <summary>
        /// Gets or sets the latitude of the location point
        /// </summary>
        [JsonProperty(PropertyName = "lat")]
        public double Lat { get; set; }

        /// <summary>
        /// Gets or sets an optional description of the location to display
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            //Nothing to validate
        }
    }
}
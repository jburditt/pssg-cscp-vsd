// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Gov.Jag.VictimServices.Interfaces.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// competitorsalesliterature
    /// </summary>
    public partial class MicrosoftDynamicsCRMcompetitorsalesliterature
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMcompetitorsalesliterature class.
        /// </summary>
        public MicrosoftDynamicsCRMcompetitorsalesliterature()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMcompetitorsalesliterature class.
        /// </summary>
        public MicrosoftDynamicsCRMcompetitorsalesliterature(string competitorid = default(string), string salesliteratureid = default(string), long? versionnumber = default(long?), string competitorsalesliteratureid = default(string))
        {
            Competitorid = competitorid;
            Salesliteratureid = salesliteratureid;
            Versionnumber = versionnumber;
            Competitorsalesliteratureid = competitorsalesliteratureid;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "competitorid")]
        public string Competitorid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "salesliteratureid")]
        public string Salesliteratureid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "versionnumber")]
        public long? Versionnumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "competitorsalesliteratureid")]
        public string Competitorsalesliteratureid { get; set; }

    }
}

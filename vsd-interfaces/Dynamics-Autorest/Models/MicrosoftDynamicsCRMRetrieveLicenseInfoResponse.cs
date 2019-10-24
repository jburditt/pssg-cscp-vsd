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
    /// RetrieveLicenseInfoResponse
    /// </summary>
    public partial class MicrosoftDynamicsCRMRetrieveLicenseInfoResponse
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMRetrieveLicenseInfoResponse class.
        /// </summary>
        public MicrosoftDynamicsCRMRetrieveLicenseInfoResponse()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMRetrieveLicenseInfoResponse class.
        /// </summary>
        public MicrosoftDynamicsCRMRetrieveLicenseInfoResponse(int? availableCount = default(int?), int? grantedLicenseCount = default(int?))
        {
            AvailableCount = availableCount;
            GrantedLicenseCount = grantedLicenseCount;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AvailableCount")]
        public int? AvailableCount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "GrantedLicenseCount")]
        public int? GrantedLicenseCount { get; set; }

    }
}

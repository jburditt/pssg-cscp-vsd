#pragma warning disable CS1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database.Model
{
	
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/msdyn/")]
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("msdyn_GetSILicenseStatus")]
	public partial class Msdyn_GetSiLicenseStatusRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public const string ActionLogicalName = "msdyn_GetSILicenseStatus";
		
		public Msdyn_GetSiLicenseStatusRequest()
		{
			this.RequestName = "msdyn_GetSILicenseStatus";
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/msdyn/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("msdyn_GetSILicenseStatus")]
	public partial class Msdyn_GetSiLicenseStatusResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string SiLicenseStatus = "SiLicenseStatus";
		}
		
		public const string ActionLogicalName = "msdyn_GetSILicenseStatus";
		
		public Msdyn_GetSiLicenseStatusResponse()
		{
		}
		
		public string SiLicenseStatus
		{
			get
			{
				if (this.Results.Contains("SILicenseStatus"))
				{
					return ((string)(this.Results["SILicenseStatus"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Results["SiLicenseStatus"] = value;
			}
		}
	}
}
#pragma warning restore CS1591
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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("msdyn_GetSIPackageStatus")]
	public partial class Msdyn_GetSiPackageStatusRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string ApiVersion = "ApiVersion";
		}
		
		public const string ActionLogicalName = "msdyn_GetSIPackageStatus";
		
		public string ApiVersion
		{
			get
			{
				if (this.Parameters.Contains("ApiVersion"))
				{
					return ((string)(this.Parameters["ApiVersion"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["ApiVersion"] = value;
			}
		}
		
		public Msdyn_GetSiPackageStatusRequest()
		{
			this.RequestName = "msdyn_GetSIPackageStatus";
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/msdyn/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("msdyn_GetSIPackageStatus")]
	public partial class Msdyn_GetSiPackageStatusResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string SiPackageStatus = "SiPackageStatus";
		}
		
		public const string ActionLogicalName = "msdyn_GetSIPackageStatus";
		
		public Msdyn_GetSiPackageStatusResponse()
		{
		}
		
		public string SiPackageStatus
		{
			get
			{
				if (this.Results.Contains("SIPackageStatus"))
				{
					return ((string)(this.Results["SIPackageStatus"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Results["SiPackageStatus"] = value;
			}
		}
	}
}
#pragma warning restore CS1591

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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("msdyn_MarketingListMetadataUpdate")]
	public partial class Msdyn_MarketingListMetadataUpdateRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public const string ActionLogicalName = "msdyn_MarketingListMetadataUpdate";
		
		public Msdyn_MarketingListMetadataUpdateRequest()
		{
			this.RequestName = "msdyn_MarketingListMetadataUpdate";
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/msdyn/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("msdyn_MarketingListMetadataUpdate")]
	public partial class Msdyn_MarketingListMetadataUpdateResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string ResultCode = "ResultCode";
		}
		
		public const string ActionLogicalName = "msdyn_MarketingListMetadataUpdate";
		
		public Msdyn_MarketingListMetadataUpdateResponse()
		{
		}
		
		public int ResultCode
		{
			get
			{
				if (this.Results.Contains("resultCode"))
				{
					return ((int)(this.Results["resultCode"]));
				}
				else
				{
					return default(int);
				}
			}
			set
			{
				this.Results["ResultCode"] = value;
			}
		}
	}
}
#pragma warning restore CS1591

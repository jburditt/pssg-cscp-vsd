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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("msdyn_IsSharePointEnabled")]
	public partial class Msdyn_IsSharePointEnabledRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public const string ActionLogicalName = "msdyn_IsSharePointEnabled";
		
		public Msdyn_IsSharePointEnabledRequest()
		{
			this.RequestName = "msdyn_IsSharePointEnabled";
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/msdyn/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("msdyn_IsSharePointEnabled")]
	public partial class Msdyn_IsSharePointEnabledResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string IsSharePointEnabled = "IsSharePointEnabled";
		}
		
		public const string ActionLogicalName = "msdyn_IsSharePointEnabled";
		
		public Msdyn_IsSharePointEnabledResponse()
		{
		}
		
		public bool IsSharePointEnabled
		{
			get
			{
				if (this.Results.Contains("IsSharePointEnabled"))
				{
					return ((bool)(this.Results["IsSharePointEnabled"]));
				}
				else
				{
					return default(bool);
				}
			}
			set
			{
				this.Results["IsSharePointEnabled"] = value;
			}
		}
	}
}
#pragma warning restore CS1591
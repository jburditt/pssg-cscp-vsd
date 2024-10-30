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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("msdyn_GDPROptoutContact")]
	public partial class Msdyn_GdPrOptOutContactRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string OptOut = "OptOut";
			public const string Target = "Target";
		}
		
		public const string ActionLogicalName = "msdyn_GDPROptoutContact";
		
		public bool OptOut
		{
			get
			{
				if (this.Parameters.Contains("optout"))
				{
					return ((bool)(this.Parameters["optout"]));
				}
				else
				{
					return default(bool);
				}
			}
			set
			{
				this.Parameters["optout"] = value;
			}
		}
		
		public Microsoft.Xrm.Sdk.EntityReference Target
		{
			get
			{
				if (this.Parameters.Contains("Target"))
				{
					return ((Microsoft.Xrm.Sdk.EntityReference)(this.Parameters["Target"]));
				}
				else
				{
					return default(Microsoft.Xrm.Sdk.EntityReference);
				}
			}
			set
			{
				this.Parameters["Target"] = value;
			}
		}
		
		public Msdyn_GdPrOptOutContactRequest()
		{
			this.RequestName = "msdyn_GDPROptoutContact";
			this.OptOut = default(bool);
			this.Target = default(Microsoft.Xrm.Sdk.EntityReference);
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/msdyn/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("msdyn_GDPROptoutContact")]
	public partial class Msdyn_GdPrOptOutContactResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public const string ActionLogicalName = "msdyn_GDPROptoutContact";
		
		public Msdyn_GdPrOptOutContactResponse()
		{
		}
	}
}
#pragma warning restore CS1591

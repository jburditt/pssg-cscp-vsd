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
	
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/vsd/")]
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("vsd_CreateCounsellor")]
	public partial class Vsd_CreateCounsellorRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string Target = "Target";
		}
		
		public const string ActionLogicalName = "vsd_CreateCounsellor";
		
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
		
		public Vsd_CreateCounsellorRequest()
		{
			this.RequestName = "vsd_CreateCounsellor";
			this.Target = default(Microsoft.Xrm.Sdk.EntityReference);
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/vsd/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("vsd_CreateCounsellor")]
	public partial class Vsd_CreateCounsellorResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string Counsellor = "Counsellor";
		}
		
		public const string ActionLogicalName = "vsd_CreateCounsellor";
		
		public Vsd_CreateCounsellorResponse()
		{
		}
		
		public Microsoft.Xrm.Sdk.EntityReference Counsellor
		{
			get
			{
				if (this.Results.Contains("Counsellor"))
				{
					return ((Microsoft.Xrm.Sdk.EntityReference)(this.Results["Counsellor"]));
				}
				else
				{
					return default(Microsoft.Xrm.Sdk.EntityReference);
				}
			}
			set
			{
				this.Results["Counsellor"] = value;
			}
		}
	}
}
#pragma warning restore CS1591

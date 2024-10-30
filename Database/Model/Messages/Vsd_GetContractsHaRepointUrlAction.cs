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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("vsd_GetContractSharePointUrlAction")]
	public partial class Vsd_GetContractsHaRepointUrlActionRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string Target = "Target";
		}
		
		public const string ActionLogicalName = "vsd_GetContractSharePointUrlAction";
		
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
		
		public Vsd_GetContractsHaRepointUrlActionRequest()
		{
			this.RequestName = "vsd_GetContractSharePointUrlAction";
			this.Target = default(Microsoft.Xrm.Sdk.EntityReference);
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/vsd/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("vsd_GetContractSharePointUrlAction")]
	public partial class Vsd_GetContractsHaRepointUrlActionResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string SharePointUrl = "SharePointUrl";
			public const string UserMessage = "UserMessage";
		}
		
		public const string ActionLogicalName = "vsd_GetContractSharePointUrlAction";
		
		public Vsd_GetContractsHaRepointUrlActionResponse()
		{
		}
		
		public string SharePointUrl
		{
			get
			{
				if (this.Results.Contains("SharePointUrl"))
				{
					return ((string)(this.Results["SharePointUrl"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Results["SharePointUrl"] = value;
			}
		}
		
		public string UserMessage
		{
			get
			{
				if (this.Results.Contains("UserMessage"))
				{
					return ((string)(this.Results["UserMessage"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Results["UserMessage"] = value;
			}
		}
	}
}
#pragma warning restore CS1591

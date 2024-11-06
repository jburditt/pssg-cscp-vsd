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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("msdyn_ExecuteARC")]
	public partial class Msdyn_ExecuteArcRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string CreatedEntityReference = "CreatedEntityReference";
			public const string RuleId = "RuleId";
		}
		
		public const string ActionLogicalName = "msdyn_ExecuteARC";
		
		public Microsoft.Xrm.Sdk.EntityReference CreatedEntityReference
		{
			get
			{
				if (this.Parameters.Contains("CreatedEntityReference"))
				{
					return ((Microsoft.Xrm.Sdk.EntityReference)(this.Parameters["CreatedEntityReference"]));
				}
				else
				{
					return default(Microsoft.Xrm.Sdk.EntityReference);
				}
			}
			set
			{
				this.Parameters["CreatedEntityReference"] = value;
			}
		}
		
		public string RuleId
		{
			get
			{
				if (this.Parameters.Contains("RuleId"))
				{
					return ((string)(this.Parameters["RuleId"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["RuleId"] = value;
			}
		}
		
		public Msdyn_ExecuteArcRequest()
		{
			this.RequestName = "msdyn_ExecuteARC";
			this.CreatedEntityReference = default(Microsoft.Xrm.Sdk.EntityReference);
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/msdyn/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("msdyn_ExecuteARC")]
	public partial class Msdyn_ExecuteArcResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string ErrorMessage = "ErrorMessage";
			public const string FlowName = "FlowName";
		}
		
		public const string ActionLogicalName = "msdyn_ExecuteARC";
		
		public Msdyn_ExecuteArcResponse()
		{
		}
		
		public string ErrorMessage
		{
			get
			{
				if (this.Results.Contains("ErrorMessage"))
				{
					return ((string)(this.Results["ErrorMessage"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Results["ErrorMessage"] = value;
			}
		}
		
		public string FlowName
		{
			get
			{
				if (this.Results.Contains("FlowName"))
				{
					return ((string)(this.Results["FlowName"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Results["FlowName"] = value;
			}
		}
	}
}
#pragma warning restore CS1591
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
	
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011//")]
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("ScheduleRetrain")]
	public partial class ScheduleRetrainRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string Recurrence = "Recurrence";
			public const string Version = "Version";
			public const string Target = "Target";
		}
		
		public const string ActionLogicalName = "ScheduleRetrain";
		
		public string Recurrence
		{
			get
			{
				if (this.Parameters.Contains("recurrence"))
				{
					return ((string)(this.Parameters["recurrence"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["recurrence"] = value;
			}
		}
		
		public string Version
		{
			get
			{
				if (this.Parameters.Contains("version"))
				{
					return ((string)(this.Parameters["version"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["version"] = value;
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
		
		public ScheduleRetrainRequest()
		{
			this.RequestName = "ScheduleRetrain";
			this.Recurrence = default(string);
			this.Version = default(string);
			this.Target = default(Microsoft.Xrm.Sdk.EntityReference);
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011//")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("ScheduleRetrain")]
	public partial class ScheduleRetrainResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string Response = "Response";
		}
		
		public const string ActionLogicalName = "ScheduleRetrain";
		
		public ScheduleRetrainResponse()
		{
		}
		
		public string Response
		{
			get
			{
				if (this.Results.Contains("response"))
				{
					return ((string)(this.Results["response"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Results["Response"] = value;
			}
		}
	}
}
#pragma warning restore CS1591

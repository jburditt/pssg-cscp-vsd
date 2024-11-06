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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("msdyn_SetSharePointDocumentStatus")]
	public partial class Msdyn_SetsHaRepointDocumentStatusRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string Enable = "Enable";
			public const string LogicalEntityNames = "LogicalEntityNames";
		}
		
		public const string ActionLogicalName = "msdyn_SetSharePointDocumentStatus";
		
		public bool Enable
		{
			get
			{
				if (this.Parameters.Contains("Enable"))
				{
					return ((bool)(this.Parameters["Enable"]));
				}
				else
				{
					return default(bool);
				}
			}
			set
			{
				this.Parameters["Enable"] = value;
			}
		}
		
		public string LogicalEntityNames
		{
			get
			{
				if (this.Parameters.Contains("LogicalEntityNames"))
				{
					return ((string)(this.Parameters["LogicalEntityNames"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["LogicalEntityNames"] = value;
			}
		}
		
		public Msdyn_SetsHaRepointDocumentStatusRequest()
		{
			this.RequestName = "msdyn_SetSharePointDocumentStatus";
			this.Enable = default(bool);
			this.LogicalEntityNames = default(string);
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/msdyn/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("msdyn_SetSharePointDocumentStatus")]
	public partial class Msdyn_SetsHaRepointDocumentStatusResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string FailedLogicalEntityNames = "FailedLogicalEntityNames";
			public const string OperationResult = "OperationResult";
			public const string PassedLogicalEntityNames = "PassedLogicalEntityNames";
		}
		
		public const string ActionLogicalName = "msdyn_SetSharePointDocumentStatus";
		
		public Msdyn_SetsHaRepointDocumentStatusResponse()
		{
		}
		
		public string FailedLogicalEntityNames
		{
			get
			{
				if (this.Results.Contains("FailedLogicalEntityNames"))
				{
					return ((string)(this.Results["FailedLogicalEntityNames"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Results["FailedLogicalEntityNames"] = value;
			}
		}
		
		public bool OperationResult
		{
			get
			{
				if (this.Results.Contains("OperationResult"))
				{
					return ((bool)(this.Results["OperationResult"]));
				}
				else
				{
					return default(bool);
				}
			}
			set
			{
				this.Results["OperationResult"] = value;
			}
		}
		
		public string PassedLogicalEntityNames
		{
			get
			{
				if (this.Results.Contains("PassedLogicalEntityNames"))
				{
					return ((string)(this.Results["PassedLogicalEntityNames"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Results["PassedLogicalEntityNames"] = value;
			}
		}
	}
}
#pragma warning restore CS1591
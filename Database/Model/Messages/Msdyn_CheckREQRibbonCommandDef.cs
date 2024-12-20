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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("msdyn_CheckReqRibbonCommandDef")]
	public partial class Msdyn_CheckREQRibbonCommandDefRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string CommandAndEntityList = "CommandAndEntityList";
		}
		
		public const string ActionLogicalName = "msdyn_CheckReqRibbonCommandDef";
		
		public string CommandAndEntityList
		{
			get
			{
				if (this.Parameters.Contains("CommandAndEntityList"))
				{
					return ((string)(this.Parameters["CommandAndEntityList"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["CommandAndEntityList"] = value;
			}
		}
		
		public Msdyn_CheckREQRibbonCommandDefRequest()
		{
			this.RequestName = "msdyn_CheckReqRibbonCommandDef";
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/msdyn/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("msdyn_CheckReqRibbonCommandDef")]
	public partial class Msdyn_CheckREQRibbonCommandDefResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string HelpLink = "HelpLink";
			public const string Message = "Message";
			public const string ResultEntities = "ResultEntities";
			public const string ReturnSeverity = "ReturnSeverity";
			public const string ReturnStatus = "ReturnStatus";
		}
		
		public const string ActionLogicalName = "msdyn_CheckReqRibbonCommandDef";
		
		public Msdyn_CheckREQRibbonCommandDefResponse()
		{
		}
		
		public string HelpLink
		{
			get
			{
				if (this.Results.Contains("HelpLink"))
				{
					return ((string)(this.Results["HelpLink"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Results["HelpLink"] = value;
			}
		}
		
		public string Message
		{
			get
			{
				if (this.Results.Contains("Message"))
				{
					return ((string)(this.Results["Message"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Results["Message"] = value;
			}
		}
		
		public string ResultEntities
		{
			get
			{
				if (this.Results.Contains("ResultEntities"))
				{
					return ((string)(this.Results["ResultEntities"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Results["ResultEntities"] = value;
			}
		}
		
		public int ReturnSeverity
		{
			get
			{
				if (this.Results.Contains("ReturnSeverity"))
				{
					return ((int)(this.Results["ReturnSeverity"]));
				}
				else
				{
					return default(int);
				}
			}
			set
			{
				this.Results["ReturnSeverity"] = value;
			}
		}
		
		public int ReturnStatus
		{
			get
			{
				if (this.Results.Contains("ReturnStatus"))
				{
					return ((int)(this.Results["ReturnStatus"]));
				}
				else
				{
					return default(int);
				}
			}
			set
			{
				this.Results["ReturnStatus"] = value;
			}
		}
	}
}
#pragma warning restore CS1591

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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("msdyn_GetTalkingPoints")]
	public partial class Msdyn_GetTalkingPointsRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string EntityId = "EntityId";
			public const string EntityType = "EntityType";
		}
		
		public const string ActionLogicalName = "msdyn_GetTalkingPoints";
		
		public string EntityId
		{
			get
			{
				if (this.Parameters.Contains("entityId"))
				{
					return ((string)(this.Parameters["entityId"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["entityId"] = value;
			}
		}
		
		public string EntityType
		{
			get
			{
				if (this.Parameters.Contains("entityType"))
				{
					return ((string)(this.Parameters["entityType"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["entityType"] = value;
			}
		}
		
		public Msdyn_GetTalkingPointsRequest()
		{
			this.RequestName = "msdyn_GetTalkingPoints";
			this.EntityId = default(string);
			this.EntityType = default(string);
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/msdyn/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("msdyn_GetTalkingPoints")]
	public partial class Msdyn_GetTalkingPointsResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string Response = "Response";
		}
		
		public const string ActionLogicalName = "msdyn_GetTalkingPoints";
		
		public Msdyn_GetTalkingPointsResponse()
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
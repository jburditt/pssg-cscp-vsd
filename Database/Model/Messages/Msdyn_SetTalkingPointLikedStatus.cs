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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("msdyn_SetTalkingPointLikedStatus")]
	public partial class Msdyn_SetTalkingPointLikedStatusRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string MessageId = "MessageId";
			public const string InferredMessageId = "InferredMessageId";
			public const string IsLiked = "IsLiked";
		}
		
		public const string ActionLogicalName = "msdyn_SetTalkingPointLikedStatus";
		
		public string MessageId
		{
			get
			{
				if (this.Parameters.Contains("MessageId"))
				{
					return ((string)(this.Parameters["MessageId"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["MessageId"] = value;
			}
		}
		
		public string InferredMessageId
		{
			get
			{
				if (this.Parameters.Contains("InferredMessageId"))
				{
					return ((string)(this.Parameters["InferredMessageId"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["InferredMessageId"] = value;
			}
		}
		
		public bool IsLiked
		{
			get
			{
				if (this.Parameters.Contains("IsLiked"))
				{
					return ((bool)(this.Parameters["IsLiked"]));
				}
				else
				{
					return default(bool);
				}
			}
			set
			{
				this.Parameters["IsLiked"] = value;
			}
		}
		
		public Msdyn_SetTalkingPointLikedStatusRequest()
		{
			this.RequestName = "msdyn_SetTalkingPointLikedStatus";
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/msdyn/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("msdyn_SetTalkingPointLikedStatus")]
	public partial class Msdyn_SetTalkingPointLikedStatusResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string IsSuccessFull = "IsSuccessFull";
		}
		
		public const string ActionLogicalName = "msdyn_SetTalkingPointLikedStatus";
		
		public Msdyn_SetTalkingPointLikedStatusResponse()
		{
		}
		
		public bool IsSuccessFull
		{
			get
			{
				if (this.Results.Contains("IsSuccessfull"))
				{
					return ((bool)(this.Results["IsSuccessfull"]));
				}
				else
				{
					return default(bool);
				}
			}
			set
			{
				this.Results["IsSuccessFull"] = value;
			}
		}
	}
}
#pragma warning restore CS1591

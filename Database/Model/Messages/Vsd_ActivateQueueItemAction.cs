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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("vsd_ActivateQueueItemAction")]
	public partial class Vsd_ActivateQueueItemActionRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string QueueId = "QueueId";
			public const string Target = "Target";
		}
		
		public const string ActionLogicalName = "vsd_ActivateQueueItemAction";
		
		public Microsoft.Xrm.Sdk.EntityReference QueueId
		{
			get
			{
				if (this.Parameters.Contains("QueueId"))
				{
					return ((Microsoft.Xrm.Sdk.EntityReference)(this.Parameters["QueueId"]));
				}
				else
				{
					return default(Microsoft.Xrm.Sdk.EntityReference);
				}
			}
			set
			{
				this.Parameters["QueueId"] = value;
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
		
		public Vsd_ActivateQueueItemActionRequest()
		{
			this.RequestName = "vsd_ActivateQueueItemAction";
			this.QueueId = default(Microsoft.Xrm.Sdk.EntityReference);
			this.Target = default(Microsoft.Xrm.Sdk.EntityReference);
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/vsd/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("vsd_ActivateQueueItemAction")]
	public partial class Vsd_ActivateQueueItemActionResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public const string ActionLogicalName = "vsd_ActivateQueueItemAction";
		
		public Vsd_ActivateQueueItemActionResponse()
		{
		}
	}
}
#pragma warning restore CS1591
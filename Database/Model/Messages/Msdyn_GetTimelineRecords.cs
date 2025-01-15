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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("msdyn_GetTimeLineRecords")]
	public partial class Msdyn_GetTimelineRecordsRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string RegardingObjectId = "RegardingObjectId";
			public const string NumberOfRecords = "NumberOfRecords";
		}
		
		public const string ActionLogicalName = "msdyn_GetTimeLineRecords";
		
		public string RegardingObjectId
		{
			get
			{
				if (this.Parameters.Contains("RegardingObjectId"))
				{
					return ((string)(this.Parameters["RegardingObjectId"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["RegardingObjectId"] = value;
			}
		}
		
		public string NumberOfRecords
		{
			get
			{
				if (this.Parameters.Contains("NumberOfRecords"))
				{
					return ((string)(this.Parameters["NumberOfRecords"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["NumberOfRecords"] = value;
			}
		}
		
		public Msdyn_GetTimelineRecordsRequest()
		{
			this.RequestName = "msdyn_GetTimeLineRecords";
			this.RegardingObjectId = default(string);
			this.NumberOfRecords = default(string);
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/msdyn/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("msdyn_GetTimeLineRecords")]
	public partial class Msdyn_GetTimelineRecordsResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string TimelineWallRecords = "TimelineWallRecords";
		}
		
		public const string ActionLogicalName = "msdyn_GetTimeLineRecords";
		
		public Msdyn_GetTimelineRecordsResponse()
		{
		}
		
		public string TimelineWallRecords
		{
			get
			{
				if (this.Results.Contains("TimeLineWallRecords"))
				{
					return ((string)(this.Results["TimeLineWallRecords"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Results["TimelineWallRecords"] = value;
			}
		}
	}
}
#pragma warning restore CS1591

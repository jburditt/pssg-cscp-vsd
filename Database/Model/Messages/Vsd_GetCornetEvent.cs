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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("vsd_GetCORNETEvent")]
	public partial class Vsd_GetCornetEventRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string EventType = "EventType";
			public const string IsHistory = "IsHistory";
			public const string Id = "Id";
			public const string EventId = "EventId";
			public const string Guid = "Guid";
			public const string Username = "Username";
			public const string FullName = "FullName";
			public const string Client = "Client";
			public const string StartDate = "StartDate";
			public const string EndDate = "EndDate";
		}
		
		public const string ActionLogicalName = "vsd_GetCORNETEvent";
		
		public int EventType
		{
			get
			{
				if (this.Parameters.Contains("EventType"))
				{
					return ((int)(this.Parameters["EventType"]));
				}
				else
				{
					return default(int);
				}
			}
			set
			{
				this.Parameters["EventType"] = value;
			}
		}
		
		public bool IsHistory
		{
			get
			{
				if (this.Parameters.Contains("IsHistory"))
				{
					return ((bool)(this.Parameters["IsHistory"]));
				}
				else
				{
					return default(bool);
				}
			}
			set
			{
				this.Parameters["IsHistory"] = value;
			}
		}
		
		public string Id
		{
			get
			{
				if (this.Parameters.Contains("Id"))
				{
					return ((string)(this.Parameters["Id"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["Id"] = value;
			}
		}
		
		public string EventId
		{
			get
			{
				if (this.Parameters.Contains("EventId"))
				{
					return ((string)(this.Parameters["EventId"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["EventId"] = value;
			}
		}
		
		public string Guid
		{
			get
			{
				if (this.Parameters.Contains("Guid"))
				{
					return ((string)(this.Parameters["Guid"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["Guid"] = value;
			}
		}
		
		public string Username
		{
			get
			{
				if (this.Parameters.Contains("UserName"))
				{
					return ((string)(this.Parameters["UserName"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["UserName"] = value;
			}
		}
		
		public string FullName
		{
			get
			{
				if (this.Parameters.Contains("FullName"))
				{
					return ((string)(this.Parameters["FullName"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["FullName"] = value;
			}
		}
		
		public string Client
		{
			get
			{
				if (this.Parameters.Contains("Client"))
				{
					return ((string)(this.Parameters["Client"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["Client"] = value;
			}
		}
		
		public System.DateTime StartDate
		{
			get
			{
				if (this.Parameters.Contains("StartDate"))
				{
					return ((System.DateTime)(this.Parameters["StartDate"]));
				}
				else
				{
					return default(System.DateTime);
				}
			}
			set
			{
				this.Parameters["StartDate"] = value;
			}
		}
		
		public System.DateTime EndDate
		{
			get
			{
				if (this.Parameters.Contains("EndDate"))
				{
					return ((System.DateTime)(this.Parameters["EndDate"]));
				}
				else
				{
					return default(System.DateTime);
				}
			}
			set
			{
				this.Parameters["EndDate"] = value;
			}
		}
		
		public Vsd_GetCornetEventRequest()
		{
			this.RequestName = "vsd_GetCORNETEvent";
			this.EventType = default(int);
			this.Username = default(string);
			this.FullName = default(string);
			this.Client = default(string);
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/vsd/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("vsd_GetCORNETEvent")]
	public partial class Vsd_GetCornetEventResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string IsSuccess = "IsSuccess";
			public const string Result = "Result";
		}
		
		public const string ActionLogicalName = "vsd_GetCORNETEvent";
		
		public Vsd_GetCornetEventResponse()
		{
		}
		
		public bool IsSuccess
		{
			get
			{
				if (this.Results.Contains("IsSuccess"))
				{
					return ((bool)(this.Results["IsSuccess"]));
				}
				else
				{
					return default(bool);
				}
			}
			set
			{
				this.Results["IsSuccess"] = value;
			}
		}
		
		public string Result
		{
			get
			{
				if (this.Results.Contains("Result"))
				{
					return ((string)(this.Results["Result"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Results["Result"] = value;
			}
		}
	}
}
#pragma warning restore CS1591

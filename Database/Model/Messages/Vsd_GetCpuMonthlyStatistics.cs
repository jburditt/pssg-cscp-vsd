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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("vsd_GetCPUMonthlyStatistics")]
	public partial class Vsd_GetCpuMonthlyStatisticsRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string BusinessBcEId = "BusinessBcEId";
			public const string UserBcEId = "UserBcEId";
			public const string Target = "Target";
		}
		
		public const string ActionLogicalName = "vsd_GetCPUMonthlyStatistics";
		
		public string BusinessBcEId
		{
			get
			{
				if (this.Parameters.Contains("BusinessBCeID"))
				{
					return ((string)(this.Parameters["BusinessBCeID"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["BusinessBCeID"] = value;
			}
		}
		
		public string UserBcEId
		{
			get
			{
				if (this.Parameters.Contains("UserBCeID"))
				{
					return ((string)(this.Parameters["UserBCeID"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["UserBCeID"] = value;
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
		
		public Vsd_GetCpuMonthlyStatisticsRequest()
		{
			this.RequestName = "vsd_GetCPUMonthlyStatistics";
			this.BusinessBcEId = default(string);
			this.UserBcEId = default(string);
			this.Target = default(Microsoft.Xrm.Sdk.EntityReference);
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/vsd/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("vsd_GetCPUMonthlyStatistics")]
	public partial class Vsd_GetCpuMonthlyStatisticsResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string BusinessBcEId = "BusinessBcEId";
			public const string ContactCollection = "ContactCollection";
			public const string DataCollection = "DataCollection";
			public const string IsSuccess = "IsSuccess";
			public const string PortalRoles = "PortalRoles";
			public const string ProgramCollection = "ProgramCollection";
			public const string Result = "Result";
			public const string UserBcEId = "UserBcEId";
			public const string UserCollection = "UserCollection";
		}
		
		public const string ActionLogicalName = "vsd_GetCPUMonthlyStatistics";
		
		public Vsd_GetCpuMonthlyStatisticsResponse()
		{
		}
		
		public string BusinessBcEId
		{
			get
			{
				if (this.Results.Contains("Businessbceid"))
				{
					return ((string)(this.Results["Businessbceid"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Results["BusinessBcEId"] = value;
			}
		}
		
		public Microsoft.Xrm.Sdk.EntityCollection ContactCollection
		{
			get
			{
				if (this.Results.Contains("ContactCollection"))
				{
					return ((Microsoft.Xrm.Sdk.EntityCollection)(this.Results["ContactCollection"]));
				}
				else
				{
					return default(Microsoft.Xrm.Sdk.EntityCollection);
				}
			}
			set
			{
				this.Results["ContactCollection"] = value;
			}
		}
		
		public Microsoft.Xrm.Sdk.EntityCollection DataCollection
		{
			get
			{
				if (this.Results.Contains("DataCollection"))
				{
					return ((Microsoft.Xrm.Sdk.EntityCollection)(this.Results["DataCollection"]));
				}
				else
				{
					return default(Microsoft.Xrm.Sdk.EntityCollection);
				}
			}
			set
			{
				this.Results["DataCollection"] = value;
			}
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
		
		public Microsoft.Xrm.Sdk.EntityCollection PortalRoles
		{
			get
			{
				if (this.Results.Contains("PortalRoles"))
				{
					return ((Microsoft.Xrm.Sdk.EntityCollection)(this.Results["PortalRoles"]));
				}
				else
				{
					return default(Microsoft.Xrm.Sdk.EntityCollection);
				}
			}
			set
			{
				this.Results["PortalRoles"] = value;
			}
		}
		
		public Microsoft.Xrm.Sdk.EntityCollection ProgramCollection
		{
			get
			{
				if (this.Results.Contains("ProgramCollection"))
				{
					return ((Microsoft.Xrm.Sdk.EntityCollection)(this.Results["ProgramCollection"]));
				}
				else
				{
					return default(Microsoft.Xrm.Sdk.EntityCollection);
				}
			}
			set
			{
				this.Results["ProgramCollection"] = value;
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
		
		public string UserBcEId
		{
			get
			{
				if (this.Results.Contains("Userbceid"))
				{
					return ((string)(this.Results["Userbceid"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Results["UserBcEId"] = value;
			}
		}
		
		public Microsoft.Xrm.Sdk.EntityCollection UserCollection
		{
			get
			{
				if (this.Results.Contains("UserCollection"))
				{
					return ((Microsoft.Xrm.Sdk.EntityCollection)(this.Results["UserCollection"]));
				}
				else
				{
					return default(Microsoft.Xrm.Sdk.EntityCollection);
				}
			}
			set
			{
				this.Results["UserCollection"] = value;
			}
		}
	}
}
#pragma warning restore CS1591

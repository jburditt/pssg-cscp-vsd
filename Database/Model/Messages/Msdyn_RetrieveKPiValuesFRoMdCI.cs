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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("msdyn_RetrieveKPIvaluesfromDCI")]
	public partial class Msdyn_RetrieveKPiValuesFRoMdCIRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string CrmRecord = "CrmRecord";
			public const string KPiNameFilterMap = "KPiNameFilterMap";
			public const string SimilarEntities = "SimilarEntities";
		}
		
		public const string ActionLogicalName = "msdyn_RetrieveKPIvaluesfromDCI";
		
		public Microsoft.Xrm.Sdk.EntityReference CrmRecord
		{
			get
			{
				if (this.Parameters.Contains("CrmRecord"))
				{
					return ((Microsoft.Xrm.Sdk.EntityReference)(this.Parameters["CrmRecord"]));
				}
				else
				{
					return default(Microsoft.Xrm.Sdk.EntityReference);
				}
			}
			set
			{
				this.Parameters["CrmRecord"] = value;
			}
		}
		
		public string KPiNameFilterMap
		{
			get
			{
				if (this.Parameters.Contains("KPINameFilterMap"))
				{
					return ((string)(this.Parameters["KPINameFilterMap"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["KPINameFilterMap"] = value;
			}
		}
		
		public string SimilarEntities
		{
			get
			{
				if (this.Parameters.Contains("SimilarEntities"))
				{
					return ((string)(this.Parameters["SimilarEntities"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["SimilarEntities"] = value;
			}
		}
		
		public Msdyn_RetrieveKPiValuesFRoMdCIRequest()
		{
			this.RequestName = "msdyn_RetrieveKPIvaluesfromDCI";
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/msdyn/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("msdyn_RetrieveKPIvaluesfromDCI")]
	public partial class Msdyn_RetrieveKPiValuesFRoMdCIResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string Errors = "Errors";
			public const string KPiValues = "KPiValues";
		}
		
		public const string ActionLogicalName = "msdyn_RetrieveKPIvaluesfromDCI";
		
		public Msdyn_RetrieveKPiValuesFRoMdCIResponse()
		{
		}
		
		public string Errors
		{
			get
			{
				if (this.Results.Contains("Errors"))
				{
					return ((string)(this.Results["Errors"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Results["Errors"] = value;
			}
		}
		
		public string KPiValues
		{
			get
			{
				if (this.Results.Contains("KPIValues"))
				{
					return ((string)(this.Results["KPIValues"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Results["KPiValues"] = value;
			}
		}
	}
}
#pragma warning restore CS1591
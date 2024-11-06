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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("vsd_CreateRestitutionCase")]
	public partial class Vsd_CreateRestitutionCaseRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string Application = "Application";
			public const string CourtInfoCollection = "CourtInfoCollection";
			public const string ProviderCollection = "ProviderCollection";
			public const string DocumentCollection = "DocumentCollection";
		}
		
		public const string ActionLogicalName = "vsd_CreateRestitutionCase";
		
		public Microsoft.Xrm.Sdk.Entity Application
		{
			get
			{
				if (this.Parameters.Contains("Application"))
				{
					return ((Microsoft.Xrm.Sdk.Entity)(this.Parameters["Application"]));
				}
				else
				{
					return default(Microsoft.Xrm.Sdk.Entity);
				}
			}
			set
			{
				this.Parameters["Application"] = value;
			}
		}
		
		public Microsoft.Xrm.Sdk.EntityCollection CourtInfoCollection
		{
			get
			{
				if (this.Parameters.Contains("CourtInfoCollection"))
				{
					return ((Microsoft.Xrm.Sdk.EntityCollection)(this.Parameters["CourtInfoCollection"]));
				}
				else
				{
					return default(Microsoft.Xrm.Sdk.EntityCollection);
				}
			}
			set
			{
				this.Parameters["CourtInfoCollection"] = value;
			}
		}
		
		public Microsoft.Xrm.Sdk.EntityCollection ProviderCollection
		{
			get
			{
				if (this.Parameters.Contains("ProviderCollection"))
				{
					return ((Microsoft.Xrm.Sdk.EntityCollection)(this.Parameters["ProviderCollection"]));
				}
				else
				{
					return default(Microsoft.Xrm.Sdk.EntityCollection);
				}
			}
			set
			{
				this.Parameters["ProviderCollection"] = value;
			}
		}
		
		public Microsoft.Xrm.Sdk.EntityCollection DocumentCollection
		{
			get
			{
				if (this.Parameters.Contains("DocumentCollection"))
				{
					return ((Microsoft.Xrm.Sdk.EntityCollection)(this.Parameters["DocumentCollection"]));
				}
				else
				{
					return default(Microsoft.Xrm.Sdk.EntityCollection);
				}
			}
			set
			{
				this.Parameters["DocumentCollection"] = value;
			}
		}
		
		public Vsd_CreateRestitutionCaseRequest()
		{
			this.RequestName = "vsd_CreateRestitutionCase";
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/vsd/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("vsd_CreateRestitutionCase")]
	public partial class Vsd_CreateRestitutionCaseResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string IsSuccess = "IsSuccess";
			public const string Result = "Result";
		}
		
		public const string ActionLogicalName = "vsd_CreateRestitutionCase";
		
		public Vsd_CreateRestitutionCaseResponse()
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
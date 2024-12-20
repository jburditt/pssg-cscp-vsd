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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("vsd_CreateContact")]
	public partial class Vsd_CreateContactRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string IsVictim = "IsVictim";
			public const string UpdateContact = "UpdateContact";
			public const string Target = "Target";
		}
		
		public const string ActionLogicalName = "vsd_CreateContact";
		
		public bool IsVictim
		{
			get
			{
				if (this.Parameters.Contains("IsVictim"))
				{
					return ((bool)(this.Parameters["IsVictim"]));
				}
				else
				{
					return default(bool);
				}
			}
			set
			{
				this.Parameters["IsVictim"] = value;
			}
		}
		
		public string UpdateContact
		{
			get
			{
				if (this.Parameters.Contains("UpdateContact"))
				{
					return ((string)(this.Parameters["UpdateContact"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["UpdateContact"] = value;
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
		
		public Vsd_CreateContactRequest()
		{
			this.RequestName = "vsd_CreateContact";
			this.IsVictim = default(bool);
			this.Target = default(Microsoft.Xrm.Sdk.EntityReference);
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/vsd/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("vsd_CreateContact")]
	public partial class Vsd_CreateContactResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string ContactId = "ContactId";
			public const string IsDuplicateFound = "IsDuplicateFound";
			public const string IsMultipleDuplicateFound = "IsMultipleDuplicateFound";
			public const string IsSuccess = "IsSuccess";
			public const string Result = "Result";
		}
		
		public const string ActionLogicalName = "vsd_CreateContact";
		
		public Vsd_CreateContactResponse()
		{
		}
		
		public Microsoft.Xrm.Sdk.EntityReference ContactId
		{
			get
			{
				if (this.Results.Contains("ContactId"))
				{
					return ((Microsoft.Xrm.Sdk.EntityReference)(this.Results["ContactId"]));
				}
				else
				{
					return default(Microsoft.Xrm.Sdk.EntityReference);
				}
			}
			set
			{
				this.Results["ContactId"] = value;
			}
		}
		
		public bool IsDuplicateFound
		{
			get
			{
				if (this.Results.Contains("IsDuplicateFound"))
				{
					return ((bool)(this.Results["IsDuplicateFound"]));
				}
				else
				{
					return default(bool);
				}
			}
			set
			{
				this.Results["IsDuplicateFound"] = value;
			}
		}
		
		public bool IsMultipleDuplicateFound
		{
			get
			{
				if (this.Results.Contains("IsMultipleDuplicateFound"))
				{
					return ((bool)(this.Results["IsMultipleDuplicateFound"]));
				}
				else
				{
					return default(bool);
				}
			}
			set
			{
				this.Results["IsMultipleDuplicateFound"] = value;
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

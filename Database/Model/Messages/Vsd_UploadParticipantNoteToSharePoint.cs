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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("vsd_UploadParticipantNoteToSharePoint")]
	public partial class Vsd_UploadParticipantNoteToSharePointRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string Tag1 = "Tag1";
			public const string Tag2 = "Tag2";
			public const string Tag3 = "Tag3";
			public const string Target = "Target";
		}
		
		public const string ActionLogicalName = "vsd_UploadParticipantNoteToSharePoint";
		
		public Microsoft.Xrm.Sdk.EntityReference Tag1
		{
			get
			{
				if (this.Parameters.Contains("Tag1"))
				{
					return ((Microsoft.Xrm.Sdk.EntityReference)(this.Parameters["Tag1"]));
				}
				else
				{
					return default(Microsoft.Xrm.Sdk.EntityReference);
				}
			}
			set
			{
				this.Parameters["Tag1"] = value;
			}
		}
		
		public Microsoft.Xrm.Sdk.EntityReference Tag2
		{
			get
			{
				if (this.Parameters.Contains("Tag2"))
				{
					return ((Microsoft.Xrm.Sdk.EntityReference)(this.Parameters["Tag2"]));
				}
				else
				{
					return default(Microsoft.Xrm.Sdk.EntityReference);
				}
			}
			set
			{
				this.Parameters["Tag2"] = value;
			}
		}
		
		public Microsoft.Xrm.Sdk.EntityReference Tag3
		{
			get
			{
				if (this.Parameters.Contains("Tag3"))
				{
					return ((Microsoft.Xrm.Sdk.EntityReference)(this.Parameters["Tag3"]));
				}
				else
				{
					return default(Microsoft.Xrm.Sdk.EntityReference);
				}
			}
			set
			{
				this.Parameters["Tag3"] = value;
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
		
		public Vsd_UploadParticipantNoteToSharePointRequest()
		{
			this.RequestName = "vsd_UploadParticipantNoteToSharePoint";
			this.Target = default(Microsoft.Xrm.Sdk.EntityReference);
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/vsd/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("vsd_UploadParticipantNoteToSharePoint")]
	public partial class Vsd_UploadParticipantNoteToSharePointResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string IsSuccess = "IsSuccess";
			public const string Result = "Result";
		}
		
		public const string ActionLogicalName = "vsd_UploadParticipantNoteToSharePoint";
		
		public Vsd_UploadParticipantNoteToSharePointResponse()
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

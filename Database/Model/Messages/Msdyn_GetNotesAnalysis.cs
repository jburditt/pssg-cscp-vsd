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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("msdyn_GetNotesAnalysis")]
	public partial class Msdyn_GetNotesAnalysisRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string NoteText = "NoteText";
		}
		
		public const string ActionLogicalName = "msdyn_GetNotesAnalysis";
		
		public string NoteText
		{
			get
			{
				if (this.Parameters.Contains("NoteText"))
				{
					return ((string)(this.Parameters["NoteText"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["NoteText"] = value;
			}
		}
		
		public Msdyn_GetNotesAnalysisRequest()
		{
			this.RequestName = "msdyn_GetNotesAnalysis";
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/msdyn/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("msdyn_GetNotesAnalysis")]
	public partial class Msdyn_GetNotesAnalysisResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string IsSuccess = "IsSuccess";
			public const string NotesAnalysisResult = "NotesAnalysisResult";
		}
		
		public const string ActionLogicalName = "msdyn_GetNotesAnalysis";
		
		public Msdyn_GetNotesAnalysisResponse()
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
		
		public string NotesAnalysisResult
		{
			get
			{
				if (this.Results.Contains("NotesAnalysisResult"))
				{
					return ((string)(this.Results["NotesAnalysisResult"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Results["NotesAnalysisResult"] = value;
			}
		}
	}
}
#pragma warning restore CS1591
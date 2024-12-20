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
	
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011//")]
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("RecognizeText")]
	public partial class RecognizeTextRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string ModelId = "ModelId";
			public const string Base64Encoded = "Base64Encoded";
		}
		
		public const string ActionLogicalName = "RecognizeText";
		
		public string ModelId
		{
			get
			{
				if (this.Parameters.Contains("modelId"))
				{
					return ((string)(this.Parameters["modelId"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["modelId"] = value;
			}
		}
		
		public string Base64Encoded
		{
			get
			{
				if (this.Parameters.Contains("base64encoded"))
				{
					return ((string)(this.Parameters["base64encoded"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["base64encoded"] = value;
			}
		}
		
		public RecognizeTextRequest()
		{
			this.RequestName = "RecognizeText";
			this.Base64Encoded = default(string);
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011//")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("RecognizeText")]
	public partial class RecognizeTextResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string CountOfPages = "CountOfPages";
			public const string Pages = "Pages";
		}
		
		public const string ActionLogicalName = "RecognizeText";
		
		public RecognizeTextResponse()
		{
		}
		
		public decimal CountOfPages
		{
			get
			{
				if (this.Results.Contains("countOfPages"))
				{
					return ((decimal)(this.Results["countOfPages"]));
				}
				else
				{
					return default(decimal);
				}
			}
			set
			{
				this.Results["CountOfPages"] = value;
			}
		}
		
		public Microsoft.Xrm.Sdk.EntityCollection Pages
		{
			get
			{
				if (this.Results.Contains("pages"))
				{
					return ((Microsoft.Xrm.Sdk.EntityCollection)(this.Results["pages"]));
				}
				else
				{
					return default(Microsoft.Xrm.Sdk.EntityCollection);
				}
			}
			set
			{
				this.Results["Pages"] = value;
			}
		}
	}
}
#pragma warning restore CS1591

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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("msdyn_Feedback")]
	public partial class Msdyn_FeedbackRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string FeatureName = "FeatureName";
			public const string Value = "Value";
			public const string Description = "Description";
			public const string Properties = "Properties";
		}
		
		public const string ActionLogicalName = "msdyn_Feedback";
		
		public string FeatureName
		{
			get
			{
				if (this.Parameters.Contains("FeatureName"))
				{
					return ((string)(this.Parameters["FeatureName"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["FeatureName"] = value;
			}
		}
		
		public int Value
		{
			get
			{
				if (this.Parameters.Contains("Value"))
				{
					return ((int)(this.Parameters["Value"]));
				}
				else
				{
					return default(int);
				}
			}
			set
			{
				this.Parameters["Value"] = value;
			}
		}
		
		public string Description
		{
			get
			{
				if (this.Parameters.Contains("Description"))
				{
					return ((string)(this.Parameters["Description"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["Description"] = value;
			}
		}
		
		public string Properties
		{
			get
			{
				if (this.Parameters.Contains("Properties"))
				{
					return ((string)(this.Parameters["Properties"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["Properties"] = value;
			}
		}
		
		public Msdyn_FeedbackRequest()
		{
			this.RequestName = "msdyn_Feedback";
			this.FeatureName = default(string);
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/msdyn/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("msdyn_Feedback")]
	public partial class Msdyn_FeedbackResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public const string ActionLogicalName = "msdyn_Feedback";
		
		public Msdyn_FeedbackResponse()
		{
		}
	}
}
#pragma warning restore CS1591
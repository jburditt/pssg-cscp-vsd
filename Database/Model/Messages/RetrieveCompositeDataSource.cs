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
	
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/crm/2011/Contracts")]
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("RetrieveCompositeDataSource")]
	public partial class RetrieveCompositeDataSourceRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string ChildSchemaName = "ChildSchemaName";
			public const string ParentSchemaName = "ParentSchemaName";
		}
		
		public const string ActionLogicalName = "RetrieveCompositeDataSource";
		
		public string ChildSchemaName
		{
			get
			{
				if (this.Parameters.Contains("ChildSchemaName"))
				{
					return ((string)(this.Parameters["ChildSchemaName"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["ChildSchemaName"] = value;
			}
		}
		
		public string ParentSchemaName
		{
			get
			{
				if (this.Parameters.Contains("ParentSchemaName"))
				{
					return ((string)(this.Parameters["ParentSchemaName"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["ParentSchemaName"] = value;
			}
		}
		
		public RetrieveCompositeDataSourceRequest()
		{
			this.RequestName = "RetrieveCompositeDataSource";
			this.ChildSchemaName = default(string);
			this.ParentSchemaName = default(string);
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/crm/2011/Contracts")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("RetrieveCompositeDataSource")]
	public partial class RetrieveCompositeDataSourceResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string EntityCollection = "EntityCollection";
		}
		
		public const string ActionLogicalName = "RetrieveCompositeDataSource";
		
		public RetrieveCompositeDataSourceResponse()
		{
		}
		
		public Microsoft.Xrm.Sdk.EntityCollection EntityCollection
		{
			get
			{
				if (this.Results.Contains("EntityCollection"))
				{
					return ((Microsoft.Xrm.Sdk.EntityCollection)(this.Results["EntityCollection"]));
				}
				else
				{
					return default(Microsoft.Xrm.Sdk.EntityCollection);
				}
			}
			set
			{
				this.Results["EntityCollection"] = value;
			}
		}
	}
}
#pragma warning restore CS1591

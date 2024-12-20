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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("UpsertCompositeDataSource")]
	public partial class UpsertCompositeDataSourceRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string ParentValue = "ParentValue";
			public const string ParentConnectionId = "ParentConnectionId";
			public const string ChildValue = "ChildValue";
			public const string ChildSchemaName = "ChildSchemaName";
			public const string ChildDataSourceType = "ChildDataSourceType";
			public const string ParentDataSourceType = "ParentDataSourceType";
			public const string ParentSchemaName = "ParentSchemaName";
		}
		
		public const string ActionLogicalName = "UpsertCompositeDataSource";
		
		public string ParentValue
		{
			get
			{
				if (this.Parameters.Contains("ParentValue"))
				{
					return ((string)(this.Parameters["ParentValue"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["ParentValue"] = value;
			}
		}
		
		public string ParentConnectionId
		{
			get
			{
				if (this.Parameters.Contains("ParentConnectionId"))
				{
					return ((string)(this.Parameters["ParentConnectionId"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["ParentConnectionId"] = value;
			}
		}
		
		public string ChildValue
		{
			get
			{
				if (this.Parameters.Contains("ChildValue"))
				{
					return ((string)(this.Parameters["ChildValue"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["ChildValue"] = value;
			}
		}
		
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
		
		public string ChildDataSourceType
		{
			get
			{
				if (this.Parameters.Contains("ChildDataSourceType"))
				{
					return ((string)(this.Parameters["ChildDataSourceType"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["ChildDataSourceType"] = value;
			}
		}
		
		public string ParentDataSourceType
		{
			get
			{
				if (this.Parameters.Contains("ParentDataSourceType"))
				{
					return ((string)(this.Parameters["ParentDataSourceType"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["ParentDataSourceType"] = value;
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
		
		public UpsertCompositeDataSourceRequest()
		{
			this.RequestName = "UpsertCompositeDataSource";
			this.ParentDataSourceType = default(string);
			this.ParentSchemaName = default(string);
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/crm/2011/Contracts")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("UpsertCompositeDataSource")]
	public partial class UpsertCompositeDataSourceResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public const string ActionLogicalName = "UpsertCompositeDataSource";
		
		public UpsertCompositeDataSourceResponse()
		{
		}
	}
}
#pragma warning restore CS1591

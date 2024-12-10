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
	
	
	/// <summary>
	/// Information about team membership type.
	/// </summary>
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Team_MembershipType
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Guests", 3)]
		Guests = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Members", 1)]
		Members = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Members and guests", 0)]
		MembersAndGuests = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Owners", 2)]
		Owners = 2,
	}
	
	/// <summary>
	/// Information about team type.
	/// </summary>
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Team_TeamType
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("AAD Office Group", 3)]
		AadOfficeGroup = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("AAD Security Group", 2)]
		AadSecurityGroup = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Access", 1)]
		Access = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Owner", 0)]
		Owner = 0,
	}
	
	/// <summary>
	/// Collection of system users that routinely collaborate. Teams can be used to simplify record sharing and provide team members with common access to organization data when team members belong to different Business Units.
	/// </summary>
	[System.Runtime.Serialization.DataContractAttribute()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("team")]
	public partial class Team : Microsoft.Xrm.Sdk.Entity
	{
		
		/// <summary>
		/// Available fields, a the time of codegen, for the team entity
		/// </summary>
		public partial class Fields
		{
			public const string AdministratorId = "administratorid";
			public const string AdministratorIdName = "administratoridname";
			public const string AdministratorIdYomiName = "administratoridyominame";
			public const string AzureActiveDirectoryObjectId = "azureactivedirectoryobjectid";
			public const string BusinessUnitId = "businessunitid";
			public const string BusinessUnitIdName = "businessunitidname";
			public const string CreatedBy = "createdby";
			public const string CreatedByName = "createdbyname";
			public const string CreatedByYomiName = "createdbyyominame";
			public const string CreatedOn = "createdon";
			public const string CreatedOnBehalfBy = "createdonbehalfby";
			public const string CreatedOnBehalfByName = "createdonbehalfbyname";
			public const string CreatedOnBehalfByYomiName = "createdonbehalfbyyominame";
			public const string Description = "description";
			public const string EmailAddress = "emailaddress";
			public const string ExchangerAte = "exchangerate";
			public const string ImportSequenceNumber = "importsequencenumber";
			public const string IsDefault = "isdefault";
			public const string IsDefaultName = "isdefaultname";
			public const string Lk_Team_CreatedOnBehalfBy = "lk_team_createdonbehalfby";
			public const string Lk_Team_ModifiedOnBehalfBy = "lk_team_modifiedonbehalfby";
			public const string Lk_TeamBase_AdministratorId = "lk_teambase_administratorid";
			public const string Lk_TeamBase_CreatedBy = "lk_teambase_createdby";
			public const string Lk_TeamBase_ModifiedBy = "lk_teambase_modifiedby";
			public const string MembershipType = "membershiptype";
			public const string MembershipTypeName = "membershiptypename";
			public const string ModifiedBy = "modifiedby";
			public const string ModifiedByName = "modifiedbyname";
			public const string ModifiedByYomiName = "modifiedbyyominame";
			public const string ModifiedOn = "modifiedon";
			public const string ModifiedOnBehalfBy = "modifiedonbehalfby";
			public const string ModifiedOnBehalfByName = "modifiedonbehalfbyname";
			public const string ModifiedOnBehalfByYomiName = "modifiedonbehalfbyyominame";
			public const string Name = "name";
			public const string OrganizationId = "organizationid";
			public const string OrganizationIdName = "organizationidname";
			public const string OverriddenCreatedOn = "overriddencreatedon";
			public const string ProcessId = "processid";
			public const string QueueId = "queueid";
			public const string QueueIdName = "queueidname";
			public const string RegardingObjectId = "regardingobjectid";
			public const string StageId = "stageid";
			public const string SystemManaged = "systemmanaged";
			public const string SystemManagedName = "systemmanagedname";
			public const string Team_Accounts = "Team_Accounts";
			public const string Team_Contacts = "Team_Contacts";
			public const string Team_Task = "Team_Task";
			public const string Team_Vsd_Contract = "Team_Vsd_Contract";
			public const string Team_Vsd_Entitlement = "Team_Vsd_Entitlement";
			public const string Team_Vsd_Invoice = "Team_Vsd_Invoice";
			public const string Team_Vsd_InvoiceLineDetail = "Team_Vsd_InvoiceLineDetail";
			public const string Team_Vsd_Payment = "Team_Vsd_Payment";
			public const string Team_Vsd_PaymentSchedule = "Team_Vsd_PaymentSchedule";
			public const string Team_Vsd_Program = "Team_Vsd_Program";
			public const string Team_Vsd_ScheduleG = "Team_Vsd_ScheduleG";
			public const string TeamId = "teamid";
			public const string Id = "teamid";
			public const string TeamMembership_Association = "teammembership_association";
			public const string TeamTemplateId = "teamtemplateid";
			public const string TeamType = "teamtype";
			public const string TeamTypeName = "teamtypename";
			public const string TransactionCurrency_Team = "TransactionCurrency_Team";
			public const string TransactionCurrencyId = "transactioncurrencyid";
			public const string TransactionCurrencyIdName = "transactioncurrencyidname";
			public const string TraversedPath = "traversedpath";
			public const string VersionNumber = "versionnumber";
			public const string YomiName = "yominame";
		}
		
		[System.Diagnostics.DebuggerNonUserCode()]
		public Team(System.Guid id) : 
				base(EntityLogicalName, id)
		{
		}
		
		[System.Diagnostics.DebuggerNonUserCode()]
		public Team(string keyName, object keyValue) : 
				base(EntityLogicalName, keyName, keyValue)
		{
		}
		
		[System.Diagnostics.DebuggerNonUserCode()]
		public Team(Microsoft.Xrm.Sdk.KeyAttributeCollection keyAttributes) : 
				base(EntityLogicalName, keyAttributes)
		{
		}
		
		public const string AlternateKeys = "azureactivedirectoryobjectid,membershiptype";
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCode()]
		public Team() : 
				base(EntityLogicalName)
		{
		}
		
		public const string PrimaryIdAttribute = "teamid";
		
		public const string PrimaryNameAttribute = "name";
		
		public const string EntitySchemaName = "Team";
		
		public const string EntityLogicalName = "team";
		
		public const string EntityLogicalCollectionName = "teams";
		
		public const string EntitySetName = "teams";
		
		/// <summary>
		/// Unique identifier of the user primary responsible for the team.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("administratorid")]
		public Microsoft.Xrm.Sdk.EntityReference AdministratorId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("administratorid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("administratorid", value);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("administratoridname")]
		public string AdministratorIdName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("administratorid"))
				{
					return this.FormattedValues["administratorid"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("administratoridyominame")]
		public string AdministratorIdYomiName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("administratorid"))
				{
					return this.FormattedValues["administratorid"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// The Azure active directory object Id for a group.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("azureactivedirectoryobjectid")]
		public System.Nullable<System.Guid> AzureActiveDirectoryObjectId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("azureactivedirectoryobjectid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("azureactivedirectoryobjectid", value);
			}
		}
		
		/// <summary>
		/// Unique identifier of the business unit with which the team is associated.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("businessunitid")]
		public Microsoft.Xrm.Sdk.EntityReference BusinessUnitId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("businessunitid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("businessunitid", value);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("businessunitidname")]
		public string BusinessUnitIdName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("businessunitid"))
				{
					return this.FormattedValues["businessunitid"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// Unique identifier of the user who created the team.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
		public Microsoft.Xrm.Sdk.EntityReference CreatedBy
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdbyname")]
		public string CreatedByName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("createdby"))
				{
					return this.FormattedValues["createdby"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdbyyominame")]
		public string CreatedByYomiName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("createdby"))
				{
					return this.FormattedValues["createdby"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// Date and time when the team was created.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
		public System.Nullable<System.DateTime> CreatedOn
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
			}
		}
		
		/// <summary>
		/// Unique identifier of the delegate user who created the team.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
		public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("createdonbehalfby", value);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfbyname")]
		public string CreatedOnBehalfByName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("createdonbehalfby"))
				{
					return this.FormattedValues["createdonbehalfby"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfbyyominame")]
		public string CreatedOnBehalfByYomiName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("createdonbehalfby"))
				{
					return this.FormattedValues["createdonbehalfby"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// Description of the team.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("description")]
		public string Description
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("description");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("description", value);
			}
		}
		
		/// <summary>
		/// Email address for the team.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("emailaddress")]
		public string EmailAddress
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("emailaddress");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("emailaddress", value);
			}
		}
		
		/// <summary>
		/// Exchange rate for the currency associated with the team with respect to the base currency.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("exchangerate")]
		public System.Nullable<decimal> ExchangerAte
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<decimal>>("exchangerate");
			}
		}
		
		/// <summary>
		/// Unique identifier of the data import or data migration that created this record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("importsequencenumber")]
		public System.Nullable<int> ImportSequenceNumber
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("importsequencenumber");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("importsequencenumber", value);
			}
		}
		
		/// <summary>
		/// Information about whether the team is a default business unit team.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isdefault")]
		public System.Nullable<bool> IsDefault
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("isdefault");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isdefaultname")]
		public string IsDefaultName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("isdefault"))
				{
					return this.FormattedValues["isdefault"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("membershiptype")]
		public virtual Team_MembershipType? MembershipType
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return ((Team_MembershipType?)(EntityOptionSetEnum.GetEnum(this, "membershiptype")));
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("membershiptype", value.HasValue ? new Microsoft.Xrm.Sdk.OptionSetValue((int)value) : null);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("membershiptypename")]
		public string MembershipTypeName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("membershiptype"))
				{
					return this.FormattedValues["membershiptype"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// Unique identifier of the user who last modified the team.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
		public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedbyname")]
		public string ModifiedByName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("modifiedby"))
				{
					return this.FormattedValues["modifiedby"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedbyyominame")]
		public string ModifiedByYomiName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("modifiedby"))
				{
					return this.FormattedValues["modifiedby"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// Date and time when the team was last modified.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
		public System.Nullable<System.DateTime> ModifiedOn
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
			}
		}
		
		/// <summary>
		/// Unique identifier of the delegate user who last modified the team.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
		public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("modifiedonbehalfby", value);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfbyname")]
		public string ModifiedOnBehalfByName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("modifiedonbehalfby"))
				{
					return this.FormattedValues["modifiedonbehalfby"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfbyyominame")]
		public string ModifiedOnBehalfByYomiName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("modifiedonbehalfby"))
				{
					return this.FormattedValues["modifiedonbehalfby"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// Name of the team.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("name")]
		public string Name
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("name");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("name", value);
			}
		}
		
		/// <summary>
		/// Unique identifier of the organization associated with the team.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
		public System.Nullable<System.Guid> OrganizationId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("organizationid");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationidname")]
		public string OrganizationIdName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("organizationid"))
				{
					return this.FormattedValues["organizationid"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// Date and time that the record was migrated.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overriddencreatedon")]
		public System.Nullable<System.DateTime> OverriddenCreatedOn
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("overriddencreatedon");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("overriddencreatedon", value);
			}
		}
		
		/// <summary>
		/// Shows the ID of the process.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("processid")]
		public System.Nullable<System.Guid> ProcessId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("processid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("processid", value);
			}
		}
		
		/// <summary>
		/// Unique identifier of the default queue for the team.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("queueid")]
		public Microsoft.Xrm.Sdk.EntityReference QueueId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("queueid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("queueid", value);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("queueidname")]
		public string QueueIdName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("queueid"))
				{
					return this.FormattedValues["queueid"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// Choose the record that the team relates to.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("regardingobjectid")]
		public Microsoft.Xrm.Sdk.EntityReference RegardingObjectId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("regardingobjectid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("regardingobjectid", value);
			}
		}
		
		/// <summary>
		/// Shows the ID of the stage.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("stageid")]
		public System.Nullable<System.Guid> StageId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("stageid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("stageid", value);
			}
		}
		
		/// <summary>
		/// Select whether the team will be managed by the system.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("systemmanaged")]
		public System.Nullable<bool> SystemManaged
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("systemmanaged");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("systemmanagedname")]
		public string SystemManagedName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("systemmanaged"))
				{
					return this.FormattedValues["systemmanaged"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// Unique identifier for the team.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("teamid")]
		public System.Nullable<System.Guid> TeamId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("teamid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("teamid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = System.Guid.Empty;
				}
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("teamid")]
		public override System.Guid Id
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return base.Id;
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.TeamId = value;
			}
		}
		
		/// <summary>
		/// Shows the team template that is associated with the team.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("teamtemplateid")]
		public Microsoft.Xrm.Sdk.EntityReference TeamTemplateId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("teamtemplateid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("teamtemplateid", value);
			}
		}
		
		/// <summary>
		/// Select the team type.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("teamtype")]
		public virtual Team_TeamType? TeamType
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return ((Team_TeamType?)(EntityOptionSetEnum.GetEnum(this, "teamtype")));
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("teamtype", value.HasValue ? new Microsoft.Xrm.Sdk.OptionSetValue((int)value) : null);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("teamtypename")]
		public string TeamTypeName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("teamtype"))
				{
					return this.FormattedValues["teamtype"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// Unique identifier of the currency associated with the team.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("transactioncurrencyid")]
		public Microsoft.Xrm.Sdk.EntityReference TransactionCurrencyId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("transactioncurrencyid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("transactioncurrencyid", value);
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("transactioncurrencyidname")]
		public string TransactionCurrencyIdName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				if (this.FormattedValues.Contains("transactioncurrencyid"))
				{
					return this.FormattedValues["transactioncurrencyid"];
				}
				else
				{
					return default(string);
				}
			}
		}
		
		/// <summary>
		/// For internal use only.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("traversedpath")]
		public string TraversedPath
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("traversedpath");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("traversedpath", value);
			}
		}
		
		/// <summary>
		/// Version number of the team.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
		public System.Nullable<long> VersionNumber
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
			}
		}
		
		/// <summary>
		/// Pronunciation of the full name of the team, written in phonetic hiragana or katakana characters.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("yominame")]
		public string YomiName
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("yominame");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetAttributeValue("yominame", value);
			}
		}
		
		/// <summary>
		/// 1:N team_accounts
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("team_accounts")]
		public System.Collections.Generic.IEnumerable<Database.Model.Account> Team_Accounts
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Database.Model.Account>("team_accounts", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetRelatedEntities<Database.Model.Account>("team_accounts", null, value);
			}
		}
		
		/// <summary>
		/// 1:N team_contacts
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("team_contacts")]
		public System.Collections.Generic.IEnumerable<Database.Model.Contact> Team_Contacts
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Database.Model.Contact>("team_contacts", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetRelatedEntities<Database.Model.Contact>("team_contacts", null, value);
			}
		}
		
		/// <summary>
		/// 1:N team_task
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("team_task")]
		public System.Collections.Generic.IEnumerable<Database.Model.Task> Team_Task
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Database.Model.Task>("team_task", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetRelatedEntities<Database.Model.Task>("team_task", null, value);
			}
		}
		
		/// <summary>
		/// 1:N team_vsd_contract
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("team_vsd_contract")]
		public System.Collections.Generic.IEnumerable<Database.Model.Vsd_Contract> Team_Vsd_Contract
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Database.Model.Vsd_Contract>("team_vsd_contract", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetRelatedEntities<Database.Model.Vsd_Contract>("team_vsd_contract", null, value);
			}
		}
		
		/// <summary>
		/// 1:N team_vsd_entitlement
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("team_vsd_entitlement")]
		public System.Collections.Generic.IEnumerable<Database.Model.Vsd_Entitlement> Team_Vsd_Entitlement
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Database.Model.Vsd_Entitlement>("team_vsd_entitlement", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetRelatedEntities<Database.Model.Vsd_Entitlement>("team_vsd_entitlement", null, value);
			}
		}
		
		/// <summary>
		/// 1:N team_vsd_invoice
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("team_vsd_invoice")]
		public System.Collections.Generic.IEnumerable<Database.Model.Vsd_Invoice> Team_Vsd_Invoice
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Database.Model.Vsd_Invoice>("team_vsd_invoice", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetRelatedEntities<Database.Model.Vsd_Invoice>("team_vsd_invoice", null, value);
			}
		}
		
		/// <summary>
		/// 1:N team_vsd_invoicelinedetail
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("team_vsd_invoicelinedetail")]
		public System.Collections.Generic.IEnumerable<Database.Model.Vsd_InvoiceLineDetail> Team_Vsd_InvoiceLineDetail
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Database.Model.Vsd_InvoiceLineDetail>("team_vsd_invoicelinedetail", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetRelatedEntities<Database.Model.Vsd_InvoiceLineDetail>("team_vsd_invoicelinedetail", null, value);
			}
		}
		
		/// <summary>
		/// 1:N team_vsd_payment
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("team_vsd_payment")]
		public System.Collections.Generic.IEnumerable<Database.Model.Vsd_Payment> Team_Vsd_Payment
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Database.Model.Vsd_Payment>("team_vsd_payment", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetRelatedEntities<Database.Model.Vsd_Payment>("team_vsd_payment", null, value);
			}
		}
		
		/// <summary>
		/// 1:N team_vsd_paymentschedule
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("team_vsd_paymentschedule")]
		public System.Collections.Generic.IEnumerable<Database.Model.Vsd_PaymentSchedule> Team_Vsd_PaymentSchedule
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Database.Model.Vsd_PaymentSchedule>("team_vsd_paymentschedule", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetRelatedEntities<Database.Model.Vsd_PaymentSchedule>("team_vsd_paymentschedule", null, value);
			}
		}
		
		/// <summary>
		/// 1:N team_vsd_program
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("team_vsd_program")]
		public System.Collections.Generic.IEnumerable<Database.Model.Vsd_Program> Team_Vsd_Program
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Database.Model.Vsd_Program>("team_vsd_program", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetRelatedEntities<Database.Model.Vsd_Program>("team_vsd_program", null, value);
			}
		}
		
		/// <summary>
		/// 1:N team_vsd_scheduleg
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("team_vsd_scheduleg")]
		public System.Collections.Generic.IEnumerable<Database.Model.Vsd_ScheduleG> Team_Vsd_ScheduleG
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Database.Model.Vsd_ScheduleG>("team_vsd_scheduleg", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetRelatedEntities<Database.Model.Vsd_ScheduleG>("team_vsd_scheduleg", null, value);
			}
		}
		
		/// <summary>
		/// N:N teammembership_association
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("teammembership_association")]
		public System.Collections.Generic.IEnumerable<Database.Model.SystemUser> TeamMembership_Association
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Database.Model.SystemUser>("teammembership_association", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetRelatedEntities<Database.Model.SystemUser>("teammembership_association", null, value);
			}
		}
		
		/// <summary>
		/// N:1 lk_team_createdonbehalfby
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("lk_team_createdonbehalfby")]
		public Database.Model.SystemUser Lk_Team_CreatedOnBehalfBy
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Database.Model.SystemUser>("lk_team_createdonbehalfby", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetRelatedEntity<Database.Model.SystemUser>("lk_team_createdonbehalfby", null, value);
			}
		}
		
		/// <summary>
		/// N:1 lk_team_modifiedonbehalfby
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("lk_team_modifiedonbehalfby")]
		public Database.Model.SystemUser Lk_Team_ModifiedOnBehalfBy
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Database.Model.SystemUser>("lk_team_modifiedonbehalfby", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetRelatedEntity<Database.Model.SystemUser>("lk_team_modifiedonbehalfby", null, value);
			}
		}
		
		/// <summary>
		/// N:1 lk_teambase_administratorid
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("administratorid")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("lk_teambase_administratorid")]
		public Database.Model.SystemUser Lk_TeamBase_AdministratorId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Database.Model.SystemUser>("lk_teambase_administratorid", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetRelatedEntity<Database.Model.SystemUser>("lk_teambase_administratorid", null, value);
			}
		}
		
		/// <summary>
		/// N:1 lk_teambase_createdby
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("lk_teambase_createdby")]
		public Database.Model.SystemUser Lk_TeamBase_CreatedBy
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Database.Model.SystemUser>("lk_teambase_createdby", null);
			}
		}
		
		/// <summary>
		/// N:1 lk_teambase_modifiedby
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("lk_teambase_modifiedby")]
		public Database.Model.SystemUser Lk_TeamBase_ModifiedBy
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Database.Model.SystemUser>("lk_teambase_modifiedby", null);
			}
		}
		
		/// <summary>
		/// N:1 TransactionCurrency_Team
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("transactioncurrencyid")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("TransactionCurrency_Team")]
		public Database.Model.TransactionCurrency TransactionCurrency_Team
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Database.Model.TransactionCurrency>("TransactionCurrency_Team", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.SetRelatedEntity<Database.Model.TransactionCurrency>("TransactionCurrency_Team", null, value);
			}
		}
		
		/// <summary>
		/// Constructor for populating via LINQ queries given a LINQ anonymous type
		/// <param name="anonymousType">LINQ anonymous type.</param>
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCode()]
		public Team(object anonymousType) : 
				this()
		{
            foreach (var p in anonymousType.GetType().GetProperties())
            {
                var value = p.GetValue(anonymousType, null);
                var name = p.Name.ToLower();
            
                if (value != null && name.EndsWith("enum") && value.GetType().BaseType == typeof(System.Enum))
                {
                    value = new Microsoft.Xrm.Sdk.OptionSetValue((int) value);
                    name = name.Remove(name.Length - "enum".Length);
                }
            
                switch (name)
                {
                    case "id":
                        base.Id = (System.Guid)value;
                        Attributes["teamid"] = base.Id;
                        break;
                    case "teamid":
                        var id = (System.Nullable<System.Guid>) value;
                        if(id == null){ continue; }
                        base.Id = id.Value;
                        Attributes[name] = base.Id;
                        break;
                    case "formattedvalues":
                        // Add Support for FormattedValues
                        FormattedValues.AddRange((Microsoft.Xrm.Sdk.FormattedValueCollection)value);
                        break;
                    default:
                        Attributes[name] = value;
                        break;
                }
            }
		}
	}
}
#pragma warning restore CS1591

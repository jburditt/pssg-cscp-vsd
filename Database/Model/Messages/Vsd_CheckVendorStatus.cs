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
	[Microsoft.Xrm.Sdk.Client.RequestProxyAttribute("vsd_CheckVendorStatus")]
	public partial class Vsd_CheckVendorStatusRequest : Microsoft.Xrm.Sdk.OrganizationRequest
	{
		
		public static class Fields
		{
			public const string VendorNumber = "VendorNumber";
			public const string VendorPostalCode = "VendorPostalCode";
			public const string CounselorNumber = "CounselorNumber";
			public const string CounselorLastName = "CounselorLastName";
		}
		
		public const string ActionLogicalName = "vsd_CheckVendorStatus";
		
		public string VendorNumber
		{
			get
			{
				if (this.Parameters.Contains("VendorNumber"))
				{
					return ((string)(this.Parameters["VendorNumber"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["VendorNumber"] = value;
			}
		}
		
		public string VendorPostalCode
		{
			get
			{
				if (this.Parameters.Contains("VendorPostalCode"))
				{
					return ((string)(this.Parameters["VendorPostalCode"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["VendorPostalCode"] = value;
			}
		}
		
		public string CounselorNumber
		{
			get
			{
				if (this.Parameters.Contains("CounselorNumber"))
				{
					return ((string)(this.Parameters["CounselorNumber"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["CounselorNumber"] = value;
			}
		}
		
		public string CounselorLastName
		{
			get
			{
				if (this.Parameters.Contains("CounselorLastName"))
				{
					return ((string)(this.Parameters["CounselorLastName"]));
				}
				else
				{
					return default(string);
				}
			}
			set
			{
				this.Parameters["CounselorLastName"] = value;
			}
		}
		
		public Vsd_CheckVendorStatusRequest()
		{
			this.RequestName = "vsd_CheckVendorStatus";
			this.VendorNumber = default(string);
			this.VendorPostalCode = default(string);
		}
	}
	
	[System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/xrm/2011/vsd/")]
	[Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute("vsd_CheckVendorStatus")]
	public partial class Vsd_CheckVendorStatusResponse : Microsoft.Xrm.Sdk.OrganizationResponse
	{
		
		public static class Fields
		{
			public const string CounsellorLevel = "CounsellorLevel";
			public const string IsSuccess = "IsSuccess";
		}
		
		public const string ActionLogicalName = "vsd_CheckVendorStatus";
		
		public Vsd_CheckVendorStatusResponse()
		{
		}
		
		public int CounsellorLevel
		{
			get
			{
				if (this.Results.Contains("CounsellorLevel"))
				{
					return ((int)(this.Results["CounsellorLevel"]));
				}
				else
				{
					return default(int);
				}
			}
			set
			{
				this.Results["CounsellorLevel"] = value;
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
	}
}
#pragma warning restore CS1591

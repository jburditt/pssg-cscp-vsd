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
	
	
	[System.Runtime.Serialization.DataContractAttribute()]
	public enum Vsd_Cpu_InvoiceTypes
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("(Deprecated)", 2, "#0000ff")]
		Deprecated = 100000002,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("One Time Payment", 1, "#0000ff")]
		OneTimePayment = 100000001,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		[OptionSetMetadataAttribute("Scheduled Payment", 0, "#0000ff")]
		ScheduledPayment = 100000000,
	}
}
#pragma warning restore CS1591

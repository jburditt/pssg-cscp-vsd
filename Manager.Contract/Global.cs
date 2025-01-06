namespace Manager.Contract;

// NOTE these values need to match the Dynamics values and also need to be updated concurrently with Dynamics
// these are brittle and a better solution should be considered
public enum StatusCode
{
    Active = 0,
    Inactive = 1
}

public enum YesNo
{
    No = 100000000,
    Yes = 100000001
}

public enum MethodOfPayment
{
    Cheque = 100000001,
    CreditCard = 100000003,
    Eft = 100000000,
    WireTransfer = 100000002,
}

public enum CpuInvoiceType
{
    Deprecated = 100000002,
    OneTimePayment = 100000001,
    ScheduledPayment = 100000000
}

public enum InvoiceType
{
    CounsCourtPsychEd = 100000000,
    DoNotUseMedicalSessions = 100000002,
    OtherPayments = 100000001
}

public enum ProgramUnit
{
    //[OptionSetMetadataAttribute("CPU", 4, "#0000ff")]
    Cpu = 100000003,

    //[OptionSetMetadataAttribute("CSU", 3, "#0000ff")]
    Csu = 100000002,

    //[OptionSetMetadataAttribute("CVAP", 1, "#0000ff")]
    Cvap = 100000000,

    //[OptionSetMetadataAttribute("Gangs", 6, "#0000ff")]
    Gangs = 100000005,

    //[OptionSetMetadataAttribute("IIPS", 0, "#0000ff")]
    Iips = 100000006,

    //[OptionSetMetadataAttribute("REST", 5, "#0000ff")]
    Rest = 100000004,

    //[OptionSetMetadataAttribute("VSU", 2, "#0000ff")]
    Vsu = 100000001,
}

public enum Quarter
{
    _1StQuarter = 100000000,
    _2NdQuarter = 100000001,
    _3RdQuarter = 100000002,
    _4ThQuarter = 100000003
}
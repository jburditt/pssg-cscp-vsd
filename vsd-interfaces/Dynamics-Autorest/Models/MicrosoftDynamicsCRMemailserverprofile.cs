// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Gov.Jag.VictimServices.Interfaces.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// emailserverprofile
    /// </summary>
    public partial class MicrosoftDynamicsCRMemailserverprofile
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMemailserverprofile class.
        /// </summary>
        public MicrosoftDynamicsCRMemailserverprofile()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMemailserverprofile class.
        /// </summary>
        public MicrosoftDynamicsCRMemailserverprofile(long? lasttesttotalexecutiontime = default(long?), bool? outgoingusessl = default(bool?), string incomingserverlocation = default(string), string outgoingusername = default(string), int? statuscode = default(int?), string incomingusername = default(string), int? outgoingportnumber = default(int?), string outgoingpassword = default(string), int? incomingauthenticationprotocol = default(int?), bool? timeoutmailboxconnection = default(bool?), object entityimage = default(object), bool? moveundeliveredemails = default(bool?), string _createdbyValue = default(string), int? utcconversiontimezonecode = default(int?), bool? isoutgoingpasswordset = default(bool?), string _owneridValue = default(string), string _incomingpartnerapplicationValue = default(string), int? outgoingauthenticationprotocol = default(int?), string _outgoingpartnerapplicationValue = default(string), int? lasttestexecutionstatus = default(int?), int? minpollingintervalinminutes = default(int?), string owneremailaddress = default(string), int? incomingcredentialretrieval = default(int?), System.DateTimeOffset? lastteststarttime = default(System.DateTimeOffset?), int? incomingportnumber = default(int?), System.DateTimeOffset? createdon = default(System.DateTimeOffset?), int? timeoutmailboxconnectionafteramount = default(int?), string emailserverprofileid = default(string), string _modifiedonbehalfbyValue = default(string), bool? outgoinguseimpersonation = default(bool?), int? lastauthorizationstatus = default(int?), int? maxconcurrentconnections = default(int?), string name = default(string), string _organizationidValue = default(string), int? timezoneruleversionnumber = default(int?), string description = default(string), bool? useautodiscover = default(bool?), string _owninguserValue = default(string), bool? sendemailalert = default(bool?), string lasttestrequest = default(string), string defaultserverlocation = default(string), bool? usedefaulttenantid = default(bool?), string entityimageUrl = default(string), bool? outgoingautograntdelegateaccess = default(bool?), bool? incominguseimpersonation = default(bool?), string _modifiedbyValue = default(string), bool? isincomingpasswordset = default(bool?), string _createdonbehalfbyValue = default(string), string incomingpassword = default(string), string entityimageid = default(string), int? statecode = default(int?), bool? usesamesettingsforoutgoingconnections = default(bool?), System.DateTimeOffset? processemailsreceivedafter = default(System.DateTimeOffset?), int? exchangeversion = default(int?), string exchangeonlinetenantid = default(string), bool? incomingusessl = default(bool?), int? lasttestvalidationstatus = default(int?), string _owningteamValue = default(string), string emailservertypename = default(string), string lasttestresponse = default(string), string lastcrmmessage = default(string), int? servertype = default(int?), System.DateTimeOffset? modifiedon = default(System.DateTimeOffset?), long? entityimageTimestamp = default(long?), string outgoingserverlocation = default(string), string _owningbusinessunitValue = default(string), string encodingcodepage = default(string), int? outgoingcredentialretrieval = default(int?), MicrosoftDynamicsCRMsystemuser createdonbehalfby = default(MicrosoftDynamicsCRMsystemuser), MicrosoftDynamicsCRMsystemuser modifiedonbehalfby = default(MicrosoftDynamicsCRMsystemuser), IList<MicrosoftDynamicsCRMmailbox> emailserverprofileMailbox = default(IList<MicrosoftDynamicsCRMmailbox>), IList<MicrosoftDynamicsCRMasyncoperation> emailserverprofileAsyncoperations = default(IList<MicrosoftDynamicsCRMasyncoperation>), MicrosoftDynamicsCRMsystemuser createdby = default(MicrosoftDynamicsCRMsystemuser), MicrosoftDynamicsCRMorganization organizationid = default(MicrosoftDynamicsCRMorganization), MicrosoftDynamicsCRMbusinessunit owningbusinessunit = default(MicrosoftDynamicsCRMbusinessunit), MicrosoftDynamicsCRMteam owningteam = default(MicrosoftDynamicsCRMteam), MicrosoftDynamicsCRMprincipal ownerid = default(MicrosoftDynamicsCRMprincipal), IList<MicrosoftDynamicsCRMbulkdeletefailure> emailserverprofileBulkdeletefailures = default(IList<MicrosoftDynamicsCRMbulkdeletefailure>), IList<MicrosoftDynamicsCRMorganization> emailServerProfileOrganization = default(IList<MicrosoftDynamicsCRMorganization>), MicrosoftDynamicsCRMsystemuser modifiedby = default(MicrosoftDynamicsCRMsystemuser), IList<MicrosoftDynamicsCRMtracelog> tracelogEmailServerProfile = default(IList<MicrosoftDynamicsCRMtracelog>), IList<MicrosoftDynamicsCRMannotation> emailServerProfileAnnotation = default(IList<MicrosoftDynamicsCRMannotation>), IList<MicrosoftDynamicsCRMduplicaterecord> emailserverprofileDuplicatematchingrecord = default(IList<MicrosoftDynamicsCRMduplicaterecord>), IList<MicrosoftDynamicsCRMsyncerror> emailServerProfileSyncErrors = default(IList<MicrosoftDynamicsCRMsyncerror>), IList<MicrosoftDynamicsCRMduplicaterecord> emailserverprofileDuplicatebaserecord = default(IList<MicrosoftDynamicsCRMduplicaterecord>))
        {
            Lasttesttotalexecutiontime = lasttesttotalexecutiontime;
            Outgoingusessl = outgoingusessl;
            Incomingserverlocation = incomingserverlocation;
            Outgoingusername = outgoingusername;
            Statuscode = statuscode;
            Incomingusername = incomingusername;
            Outgoingportnumber = outgoingportnumber;
            Outgoingpassword = outgoingpassword;
            Incomingauthenticationprotocol = incomingauthenticationprotocol;
            Timeoutmailboxconnection = timeoutmailboxconnection;
            Entityimage = entityimage;
            Moveundeliveredemails = moveundeliveredemails;
            this._createdbyValue = _createdbyValue;
            Utcconversiontimezonecode = utcconversiontimezonecode;
            Isoutgoingpasswordset = isoutgoingpasswordset;
            this._owneridValue = _owneridValue;
            this._incomingpartnerapplicationValue = _incomingpartnerapplicationValue;
            Outgoingauthenticationprotocol = outgoingauthenticationprotocol;
            this._outgoingpartnerapplicationValue = _outgoingpartnerapplicationValue;
            Lasttestexecutionstatus = lasttestexecutionstatus;
            Minpollingintervalinminutes = minpollingintervalinminutes;
            Owneremailaddress = owneremailaddress;
            Incomingcredentialretrieval = incomingcredentialretrieval;
            Lastteststarttime = lastteststarttime;
            Incomingportnumber = incomingportnumber;
            Createdon = createdon;
            Timeoutmailboxconnectionafteramount = timeoutmailboxconnectionafteramount;
            Emailserverprofileid = emailserverprofileid;
            this._modifiedonbehalfbyValue = _modifiedonbehalfbyValue;
            Outgoinguseimpersonation = outgoinguseimpersonation;
            Lastauthorizationstatus = lastauthorizationstatus;
            Maxconcurrentconnections = maxconcurrentconnections;
            Name = name;
            this._organizationidValue = _organizationidValue;
            Timezoneruleversionnumber = timezoneruleversionnumber;
            Description = description;
            Useautodiscover = useautodiscover;
            this._owninguserValue = _owninguserValue;
            Sendemailalert = sendemailalert;
            Lasttestrequest = lasttestrequest;
            Defaultserverlocation = defaultserverlocation;
            Usedefaulttenantid = usedefaulttenantid;
            EntityimageUrl = entityimageUrl;
            Outgoingautograntdelegateaccess = outgoingautograntdelegateaccess;
            Incominguseimpersonation = incominguseimpersonation;
            this._modifiedbyValue = _modifiedbyValue;
            Isincomingpasswordset = isincomingpasswordset;
            this._createdonbehalfbyValue = _createdonbehalfbyValue;
            Incomingpassword = incomingpassword;
            Entityimageid = entityimageid;
            Statecode = statecode;
            Usesamesettingsforoutgoingconnections = usesamesettingsforoutgoingconnections;
            Processemailsreceivedafter = processemailsreceivedafter;
            Exchangeversion = exchangeversion;
            Exchangeonlinetenantid = exchangeonlinetenantid;
            Incomingusessl = incomingusessl;
            Lasttestvalidationstatus = lasttestvalidationstatus;
            this._owningteamValue = _owningteamValue;
            Emailservertypename = emailservertypename;
            Lasttestresponse = lasttestresponse;
            Lastcrmmessage = lastcrmmessage;
            Servertype = servertype;
            Modifiedon = modifiedon;
            EntityimageTimestamp = entityimageTimestamp;
            Outgoingserverlocation = outgoingserverlocation;
            this._owningbusinessunitValue = _owningbusinessunitValue;
            Encodingcodepage = encodingcodepage;
            Outgoingcredentialretrieval = outgoingcredentialretrieval;
            Createdonbehalfby = createdonbehalfby;
            Modifiedonbehalfby = modifiedonbehalfby;
            EmailserverprofileMailbox = emailserverprofileMailbox;
            EmailserverprofileAsyncoperations = emailserverprofileAsyncoperations;
            Createdby = createdby;
            Organizationid = organizationid;
            Owningbusinessunit = owningbusinessunit;
            Owningteam = owningteam;
            Ownerid = ownerid;
            EmailserverprofileBulkdeletefailures = emailserverprofileBulkdeletefailures;
            EmailServerProfileOrganization = emailServerProfileOrganization;
            Modifiedby = modifiedby;
            TracelogEmailServerProfile = tracelogEmailServerProfile;
            EmailServerProfileAnnotation = emailServerProfileAnnotation;
            EmailserverprofileDuplicatematchingrecord = emailserverprofileDuplicatematchingrecord;
            EmailServerProfileSyncErrors = emailServerProfileSyncErrors;
            EmailserverprofileDuplicatebaserecord = emailserverprofileDuplicatebaserecord;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lasttesttotalexecutiontime")]
        public long? Lasttesttotalexecutiontime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "outgoingusessl")]
        public bool? Outgoingusessl { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "incomingserverlocation")]
        public string Incomingserverlocation { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "outgoingusername")]
        public string Outgoingusername { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "statuscode")]
        public int? Statuscode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "incomingusername")]
        public string Incomingusername { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "outgoingportnumber")]
        public int? Outgoingportnumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "outgoingpassword")]
        public string Outgoingpassword { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "incomingauthenticationprotocol")]
        public int? Incomingauthenticationprotocol { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "timeoutmailboxconnection")]
        public bool? Timeoutmailboxconnection { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "entityimage")]
        public object Entityimage { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "moveundeliveredemails")]
        public bool? Moveundeliveredemails { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_createdby_value")]
        public string _createdbyValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "utcconversiontimezonecode")]
        public int? Utcconversiontimezonecode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isoutgoingpasswordset")]
        public bool? Isoutgoingpasswordset { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_ownerid_value")]
        public string _owneridValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_incomingpartnerapplication_value")]
        public string _incomingpartnerapplicationValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "outgoingauthenticationprotocol")]
        public int? Outgoingauthenticationprotocol { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_outgoingpartnerapplication_value")]
        public string _outgoingpartnerapplicationValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lasttestexecutionstatus")]
        public int? Lasttestexecutionstatus { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "minpollingintervalinminutes")]
        public int? Minpollingintervalinminutes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "owneremailaddress")]
        public string Owneremailaddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "incomingcredentialretrieval")]
        public int? Incomingcredentialretrieval { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastteststarttime")]
        public System.DateTimeOffset? Lastteststarttime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "incomingportnumber")]
        public int? Incomingportnumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdon")]
        public System.DateTimeOffset? Createdon { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "timeoutmailboxconnectionafteramount")]
        public int? Timeoutmailboxconnectionafteramount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "emailserverprofileid")]
        public string Emailserverprofileid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_modifiedonbehalfby_value")]
        public string _modifiedonbehalfbyValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "outgoinguseimpersonation")]
        public bool? Outgoinguseimpersonation { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastauthorizationstatus")]
        public int? Lastauthorizationstatus { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "maxconcurrentconnections")]
        public int? Maxconcurrentconnections { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_organizationid_value")]
        public string _organizationidValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "timezoneruleversionnumber")]
        public int? Timezoneruleversionnumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "useautodiscover")]
        public bool? Useautodiscover { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_owninguser_value")]
        public string _owninguserValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sendemailalert")]
        public bool? Sendemailalert { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lasttestrequest")]
        public string Lasttestrequest { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "defaultserverlocation")]
        public string Defaultserverlocation { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "usedefaulttenantid")]
        public bool? Usedefaulttenantid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "entityimage_url")]
        public string EntityimageUrl { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "outgoingautograntdelegateaccess")]
        public bool? Outgoingautograntdelegateaccess { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "incominguseimpersonation")]
        public bool? Incominguseimpersonation { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_modifiedby_value")]
        public string _modifiedbyValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isincomingpasswordset")]
        public bool? Isincomingpasswordset { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_createdonbehalfby_value")]
        public string _createdonbehalfbyValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "incomingpassword")]
        public string Incomingpassword { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "entityimageid")]
        public string Entityimageid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "statecode")]
        public int? Statecode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "usesamesettingsforoutgoingconnections")]
        public bool? Usesamesettingsforoutgoingconnections { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "processemailsreceivedafter")]
        public System.DateTimeOffset? Processemailsreceivedafter { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "exchangeversion")]
        public int? Exchangeversion { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "exchangeonlinetenantid")]
        public string Exchangeonlinetenantid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "incomingusessl")]
        public bool? Incomingusessl { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lasttestvalidationstatus")]
        public int? Lasttestvalidationstatus { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_owningteam_value")]
        public string _owningteamValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "emailservertypename")]
        public string Emailservertypename { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lasttestresponse")]
        public string Lasttestresponse { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastcrmmessage")]
        public string Lastcrmmessage { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "servertype")]
        public int? Servertype { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "modifiedon")]
        public System.DateTimeOffset? Modifiedon { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "entityimage_timestamp")]
        public long? EntityimageTimestamp { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "outgoingserverlocation")]
        public string Outgoingserverlocation { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_owningbusinessunit_value")]
        public string _owningbusinessunitValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "encodingcodepage")]
        public string Encodingcodepage { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "outgoingcredentialretrieval")]
        public int? Outgoingcredentialretrieval { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdonbehalfby")]
        public MicrosoftDynamicsCRMsystemuser Createdonbehalfby { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "modifiedonbehalfby")]
        public MicrosoftDynamicsCRMsystemuser Modifiedonbehalfby { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "emailserverprofile_mailbox")]
        public IList<MicrosoftDynamicsCRMmailbox> EmailserverprofileMailbox { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "emailserverprofile_asyncoperations")]
        public IList<MicrosoftDynamicsCRMasyncoperation> EmailserverprofileAsyncoperations { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdby")]
        public MicrosoftDynamicsCRMsystemuser Createdby { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "organizationid")]
        public MicrosoftDynamicsCRMorganization Organizationid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "owningbusinessunit")]
        public MicrosoftDynamicsCRMbusinessunit Owningbusinessunit { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "owningteam")]
        public MicrosoftDynamicsCRMteam Owningteam { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ownerid")]
        public MicrosoftDynamicsCRMprincipal Ownerid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "emailserverprofile_bulkdeletefailures")]
        public IList<MicrosoftDynamicsCRMbulkdeletefailure> EmailserverprofileBulkdeletefailures { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EmailServerProfile_Organization")]
        public IList<MicrosoftDynamicsCRMorganization> EmailServerProfileOrganization { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "modifiedby")]
        public MicrosoftDynamicsCRMsystemuser Modifiedby { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tracelog_EmailServerProfile")]
        public IList<MicrosoftDynamicsCRMtracelog> TracelogEmailServerProfile { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EmailServerProfile_Annotation")]
        public IList<MicrosoftDynamicsCRMannotation> EmailServerProfileAnnotation { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "emailserverprofile_duplicatematchingrecord")]
        public IList<MicrosoftDynamicsCRMduplicaterecord> EmailserverprofileDuplicatematchingrecord { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EmailServerProfile_SyncErrors")]
        public IList<MicrosoftDynamicsCRMsyncerror> EmailServerProfileSyncErrors { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "emailserverprofile_duplicatebaserecord")]
        public IList<MicrosoftDynamicsCRMduplicaterecord> EmailserverprofileDuplicatebaserecord { get; set; }

    }
}

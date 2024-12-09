public class PaymentTests(IMediator mediator, IMessageRequests messageRequests, ILoggerFactory loggerFactory)
{
    private readonly ILogger _logger = loggerFactory.CreateLogger<PaymentScheduleTests>();

    [Fact]
    public async Task Send_Payment_To_CAS()
    {
        var startTime = DateTime.Now;

        var configurationQuery = new ConfigurationQuery();
        configurationQuery.StateCode = StateCode.Active;
        configurationQuery.Group = "CAS";
        var configs = await mediator.Send(configurationQuery);

        var getKeyValueCommand = new GetKeyValueCommand(configs, "ClientKey", "CAS", null);
        var clientKey = await mediator.Send(getKeyValueCommand);
        getKeyValueCommand = new GetKeyValueCommand(configs, "ClientId", "CAS", null);
        var clientId = await mediator.Send(getKeyValueCommand);
        getKeyValueCommand = new GetKeyValueCommand(configs, "InterfaceUrl", "CAS", null);
        var url = await mediator.Send(getKeyValueCommand);

        var paymentQuery = new PaymentQuery();
        paymentQuery.IncludeChildren = true;
        paymentQuery.StateCode = StateCode.Active;
        paymentQuery.StatusCode = PaymentStatusCode.Waiting;
        paymentQuery.BeforeDate = DateTime.Now;
        var payments = await mediator.Send(paymentQuery);

        foreach (var postImageEntity in payments)
        {
            string userMessage = string.Empty;
            HttpClient httpClient = null;
            bool isError = false;
            _logger.LogInformation("Processing Payment: " + postImageEntity.Name);
            if ((DateTime.Now - startTime).TotalSeconds >= 100) //2-limit timer
            {
                break;
            }

            try
            {
                ArgumentNullException.ThrowIfNull(postImageEntity.Payee, "Payee lookup is missing on the payment.");
                ArgumentNullException.ThrowIfNull(postImageEntity.Total, "Payment Total is missing on the payment.");
                ArgumentNullException.ThrowIfNull(postImageEntity.Date, "CAS Payment Date is missing on the payment.");

                //messageRequests.SetState(Vsd_Payment.EntityLogicalName, postImageEntity.Id, (int)StateCode.Active, (int)PaymentStatusCode.Sending); //Sending

                var invoices = await GenerateInvoice(configs, postImageEntity);
                var jsonRequest = JsonConvert.SerializeObject(invoices);

                //Log.AppendLine("Sending Json: " + jsonRequest.ToString());
                //httpClient = new HttpClient();
                //httpClient.DefaultRequestHeaders.Add("clientID", clientId);
                //httpClient.DefaultRequestHeaders.Add("secret", clientKey);
                //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //httpClient.BaseAddress = new Uri(url);
                //httpClient.Timeout = new TimeSpan(1, 0, 0);  // 1 hour timeout 

                //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + "/api/CASAPTransaction");
                //request.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                //HttpResponseMessage response = httpClient.SendAsync(request).Result;

                //            if (response.StatusCode == HttpStatusCode.OK)
                //            {
                //                var httpResponse = response.Content.ReadAsStringAsync().Result;

                //                var jsonReader = System.Runtime.Serialization.Json.JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(httpResponse), new XmlDictionaryReaderQuotas());

                //                var root = XElement.Load(jsonReader);
                //                if (root.Element("CAS-Returned-Messages") != null)
                //                {
                //                    var casReturnedMessages = root.Element("CAS-Returned-Messages");
                //                    if (casReturnedMessages != null)
                //                    {
                //                        if (!(casReturnedMessages.Value.Equals("SUCCEEDED", StringComparison.InvariantCultureIgnoreCase) | casReturnedMessages.Value.Contains("Duplicate Submission")))
                //                            throw new Exception(casReturnedMessages.Value + "\r\n" + jsonRequest);
                //                    }
                //                    else
                //                        throw new Exception(httpResponse + "\r\n" + jsonRequest);
                //                }
                //                else
                //                    throw new Exception(httpResponse + "\r\n" + jsonRequest);
                //            }
                //            else
                //                throw new Exception(response.StatusCode.ToString() + "\r\n" + jsonRequest);
            }
            catch (Exception ex1)
            {
                isError = true;
                userMessage = ex1.Message;
                _logger.LogError(ex1.Message);
            }
            finally
            {
                var updatePayment = new Payment();
                updatePayment.Id = postImageEntity.Id;

                if (!string.IsNullOrEmpty(userMessage))
                    updatePayment.CasResponse = (userMessage.Length >= 2000 ? userMessage.Substring(0, 1998) : userMessage);

                if (isError)
                    updatePayment.StatusCode = PaymentStatusCode.Failed;
                else
                {
                    updatePayment.Date = DateTime.Now;
                    updatePayment.StatusCode = PaymentStatusCode.Sent;
                }

                // TODO
                //OrgService.Update(updatePayment);

                if (httpClient != null)
                    httpClient.Dispose();

                _logger.LogInformation(postImageEntity.Name + " END.");
            }
        }
    }

    private async Task<Invoice> GenerateInvoice(IEnumerable<Configuration> configs, Payment paymentEntity)
    {
        ArgumentNullException.ThrowIfNull(paymentEntity.Invoices, "Invoice is missing.");
        if (paymentEntity.Invoices.Count() != 1)
            throw new Exception("Payment is associated to multiple invoices.");

        #region Payee Details
        string supplierNumber = string.Empty;
        int siteNumber = int.MinValue;
        string firstName = string.Empty;
        string lastName = string.Empty;
        string addressLine1 = string.Empty;
        string addressLine2 = string.Empty;
        string addressLine3 = string.Empty;
        string city = string.Empty;
        string province = string.Empty;
        string country = string.Empty;
        string postalCode = string.Empty;
        var programUnit = ProgramUnit.Cvap;
        Invoice invoiceEntity = paymentEntity.Invoices.Single();
        string methodOfPayment = "GEN CHQ";
        string accountNumber = string.Empty;
        string transitNumber = string.Empty;
        string institutionNumber = string.Empty;
        string emailAddress = string.Empty;
        bool isBlockSupplier = false;
        var payeeLookup = paymentEntity.Payee;

        ArgumentNullException.ThrowIfNull(invoiceEntity.InvoiceDate, "Invoice Date is missing.");
        ArgumentNullException.ThrowIfNull(invoiceEntity.Name, "Invoice Number is missing.");
        //ArgumentNullException.ThrowIfNull(invoiceEntity.ProgramUnit, "Invoice Program Unit is missing.");

        if (invoiceEntity.MethodOfPayment == MethodOfPayment.Eft)
            methodOfPayment = "GEN EFT";

        var programUnitConfigs = configs.Where(x => x.ProgramUnit == programUnit).ToList();

        var getKeyValueCommand = new GetKeyValueCommand(programUnitConfigs, "GSTDistributionAccount", "CAS", programUnit);
        var gstDistributionAccount = await mediator.Send(getKeyValueCommand);

        if (payeeLookup.SchemaName.Equals(Database.Model.Account.EntityLogicalName, StringComparison.InvariantCultureIgnoreCase))
        {
            var accountEntity = await mediator.Send(new FindAccountQuery { Id = payeeLookup.Id });

            ArgumentNullException.ThrowIfNull(accountEntity.Name, "Account Name is missing.");
            if (string.IsNullOrEmpty(accountEntity.AccountNumber))
            {
                if (programUnit == ProgramUnit.Cvap || programUnit == ProgramUnit.Vsu || programUnit == ProgramUnit.Rest)
                {
                    isBlockSupplier = true;
                    accountEntity.AccountNumber = await mediator.Send(new GetKeyValueCommand(programUnitConfigs, "BlockSupplierNumber", "CAS", programUnit));
                }
                else
                    throw new Exception("Vendor/Account Number on Service Provider is missing.");
            }
            //if (!accountEntity.SiteNumber.HasValue)
            //{
            //    if (programUnit == ProgramUnit.Cvap || programUnit == ProgramUnit.Vsu || programUnit == ProgramUnit.Rest)
            //    {
            //        isBlockSupplier = true;
            //        accountEntity.SiteNumber = int.Parse(await mediator.Send(new GetKeyValueCommand(programUnitConfigs, "SupplierSiteNumber", "CAS", programUnit));
            //    }
            //}

            //supplierNumber = accountEntity.AccountNumber;
            //if (accountEntity.SiteNumber.HasValue)
            //    siteNumber = accountEntity.SiteNumber.Value;

            //if (programUnit == ProgramUnit.Rest && !string.IsNullOrEmpty(accountEntity.RestChequeName) && methodOfPayment.Equals("GEN CHQ", StringComparison.InvariantCultureIgnoreCase)) //REST and CHQ
            //    firstName = accountEntity.RestChequeName;
            //else
            //    firstName = accountEntity.Name;

            //if (accountEntity.Address1_AddressTypeCode.HasValue && accountEntity.Address1_AddressTypeCode.Value == 2 && !string.IsNullOrEmpty(accountEntity.Address1_Line1)) //Payment Address
            //{
            //    addressLine1 = accountEntity.Address1_Line1;
            //    addressLine2 = accountEntity.Address1_Line2;
            //    addressLine3 = accountEntity.Address1_Line3;
            //    city = accountEntity.Address1_City;
            //    province = accountEntity.Address1_StateOrProvince;
            //    country = accountEntity.Address1_Country;
            //    postalCode = accountEntity.Address1_PostalCode;
            //}
            //else if (accountEntity.Address2_AddressTypeCode.HasValue && accountEntity.Address2_AddressTypeCode.Value == 100000001 && !string.IsNullOrEmpty(accountEntity.Address2_Line1)) //Payment Address
            //{
            //    addressLine1 = accountEntity.Address2_Line1;
            
                //        if (accountEntity.Contains("address2_line2"))
                //            addressLine2 = (string)accountEntity["address2_line2"];
                //        if (accountEntity.Contains("address2_line3"))
                //            addressLine3 = (string)accountEntity["address2_line3"];
                //        if (accountEntity.Contains("address2_city"))
                //            city = (string)accountEntity["address2_city"];
                //        if (accountEntity.Contains("address2_stateorprovince"))
                //            province = (string)accountEntity["address2_stateorprovince"];
                //        if (accountEntity.Contains("address2_country"))
                //            country = (string)accountEntity["address2_country"];
                //        if (accountEntity.Contains("address2_postalcode"))
                //            postalCode = (string)accountEntity["address2_postalcode"];
                //    }
                //    else
                //    {
                //        if (accountEntity.Contains("address1_line1"))
                //            addressLine1 = (string)accountEntity["address1_line1"];
                //        if (accountEntity.Contains("address1_line2"))
                //            addressLine2 = (string)accountEntity["address1_line2"];
                //        if (accountEntity.Contains("address1_line3"))
                //            addressLine3 = (string)accountEntity["address1_line3"];
                //        if (accountEntity.Contains("address1_city"))
                //            city = (string)accountEntity["address1_city"];
                //        if (accountEntity.Contains("address1_stateorprovince"))
                //            province = (string)accountEntity["address1_stateorprovince"];
                //        if (accountEntity.Contains("address1_country"))
                //            country = (string)accountEntity["address1_country"];
                //        if (accountEntity.Contains("address1_postalcode"))
                //            postalCode = (string)accountEntity["address1_postalcode"];
                //    }

                //    if (accountEntity.Contains("vsd_accountno"))
                //        accountNumber = (string)accountEntity["vsd_accountno"];
                //    if (accountEntity.Contains("vsd_transitno"))
                //        transitNumber = (string)accountEntity["vsd_transitno"];
                //    if (accountEntity.Contains("vsd_institutionno"))
                //        institutionNumber = (string)accountEntity["vsd_institutionno"];
                //    if (accountEntity.Contains("emailaddress1"))
                //        emailAddress = (string)accountEntity["emailaddress1"];
        }
        else
        {
            var contactEntity = await mediator.Send(new FindContactQuery { Id = payeeLookup.Id });

            //ArgumentNullException.ThrowIfNull(contactEntity.ContactRole, "Contact Role is missing.");
            if (string.IsNullOrEmpty(contactEntity.AccountNumber))
            {
                if (programUnit == ProgramUnit.Cvap || programUnit == ProgramUnit.Vsu || programUnit == ProgramUnit.Rest)
                {
                    isBlockSupplier = true;
                    contactEntity.AccountNumber = await mediator.Send(new GetKeyValueCommand(programUnitConfigs, "BlockSupplierNumber", "CAS", programUnit));
                }
                else
                    throw new Exception("Vendor/Account Number on Service Provider is missing.");
            }
            if (contactEntity.SupplierSiteNumber == null)
            {
                if (programUnit == ProgramUnit.Cvap || programUnit == ProgramUnit.Vsu || programUnit == ProgramUnit.Rest)
                {
                    isBlockSupplier = true;
                    contactEntity.SupplierSiteNumber = int.Parse(await mediator.Send(new GetKeyValueCommand(programUnitConfigs, "SupplierSiteNumber", "CAS", programUnit)));
                }
            }

            supplierNumber = contactEntity.AccountNumber;
            if (contactEntity.SupplierSiteNumber != null)
                siteNumber = (int)contactEntity.SupplierSiteNumber;

            if (programUnit == ProgramUnit.Rest && !string.IsNullOrEmpty(contactEntity.RestChequeName) && methodOfPayment.Equals("GEN CHQ", StringComparison.InvariantCultureIgnoreCase)) //REST and CHQ
                firstName = contactEntity.RestChequeName;
            else
            {
                firstName = contactEntity.FirstName;
                lastName = contactEntity.LastName;
            }

            if (contactEntity.Addresses != null && contactEntity.Addresses.Length > 0 && !string.IsNullOrEmpty(contactEntity.Addresses[0].AddressLine1)) //Payment Address
            {
                addressLine1 = contactEntity.Addresses?[0].AddressLine1;
                addressLine2 = contactEntity.Addresses?[0].AddressLine2;
                addressLine3 = contactEntity.Addresses?[0].AddressLine3;
                city = contactEntity.Addresses?[0].City;
                province = contactEntity.Addresses?[0].StateOrProvince;
                country = contactEntity.Addresses?[0].Country;
                postalCode = contactEntity.Addresses?[0].PostalCode;
                accountNumber = contactEntity.AccountNumber;
                transitNumber = contactEntity.TransitNumber;
                institutionNumber = contactEntity.InstitutionNumber;
                emailAddress = contactEntity.Emails?[0];
            }
        }
        #endregion

        #region Invoice Details

        var invoiceDate = paymentEntity.Date;
        string invoiceNumber = invoiceEntity.Name;

        if (programUnit == ProgramUnit.Cvap && invoiceEntity.Origin != null && invoiceEntity.Origin != Origin.AutoGenerated)
        {
            if (string.IsNullOrEmpty(invoiceEntity.Validator))
                throw new Exception("Validator is missing from the invoice.");
        }

        var defaultDistributionAccount = "";
        if (programUnit == ProgramUnit.Cpu)
        {
            if (invoiceEntity.CpuInvoiceType == null)
                throw new Exception("Invoice Type is missing for CPU invoice. Unable to determine STOB.");

            if (invoiceEntity.CpuInvoiceType == CpuInvoiceType.ScheduledPayment)
            {
                if (invoiceEntity.ProgramId == null)
                    throw new Exception("Invoice Program Lookup is missing.");

                //defaultDistributionAccount = GenerateDefaultDistributionAccount(((EntityReference)invoiceEntity["vsd_programid"]).Id);
            }
            else if (invoiceEntity.CpuInvoiceType == CpuInvoiceType.OneTimePayment)
            {
                //if (invoiceEntity.ProgramId != null)
                //    defaultDistributionAccount = GenerateDefaultDistributionAccount(((EntityReference)invoiceEntity["vsd_programid"]).Id);

                //if (invoiceEntity.Contains("vsd_caspaymenttype"))
                //    defaultDistributionAccount = GenerateOneTimeDistributionAccount(((EntityReference)invoiceEntity["vsd_caspaymenttype"]).Id);

                if (string.IsNullOrEmpty(defaultDistributionAccount))
                    throw new Exception("Invoice Payment Type/Program is missing.");
            }
            else
                throw new Exception("Unknown CPU Invoice Type..");
        }
        else if (programUnit == ProgramUnit.Cvap || programUnit == ProgramUnit.Vsu || programUnit == ProgramUnit.Rest)
        {
            //if (invoiceEntity.Contains("vsd_cvap_stobid"))
            //    defaultDistributionAccount = GenerateCVAPDistributionAccount(((EntityReference)invoiceEntity["vsd_cvap_stobid"]).Id);

            if (string.IsNullOrEmpty(defaultDistributionAccount))
                throw new Exception("CVAP STOB is missing.");
        }
        else
            throw new Exception(string.Format("STOB information is not setup for Program Unit '{0}'.", (ProgramUnit)programUnit));

        if (string.IsNullOrEmpty(defaultDistributionAccount))
            throw new Exception("Default Distribution Account is missing.");

        var invoiceLineDetailQuery = new InvoiceLineDetailQuery();
        invoiceLineDetailQuery.InvoiceId = invoiceEntity.Id;
        invoiceLineDetailQuery.StateCode = StateCode.Active;
        invoiceLineDetailQuery.Approved = YesNo.Yes;
        var invoiceLineDetails = await mediator.Send(invoiceLineDetailQuery);

        int j = 0;
        foreach (var invoiceLineDetail in invoiceLineDetails)
        {
            if (invoiceLineDetail.AmountCalculated == null)
                throw new Exception("Invoice Line Item Sub Total Amount is missing.");
            if (invoiceLineDetail.TaxExemption == null)
                throw new Exception("Invoice Line Item Tax is missing.");
            if (invoiceLineDetail.TotalAmount == null)
                throw new Exception("Invoice Line Item Total Amount is missing.");

            //        j = j + 1;
            //        InvoiceLineDetail lineDetail = new InvoiceLineDetail()
            //        {
            //            InvoiceLineNumber = j,
            //            InvoiceLineType = "Item",
            //            LineCode = paymentEntity.FormattedValues["vsd_linecode"],
            //            InvoiceLineAmount = ((Money)coll.Entities[i]["vsd_amountcalculated"]).Value,
            //            DefaultDistributionAccount = defaultDistributionAccount
            //        };
            //        invoiceLineDetails.Add(lineDetail);

            //        if (((OptionSetValue)coll.Entities[i]["vsd_taxexemption"]).Value == 100000000) //PST
            //        {
            //            j = j + 1;
            //            InvoiceLineDetail lineDetail1 = new InvoiceLineDetail()
            //            {
            //                InvoiceLineNumber = j,
            //                InvoiceLineType = "Item",
            //                LineCode = paymentEntity.FormattedValues["vsd_linecode"],
            //                InvoiceLineAmount = ((Money)coll.Entities[i]["vsd_lineitemtotalamount"]).Value - ((Money)coll.Entities[i]["vsd_amountcalculated"]).Value,
            //                DefaultDistributionAccount = defaultDistributionAccount
            //            };
            //            invoiceLineDetails.Add(lineDetail1);
            //            //lineDetail.TaxClassificationCode = "PST";
            //        }
            //        else if (((OptionSetValue)coll.Entities[i]["vsd_taxexemption"]).Value == 100000001) //GST
            //        {
            //            j = j + 1;
            //            InvoiceLineDetail lineDetail1 = new InvoiceLineDetail()
            //            {
            //                InvoiceLineNumber = j,
            //                InvoiceLineType = "Item",
            //                LineCode = paymentEntity.FormattedValues["vsd_linecode"],
            //                InvoiceLineAmount = ((Money)coll.Entities[i]["vsd_lineitemtotalamount"]).Value - ((Money)coll.Entities[i]["vsd_amountcalculated"]).Value,
            //                DefaultDistributionAccount = gstDistributionAccount
            //            };
            //            invoiceLineDetails.Add(lineDetail1);
            //            //lineDetail.TaxClassificationCode = "GST";
            //        }
            //        else if (((OptionSetValue)coll.Entities[i]["vsd_taxexemption"]).Value == 100000003) //GST and PST
            //        {
            //            if (!coll.Entities[i].Contains("vsd_gst"))
            //                throw new Exception("GST amount is missing.");

            //            j = j + 1;
            //            InvoiceLineDetail lineDetail1 = new InvoiceLineDetail()
            //            {
            //                InvoiceLineNumber = j,
            //                InvoiceLineType = "Item",
            //                LineCode = paymentEntity.FormattedValues["vsd_linecode"],
            //                InvoiceLineAmount = ((Money)coll.Entities[i]["vsd_gst"]).Value,
            //                DefaultDistributionAccount = gstDistributionAccount
            //            };
            //            invoiceLineDetails.Add(lineDetail1);

            //            j = j + 1;
            //            InvoiceLineDetail lineDetail2 = new InvoiceLineDetail()
            //            {
            //                InvoiceLineNumber = j,
            //                InvoiceLineType = "Item",
            //                LineCode = paymentEntity.FormattedValues["vsd_linecode"],
            //                InvoiceLineAmount = ((Money)coll.Entities[i]["vsd_lineitemtotalamount"]).Value - (((Money)coll.Entities[i]["vsd_amountcalculated"]).Value + ((Money)coll.Entities[i]["vsd_gst"]).Value),
            //                DefaultDistributionAccount = defaultDistributionAccount
            //            };
            //            invoiceLineDetails.Add(lineDetail2);
            //            //lineDetail.TaxClassificationCode = "GST AND PST";
            //        }
        }
        //}
        //else
        //{
        //    InvoiceLineDetail lineDetail = new InvoiceLineDetail()
        //    {
        //        InvoiceLineNumber = 1,
        //        InvoiceLineType = "Item",
        //        LineCode = paymentEntity.FormattedValues["vsd_linecode"],
        //        InvoiceLineAmount = ((Money)paymentEntity["vsd_paymenttotal"]).Value,
        //        DefaultDistributionAccount = defaultDistributionAccount
        //    };
        //    invoiceLineDetails.Add(lineDetail);
        //}

        #endregion

        //#region Mandatory Field Validations
        //if (string.IsNullOrEmpty(supplierNumber))
        //    throw new Exception("Vendor Number is missing.");
        //if (methodOfPayment.Equals("GEN EFT", StringComparison.InvariantCultureIgnoreCase) && isBlockSupplier)
        //{
        //    if (string.IsNullOrEmpty(accountNumber))
        //        throw new Exception("Account # is missing.");
        //    if (string.IsNullOrEmpty(transitNumber))
        //        throw new Exception("Transit # is missing.");
        //    if (string.IsNullOrEmpty(institutionNumber))
        //        throw new Exception("Institution # is missing.");
        //}

        //if (siteNumber == int.MinValue)
        //    throw new Exception("Supplier Site Number is missing.");
        //if (!paymentEntity.Contains("vsd_paymenttotal"))
        //    throw new Exception("Invoice Amount is missing.");
        //if (!invoiceDate.HasValue)
        //    throw new Exception("Invoice Date is missing.");
        //if (!paymentEntity.Contains("vsd_gldate"))
        //    throw new Exception("GL Date is missing.");
        //#endregion

        Invoice result = new Invoice
        {
            //Mandatory values
            Owner = null,
        //    IsBlockSupplier = isBlockSupplier,
        //    InvoiceType = Helpers.GetConfigKeyValue(configs, "InvoiceType", "CAS", null),
        //    SupplierNumber = supplierNumber,
        //    SupplierSiteNumber = siteNumber,
        //    InvoiceDate = invoiceDate.Value,
        //    InvoiceNumber = invoiceNumber,
        //    InvoiceAmount = ((Money)paymentEntity["vsd_paymenttotal"]).Value,
        //    PayGroup = methodOfPayment,
        //    DateInvoiceReceived = invoiceDate.Value,
        //    RemittanceCode = Helpers.GetConfigKeyValue(configs, "RemittanceCode", "CAS", null),
        //    SpecialHandling = false,
        //    Terms = paymentEntity.FormattedValues["vsd_terms"],
        //    GLDate = (DateTime)paymentEntity["vsd_gldate"],
        //    InvoiceBatchName = Helpers.GetConfigKeyValue(configs, "BatchName", "CAS", null),

        //    //Optional Value
        //    QualifiedReceiver = ((EntityReference)paymentEntity["ownerid"]).Name,
        //    PaymentAdviceComments = paymentEntity.Contains("vsd_paymentadvicecomments") ? (string)paymentEntity["vsd_paymentadvicecomments"] : "",
        //    RemittanceMessage1 = paymentEntity.Contains("vsd_remittancemessage1") ? (string)paymentEntity["vsd_remittancemessage1"] : "",
        //    RemittanceMessage2 = paymentEntity.Contains("vsd_remittancemessage2") ? (string)paymentEntity["vsd_remittancemessage2"] : "",
        //    RemittanceMessage3 = paymentEntity.Contains("vsd_remittancemessage3") ? (string)paymentEntity["vsd_remittancemessage3"] : "",
        //    CurrencyCode = Helpers.GetConfigKeyValue(configs, "CurrencyCode", "CAS", null)
        };

        //result.InvoiceLineDetails = invoiceLineDetails;

        //if (methodOfPayment.Equals("GEN EFT", StringComparison.InvariantCultureIgnoreCase))
        //{
        //    if (isBlockSupplier)
        //    {
        //        result.AccountNumber = accountNumber;
        //        result.TransitNumber = transitNumber;
        //        result.InstitutionNumber = institutionNumber;

        //        if (paymentEntity.Contains("vsd_eftadvice"))
        //        {
        //            if (((OptionSetValue)paymentEntity["vsd_eftadvice"]).Value == 100000000) //Email
        //            {
        //                if (string.IsNullOrEmpty(emailAddress))
        //                    throw new Exception("Email Address on the Payee is missing.");

        //                result.EmailAddress = emailAddress;
        //                result.EFTAdvice = "E";
        //            }
        //            else if (((OptionSetValue)paymentEntity["vsd_eftadvice"]).Value == 100000001) //Mail
        //            {
        //                result.EFTAdvice = "P";
        //                List<string> nameLines = new List<string>();
        //                if (!string.IsNullOrEmpty(firstName))
        //                    nameLines.Add(firstName);
        //                if (!string.IsNullOrEmpty(lastName))
        //                    nameLines.Add(lastName);
        //                if (nameLines.Count > 0)
        //                {
        //                    result.NameLine1 = string.Join(" ", nameLines);
        //                    if (result.NameLine1.Length > 40)
        //                        throw new Exception(string.Format("'{0}' name exceeded 40 character limit.."));
        //                }
        //                if (!string.IsNullOrEmpty(addressLine1))
        //                    result.AddressLine1 = addressLine1;
        //                if (!string.IsNullOrEmpty(addressLine2))
        //                    result.AddressLine2 = addressLine2;
        //                if (!string.IsNullOrEmpty(addressLine3))
        //                    result.AddressLine3 = addressLine3;
        //                if (!string.IsNullOrEmpty(city))
        //                    result.City = city;
        //                if (!string.IsNullOrEmpty(country))
        //                {
        //                    var countryLookup = GetCountryCode(country);
        //                    result.Country = countryLookup.Name;

        //                    if (!string.IsNullOrEmpty(province))
        //                        result.Province = GetProvinceCode(province, countryLookup.Id);
        //                }
        //                if (!string.IsNullOrEmpty(postalCode))
        //                    result.PostalCode = postalCode;
        //            }
        //        }
        //        else
        //        {
        //            result.EmailAddress = emailAddress;
        //            result.EFTAdvice = "E";
        //        }

        //        result.PayAloneFlag = "Y";
        //    }
        //}
        //else //GEN CHQ
        //{
        //    if (isBlockSupplier)
        //    {
        //        List<string> nameLines = new List<string>();
        //        if (!string.IsNullOrEmpty(firstName))
        //            nameLines.Add(firstName);
        //        if (!string.IsNullOrEmpty(lastName))
        //            nameLines.Add(lastName);
        //        if (nameLines.Count > 0)
        //        {
        //            result.NameLine1 = string.Join(" ", nameLines);
        //            if (result.NameLine1.Length > 40)
        //                throw new Exception(string.Format("'{0}' name exceeded 40 character limit..", result.NameLine1));
        //        }
        //        if (!string.IsNullOrEmpty(addressLine1))
        //            result.AddressLine1 = addressLine1;
        //        if (!string.IsNullOrEmpty(addressLine2))
        //            result.AddressLine2 = addressLine2;
        //        if (!string.IsNullOrEmpty(addressLine3))
        //            result.AddressLine3 = addressLine3;
        //        if (!string.IsNullOrEmpty(city))
        //            result.City = city;
        //        if (!string.IsNullOrEmpty(country))
        //        {
        //            var countryLookup = GetCountryCode(country);
        //            result.Country = countryLookup.Name;

        //            if (!string.IsNullOrEmpty(province))
        //                result.Province = GetProvinceCode(province, countryLookup.Id);
        //        }
        //        if (!string.IsNullOrEmpty(postalCode))
        //            result.PostalCode = postalCode;

        //        result.PayAloneFlag = "Y";
        //    }
        //}

        //if (((OptionSetValue)paymentEntity["vsd_specialhandling"]).Value == 100000001) //DBack
        //{
        //    result.PayGroup = "GEN DAY";
        //    result.SpecialHandling = true;
        //    result.PayAloneFlag = "Y";
        //}

        //if (result.GLDate.HasValue && result.GLDate.Value.ToLocalTime() < DateTime.Today)
        //{
        //    result.GLDate = DateTime.Now;
        //}

        return result;
    }
}

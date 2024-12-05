using Microsoft.Xrm.Sdk;

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

                messageRequests.SetState(Vsd_Payment.EntityLogicalName, postImageEntity.Id, (int)StateCode.Active, (int)PaymentStatusCode.Sending); //Sending

                var invoices = GenerateInvoice(configs, postImageEntity);
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
                //                            throw new InvalidPluginExecutionException(casReturnedMessages.Value + "\r\n" + jsonRequest);
                //                    }
                //                    else
                //                        throw new InvalidPluginExecutionException(httpResponse + "\r\n" + jsonRequest);
                //                }
                //                else
                //                    throw new InvalidPluginExecutionException(httpResponse + "\r\n" + jsonRequest);
                //            }
                //            else
                //                throw new InvalidPluginExecutionException(response.StatusCode.ToString() + "\r\n" + jsonRequest);
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

    private Invoice GenerateInvoice(IEnumerable<Configuration> configs, Payment paymentEntity)
    {
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
        int programUnit = (int)ProgramUnit.Cvap;
        Entity invoiceEntity = null;
        string methodOfPayment = "GEN CHQ";
        string accountNumber = string.Empty;
        string transitNumber = string.Empty;
        string institutionNumber = string.Empty;
        string emailAddress = string.Empty;
        bool isBlockSupplier = false;
        var payeeLookup = paymentEntity.Payee;
        List<InvoiceLineDetail> invoiceLineDetails = new List<InvoiceLineDetail>();

        //QueryExpression exp = new QueryExpression("vsd_vsd_payment_vsd_invoice");
        //exp.NoLock = true;
        //exp.ColumnSet.AddColumn("vsd_invoiceid");
        //exp.Criteria.AddCondition("vsd_paymentid", ConditionOperator.Equal, paymentEntity.Id);

        //var coll = OrgService.RetrieveMultiple(exp);
        //if (coll != null && coll.Entities != null && coll.Entities.Count > 0)
        //{
        //    if (coll.Entities.Count != 1)
        //        throw new Exception("Payment is associated to multiple invoices..");

        //    invoiceEntity = OrgService.Retrieve("vsd_invoice", (Guid)coll.Entities[0]["vsd_invoiceid"], new ColumnSet("vsd_invoicedate", "vsd_name", "vsd_methodofpayment", "vsd_programunit", "vsd_programid", "vsd_cpu_invoicetype", "vsd_caspaymenttype", "vsd_cvap_stobid", "vsd_user3", "vsd_origin"));

        //    if (!invoiceEntity.Contains("vsd_invoicedate"))
        //        throw new Exception("Invoice Date is empty..");
        //    if (!invoiceEntity.Contains("vsd_name"))
        //        throw new Exception("Invoice Number is empty..");
        //    if (!invoiceEntity.Contains("vsd_programunit"))
        //        throw new Exception("Invoice Program Unit is empty..");

        //    programUnit = ((OptionSetValue)invoiceEntity["vsd_programunit"]).Value;

        //    if (invoiceEntity.Contains("vsd_methodofpayment"))
        //    {
        //        if (((OptionSetValue)invoiceEntity["vsd_methodofpayment"]).Value == 100000000)
        //            methodOfPayment = "GEN EFT";
        //    }
        //}
        //else
        //    throw new Exception("Payment is not associated to any invoice..");

        //var programUnitConfigs = Helpers.GetSystemConfigurations(OrgService, "CAS", string.Empty, (ProgramUnit)programUnit);

        //var gstDistributionAccount = Helpers.GetConfigKeyValue(programUnitConfigs, "GSTDistributionAccount", "CAS", (ProgramUnit)programUnit);

        //if (payeeLookup.LogicalName.Equals("account", StringComparison.InvariantCultureIgnoreCase))
        //{
        //    var accountEntity = OrgService.Retrieve(payeeLookup.LogicalName.ToLowerInvariant(), payeeLookup.Id,
        //        new ColumnSet("accountnumber", "vsd_suppliersitenumber", "name",
        //        "address1_addresstypecode", "address1_line1", "address1_line2", "address1_line3", "address1_city", "address1_stateorprovince", "address1_country", "address1_postalcode",
        //        "address2_addresstypecode", "address2_line1", "address2_line2", "address2_line3", "address2_city", "address2_stateorprovince", "address2_country", "address2_postalcode",
        //        "vsd_accountno", "vsd_transitno", "vsd_institutionno", "emailaddress1", "vsd_rest_chequename"));

        //    if (!accountEntity.Contains("name"))
        //        throw new InvalidPluginExecutionException("Account Name is empty..");
        //    if (!accountEntity.Contains("accountnumber"))
        //    {
        //        if (programUnit == (int)ProgramUnit.CVAP || programUnit == (int)ProgramUnit.VSU || programUnit == (int)ProgramUnit.REST) //CVAP or VSU or REST
        //        {
        //            isBlockSupplier = true;
        //            accountEntity["accountnumber"] = Helpers.GetConfigKeyValue(programUnitConfigs, "BlockSupplierNumber", "CAS", (ProgramUnit)programUnit);
        //        }
        //        else
        //            throw new InvalidPluginExecutionException("Vendor/Account Number on Service Provider is empty..");
        //    }
        //    if (!accountEntity.Contains("vsd_suppliersitenumber"))
        //    {
        //        if (programUnit == (int)ProgramUnit.CVAP || programUnit == (int)ProgramUnit.VSU || programUnit == (int)ProgramUnit.REST) //CVAP or VSU or REST
        //        {
        //            isBlockSupplier = true;
        //            accountEntity["vsd_suppliersitenumber"] = int.Parse(Helpers.GetConfigKeyValue(programUnitConfigs, "SupplierSiteNumber", "CAS", (ProgramUnit)programUnit));
        //        }
        //    }

        //    supplierNumber = (string)accountEntity["accountnumber"];
        //    if (accountEntity.Contains("vsd_suppliersitenumber"))
        //        siteNumber = (int)accountEntity["vsd_suppliersitenumber"];

        //    if (programUnit == (int)ProgramUnit.REST && accountEntity.Contains("vsd_rest_chequename") && !string.IsNullOrEmpty(accountEntity["vsd_rest_chequename"].ToString()) && methodOfPayment.Equals("GEN CHQ", StringComparison.InvariantCultureIgnoreCase)) //REST and CHQ
        //        firstName = (string)accountEntity["vsd_rest_chequename"];
        //    else
        //        firstName = (string)accountEntity["name"];

        //    if (accountEntity.Contains("address1_addresstypecode") && ((OptionSetValue)accountEntity["address1_addresstypecode"]).Value == 2 && accountEntity.Contains("address1_line1")) //Payment Address
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
        //    else if (accountEntity.Contains("address2_addresstypecode") && ((OptionSetValue)accountEntity["address2_addresstypecode"]).Value == 100000001 && accountEntity.Contains("address2_line1")) //Payment Address
        //    {
        //        if (accountEntity.Contains("address2_line1"))
        //            addressLine1 = (string)accountEntity["address2_line1"];
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
        //}
        //else
        //{
        //    var contactEntity = OrgService.Retrieve(payeeLookup.LogicalName.ToLowerInvariant(), payeeLookup.Id,
        //        new ColumnSet("vsd_contactrole", "vsd_accountnumber", "vsd_suppliersitenumber", "firstname", "lastname", "address3_line1", "address3_line2", "address3_line3",
        //        "address3_city", "address3_stateorprovince", "address3_country", "address3_postalcode", "vsd_accountno", "vsd_transitno", "vsd_institutionno", "emailaddress1", "vsd_rest_chequename"));

        //    if (!contactEntity.Contains("vsd_contactrole"))
        //        throw new InvalidPluginExecutionException("Contact Role is empty..");
        //    if (!contactEntity.Contains("vsd_accountnumber"))
        //    {
        //        if ((programUnit == (int)ProgramUnit.CVAP || programUnit == (int)ProgramUnit.VSU || programUnit == (int)ProgramUnit.REST) && ((OptionSetValue)contactEntity["vsd_contactrole"]).Value == 100000000) //CVAP or VSU or REST and Client
        //        {
        //            isBlockSupplier = true;
        //            contactEntity["vsd_accountnumber"] = Helpers.GetConfigKeyValue(programUnitConfigs, "BlockSupplierNumber", "CAS", (ProgramUnit)programUnit);
        //        }
        //        else
        //            throw new InvalidPluginExecutionException("Vendor Number on contact is empty..");
        //    }
        //    if (!contactEntity.Contains("vsd_suppliersitenumber"))
        //    {
        //        if ((programUnit == (int)ProgramUnit.CVAP || programUnit == (int)ProgramUnit.VSU || programUnit == (int)ProgramUnit.REST) && ((OptionSetValue)contactEntity["vsd_contactrole"]).Value == 100000000) //CVAP or VSU or REST and Client
        //        {
        //            isBlockSupplier = true;
        //            contactEntity["vsd_suppliersitenumber"] = int.Parse(Helpers.GetConfigKeyValue(programUnitConfigs, "SupplierSiteNumber", "CAS", (ProgramUnit)programUnit));
        //        }
        //    }
        //    if (!contactEntity.Contains("firstname"))
        //        throw new InvalidPluginExecutionException("First Name on contact is empty..");
        //    if (!contactEntity.Contains("lastname"))
        //        throw new InvalidPluginExecutionException("Last Name on contact is empty..");

        //    supplierNumber = (string)contactEntity["vsd_accountnumber"];
        //    if (contactEntity.Contains("vsd_suppliersitenumber"))
        //        siteNumber = (int)contactEntity["vsd_suppliersitenumber"];

        //    if (programUnit == (int)ProgramUnit.REST && contactEntity.Contains("vsd_rest_chequename") && !string.IsNullOrEmpty(contactEntity["vsd_rest_chequename"].ToString()) && methodOfPayment.Equals("GEN CHQ", StringComparison.InvariantCultureIgnoreCase)) //REST and CHQ
        //        firstName = contactEntity["vsd_rest_chequename"].ToString();
        //    else
        //    {
        //        firstName = (string)contactEntity["firstname"];
        //        lastName = (string)contactEntity["lastname"];
        //    }

        //    if (contactEntity.Contains("address3_line1"))
        //        addressLine1 = (string)contactEntity["address3_line1"];
        //    if (contactEntity.Contains("address3_line2"))
        //        addressLine2 = (string)contactEntity["address3_line2"];
        //    if (contactEntity.Contains("address3_line3"))
        //        addressLine3 = (string)contactEntity["address3_line3"];
        //    if (contactEntity.Contains("address3_city"))
        //        city = (string)contactEntity["address3_city"];
        //    if (contactEntity.Contains("address3_stateorprovince"))
        //        province = (string)contactEntity["address3_stateorprovince"];
        //    if (contactEntity.Contains("address3_country"))
        //        country = (string)contactEntity["address3_country"];
        //    if (contactEntity.Contains("address3_postalcode"))
        //        postalCode = (string)contactEntity["address3_postalcode"];
        //    if (contactEntity.Contains("vsd_accountno"))
        //        accountNumber = (string)contactEntity["vsd_accountno"];
        //    if (contactEntity.Contains("vsd_transitno"))
        //        transitNumber = (string)contactEntity["vsd_transitno"];
        //    if (contactEntity.Contains("vsd_institutionno"))
        //        institutionNumber = (string)contactEntity["vsd_institutionno"];
        //    if (contactEntity.Contains("emailaddress1"))
        //        emailAddress = (string)contactEntity["emailaddress1"];
        //}
        #endregion

        //#region Invoice Details
        //DateTime? invoiceDate = (DateTime)paymentEntity["vsd_paymentdate"];
        //string invoiceNumber = (string)invoiceEntity["vsd_name"];

        //if (programUnit == (int)ProgramUnit.CVAP && invoiceEntity.Contains("vsd_origin") && invoiceEntity["vsd_origin"] != null && ((OptionSetValue)invoiceEntity["vsd_origin"]).Value != 100000002) //Auto-generated
        //{
        //    if (!invoiceEntity.Contains("vsd_user3"))
        //        throw new InvalidPluginExecutionException("Validator is not present on the invoice..");
        //    if (invoiceEntity["vsd_user3"] == null)
        //        throw new InvalidPluginExecutionException("Validator is not present on the invoice..");
        //}

        //var defaultDistributionAccount = "";
        //if (programUnit == (int)ProgramUnit.CPU)
        //{
        //    if (!invoiceEntity.Contains("vsd_cpu_invoicetype"))
        //        throw new InvalidPluginExecutionException("Invoice Type is empty for CPU invoice. Unable to determine STOB..");

        //    if (((OptionSetValue)invoiceEntity["vsd_cpu_invoicetype"]).Value == 100000000) //Scheduled Payment
        //    {
        //        if (!invoiceEntity.Contains("vsd_programid"))
        //            throw new InvalidPluginExecutionException("Invoice Program Lookup is empty..");

        //        defaultDistributionAccount = GenerateDefaultDistributionAccount(((EntityReference)invoiceEntity["vsd_programid"]).Id);
        //    }
        //    else if (((OptionSetValue)invoiceEntity["vsd_cpu_invoicetype"]).Value == 100000001) //One Time Payment
        //    {
        //        if (invoiceEntity.Contains("vsd_programid"))
        //            defaultDistributionAccount = GenerateDefaultDistributionAccount(((EntityReference)invoiceEntity["vsd_programid"]).Id);

        //        if (invoiceEntity.Contains("vsd_caspaymenttype"))
        //            defaultDistributionAccount = GenerateOneTimeDistributionAccount(((EntityReference)invoiceEntity["vsd_caspaymenttype"]).Id);

        //        if (string.IsNullOrEmpty(defaultDistributionAccount))
        //            throw new InvalidPluginExecutionException("Invoice Payment Type/Program is empty..");
        //    }
        //    else
        //        throw new InvalidPluginExecutionException("Unknown CPU Invoice Type..");
        //}
        //else if (programUnit == (int)ProgramUnit.CVAP || programUnit == (int)ProgramUnit.VSU || programUnit == (int)ProgramUnit.REST)
        //{
        //    if (invoiceEntity.Contains("vsd_cvap_stobid"))
        //        defaultDistributionAccount = GenerateCVAPDistributionAccount(((EntityReference)invoiceEntity["vsd_cvap_stobid"]).Id);

        //    if (string.IsNullOrEmpty(defaultDistributionAccount))
        //        throw new InvalidPluginExecutionException("CVAP STOB is empty..");
        //}
        //else
        //    throw new InvalidPluginExecutionException(string.Format("STOB information is not setup for Program Unit '{0}'..", (ProgramUnit)programUnit));

        //if (string.IsNullOrEmpty(defaultDistributionAccount))
        //    throw new InvalidPluginExecutionException("Default Distribution Account is empty..");

        //exp = new QueryExpression("vsd_invoicelinedetail");
        //exp.NoLock = true;
        //exp.ColumnSet.AddColumns("vsd_name", "vsd_amountcalculated", "vsd_taxexemption", "vsd_lineitemtotalamount", "vsd_gst");
        //exp.Criteria.AddCondition("vsd_invoiceid", ConditionOperator.Equal, invoiceEntity.Id);
        //exp.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0); //Active
        //exp.Criteria.AddCondition("vsd_lineitemapproved", ConditionOperator.Equal, 100000001); //Approved

        //coll = OrgService.RetrieveMultiple(exp);
        //if (coll != null && coll.Entities != null && coll.Entities.Count > 0)
        //{
        //    int j = 0;
        //    for (int i = 0; i < coll.Entities.Count; i++)
        //    {
        //        if (!coll.Entities[i].Contains("vsd_amountcalculated"))
        //            throw new InvalidPluginExecutionException("Invoice Line Item Sub Total Amount is empty..");
        //        if (!coll.Entities[i].Contains("vsd_taxexemption"))
        //            throw new InvalidPluginExecutionException("Invoice Line Item Tax is empty..");
        //        if (!coll.Entities[i].Contains("vsd_lineitemtotalamount"))
        //            throw new InvalidPluginExecutionException("Invoice Line Item Total Amount is empty..");

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
        //                throw new InvalidPluginExecutionException("GST amount is empty..");

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
        //    }
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

        //#endregion

        //#region Mandatory Field Validations
        //if (string.IsNullOrEmpty(supplierNumber))
        //    throw new InvalidPluginExecutionException("Vendor Number is empty..");
        //if (methodOfPayment.Equals("GEN EFT", StringComparison.InvariantCultureIgnoreCase) && isBlockSupplier)
        //{
        //    if (string.IsNullOrEmpty(accountNumber))
        //        throw new InvalidPluginExecutionException("Account # is empty..");
        //    if (string.IsNullOrEmpty(transitNumber))
        //        throw new InvalidPluginExecutionException("Transit # is empty..");
        //    if (string.IsNullOrEmpty(institutionNumber))
        //        throw new InvalidPluginExecutionException("Institution # is empty..");
        //}

        //if (siteNumber == int.MinValue)
        //    throw new InvalidPluginExecutionException("Supplier Site Number is empty..");
        //if (!paymentEntity.Contains("vsd_paymenttotal"))
        //    throw new InvalidPluginExecutionException("Invoice Amount is empty..");
        //if (!invoiceDate.HasValue)
        //    throw new InvalidPluginExecutionException("Invoice Date is empty..");
        //if (!paymentEntity.Contains("vsd_gldate"))
        //    throw new InvalidPluginExecutionException("GL Date is empty..");
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
        //                    throw new InvalidPluginExecutionException("Email Address on the Payee is empty..");

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
        //                        throw new InvalidPluginExecutionException(string.Format("'{0}' name exceeded 40 character limit.."));
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
        //                throw new InvalidPluginExecutionException(string.Format("'{0}' name exceeded 40 character limit..", result.NameLine1));
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

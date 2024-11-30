public class PaymentTests(ILoggerFactory loggerFactory)
{
    private readonly ILogger _logger = loggerFactory.CreateLogger<PaymentScheduleTests>();

    [Fact]
    public async Task Send_Payment_To_CAS()
    {
        //LogicStatus result = new LogicStatus();

        //try
        //{
            var startTime = DateTime.Now;
            //var configs = XrmHelpers.Helpers.GetSystemConfigurations(OrgService, "CAS", string.Empty, null);

            //string clientKey = Helpers.GetConfigKeyValue(configs, "ClientKey", "CAS", null);
            //string clientId = Helpers.GetConfigKeyValue(configs, "ClientId", "CAS", null);
            //string url = Helpers.GetConfigKeyValue(configs, "InterfaceUrl", "CAS", null);

        //    foreach (var postImageEntity in GetPaymentsToBeSentToCAS())
        //    {
        //        string userMessage = string.Empty;
        //        HttpClient httpClient = null;
        //        bool isError = false;
        //        Log.AppendLine("Processing Payment: " + postImageEntity.GetAttributeValue<string>("vsd_name"));
        //        //if ((DateTime.Now - startTime).TotalSeconds >= 100) //2-limit timer
        //        //{
        //        //    result.MoreRecords = true;
        //        //    break;
        //        //}

        //        try
        //        {
        //            if (!postImageEntity.Contains("vsd_payee"))
        //                throw new InvalidPluginExecutionException("Payee lookup is empty on the payment..");
        //            if (!postImageEntity.Contains("vsd_paymenttotal"))
        //                throw new InvalidPluginExecutionException("Payment Total is empty on the payment");
        //            if (!postImageEntity.Contains("vsd_paymentdate"))
        //                throw new InvalidPluginExecutionException("CAS Payment Date is empty on the payment");

        //            SetState(postImageEntity.ToEntityReference(), 0, 100000001); //Sending

        //            var jsonRequest = GenerateInvoice(configs, postImageEntity).ToJSONString();
        //            Log.AppendLine("Sending Json: " + jsonRequest.ToString());
        //            httpClient = new HttpClient();
        //            httpClient.DefaultRequestHeaders.Add("clientID", clientId);
        //            httpClient.DefaultRequestHeaders.Add("secret", clientKey);
        //            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            httpClient.BaseAddress = new Uri(url);
        //            httpClient.Timeout = new TimeSpan(1, 0, 0);  // 1 hour timeout 

        //            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url + "/api/CASAPTransaction");
        //            request.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        //            HttpResponseMessage response = httpClient.SendAsync(request).Result;

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
        //        }
        //        catch (Exception ex1)
        //        {
        //            Log.AppendLine("Error");
        //            isError = true;
        //            result.IsError = true;
        //            userMessage = ex1.Message;
        //            Log.AppendLine(ex1.Message);
        //        }
        //        finally
        //        {
        //            Entity updatePayment = new Entity("vsd_payment");
        //            updatePayment.Id = postImageEntity.Id;

        //            if (!string.IsNullOrEmpty(userMessage))
        //                updatePayment["vsd_casresponse"] = (userMessage.Length >= 2000 ? userMessage.Substring(0, 1998) : userMessage);

        //            if (isError)
        //                updatePayment["statuscode"] = new OptionSetValue(100000003); //Failed
        //            else
        //            {
        //                updatePayment["vsd_paymentdate"] = DateTime.Now;
        //                updatePayment["statuscode"] = new OptionSetValue(100000002); //Sent
        //            }

        //            OrgService.Update(updatePayment);

        //            if (httpClient != null)
        //                httpClient.Dispose();

        //            Log.AppendLine((string)postImageEntity["vsd_name"] + " END..");
        //        }
        //    }
        //}
        //catch (Exception ex2)
        //{
        //    result.IsError = true;
        //    Log.AppendLine("Main Error:" + ex2.Message);
        //}
        //finally
        //{
        //    TraceLog.Trace(Log.ToString());

        //    Entity updateLog = new Entity(Target.LogicalName.ToLowerInvariant());
        //    updateLog.Id = Target.Id;
        //    // updateLog["vsd_log"] = (Log.ToString().Length >= 4000 ? Log.ToString().Substring(0, 3999) : Log.ToString());
        //    updateLog["vsd_log"] = Log.Length < Helpers.LogMax ? Log.ToString() : Log.ToString(0, Helpers.LogMax - 1);
        //    OrgService.Update(updateLog);
        //}
    }
}


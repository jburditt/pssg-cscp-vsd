using System.Net.Http;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System;
using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Manager.Contract;

public interface ICasHttpClient
{
    Task<bool> ApTransaction(CasApTransactionInvoices invoices);
}

public class CasHttpClient : ICasHttpClient
{
    private readonly HttpClient _httpClient;

    public CasHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> ApTransaction(CasApTransactionInvoices invoices)
    {
        var jsonRequest = JsonConvert.SerializeObject(invoices);

        var url = "/api/CASAPTransaction";
        var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, httpContent);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Request {url} returned {response.StatusCode} status code.");
        }
        var httpResponse = await response.Content.ReadAsStringAsync();

        var jsonReader = System.Runtime.Serialization.Json.JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(httpResponse), new XmlDictionaryReaderQuotas());

        var root = XElement.Load(jsonReader);
        if (root.Element("CAS-Returned-Messages") != null)
        {
            var casReturnedMessages = root.Element("CAS-Returned-Messages");
            if (casReturnedMessages != null)
            {
                if (!(casReturnedMessages.Value.Equals("SUCCEEDED", StringComparison.InvariantCultureIgnoreCase) | casReturnedMessages.Value.Contains("Duplicate Submission")))
                    throw new Exception(casReturnedMessages.Value + "\r\n" + jsonRequest);
            }
            else
                throw new Exception(httpResponse + "\r\n" + jsonRequest);
        }
        else
            throw new Exception(httpResponse + "\r\n" + jsonRequest);

        return true;
    }
}

public static class CasHttpClientExtensions
{
    public static IServiceCollection AddHttpClient(this IServiceCollection services, string clientKey, string clientId, string url)
    {
        // TODO add http client request logger e.g. interceptor or decorator
        //Log.AppendLine("Sending Json: " + jsonRequest.ToString());
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("clientID", clientId);
        httpClient.DefaultRequestHeaders.Add("secret", clientKey);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.BaseAddress = new Uri(url);
        httpClient.Timeout = new TimeSpan(1, 0, 0);  // 1 hour timeout 

        services.AddHttpClient<ICasHttpClient, CasHttpClient>(serviceProvider => new CasHttpClient(httpClient));
        return services;
    }
}

using System.Threading.Tasks;
using System.Net.Http;
using SunInfo.Model;
using System;
using System.Net;
using Polly;
using Polly.Contrib.WaitAndRetry;

namespace SunInfo.Services;

public class NetworkService : INetworkService
{
    private readonly HttpClient _httpClient;
    private readonly Policy _retryPolicy;
    public NetworkService()
    {

        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://ipinfo.io")
        };

        var sleepDurations = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(1), retryCount: 3);

        _retryPolicy = Policy
            .Handle<Exception>()
            .WaitAndRetry(sleepDurations);
    }
    public async Task<NetworkInfoModel> GetNetworkInfo()
    {

        var response = await _retryPolicy.Execute(async () =>
        {
            var response = await _httpClient.GetAsync("/ipp");
            response.EnsureSuccessStatusCode();
            return response;
        });

        var content = await response.Content.ReadAsStringAsync();

        if (!IPAddress.TryParse(content, out var ip))
            throw new Exception("Invalid IP address format");

        var result = new NetworkInfoModel(ip.ToString());
        return result;
    }
}
public class FakeNetworkService : INetworkService
{
    public async Task<NetworkInfoModel> GetNetworkInfo()
    {
        await Task.Delay(250);
        return new NetworkInfoModel("83.65.28.114");
    }
}

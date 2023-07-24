using System.Threading.Tasks;
using System.Net.Http;
using SunInfo.Model;
using System;
using System.Net;
using System.Windows;

namespace SunInfo.Services;

public class NetworkService : INetworkService
{
    private readonly HttpClient _httpClient;
    public NetworkService()
    {
        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://ipinfo.io")
        };
    }
    public async Task<NetworkInfoModel> GetNetworkInfo()
    {
        //var ip = await _httpClient.GetStringAsync("/ip");

        var response = await _httpClient.GetAsync("/ip");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        //content = "";

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

using IP2Location;
using SunInfo.Model;
using System;
using System.Threading.Tasks;

namespace SunInfo.Services;

public class LocationService : ILocationService
{
    private readonly Component _component;
    private readonly INetworkService _networkService;

    public LocationService(INetworkService networkService)
    {
        _component = new Component();
        _component.Open("Resources\\IpData.BIN");
        _networkService = networkService;
    }

    public async Task<LocationInfoModel> GetLocationInfo()
    {
        var networkInfo = await _networkService.GetNetworkInfo();

        var ipInfo = _component.IPQuery(networkInfo.Ip);
        if (ipInfo is null)
            throw new Exception("Could not get location info");
        
        var result = new LocationInfoModel(
            ipInfo.Latitude, 
            ipInfo.Longitude, 
            ipInfo.City);
        return result;
    }
}

public class FakeLocationService : ILocationService
{
    public async Task<LocationInfoModel> GetLocationInfo()
    {
        await Task.Delay(200);
        return new LocationInfoModel(47.7f, 9.5f, "FakeCity");
    }
}

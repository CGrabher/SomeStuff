using System.Threading.Tasks;
using System.Net.Http;
using SunInfo.Model;
using System;

namespace SunInfo.Services
{
    internal class RealServices
    {
        public async Task<string> GetPublicIpAddress()
        {
            using var httpClient = new HttpClient();
            var ip = await httpClient.GetStringAsync("https://ipinfo.io/ip");
            return ip;
        }
    }

    public class SunInfoService : ISunInfoService
    {

        private readonly ILocationService _locationService;
        public SunInfoService(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<SunInfoModel> GetSunInfo()
        {
            var location = await _locationService.GetLocationInfo();

            await Task.Delay(1000);
            return new SunInfoModel
            {
                Sunrise = TimeSpan.FromSeconds(1900),
                Sunset = TimeSpan.FromSeconds(1900),
                City = location.City,
                Daylight = TimeSpan.FromSeconds(39231)
            };
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
    public class LocationService : ILocationService
    {
        private INetworkService _networkService;
        public LocationService(INetworkService networkService)
        {
            _networkService = networkService;
        }

        public async Task<LocationInfoModel> GetLocationInfo()
        {
            var networkInfo = await _networkService.GetNetworkInfo();
            //need ip here
            await Task.Delay(200);
            return new LocationInfoModel(47.7f, 9.5f, "FakeCity");
        }
    }

    public class FakeNetworkService : INetworkService
    {
        public async Task<NetworkInfoModel> GetNetworkInfo()
        {
            await Task.Delay(250);
            return new NetworkInfoModel("192.168.1.1");
        }
    }

    public class NetworkService : INetworkService
    {
        public async Task<NetworkInfoModel> GetNetworkInfo()
        {
            using var httpClient = new HttpClient();
            var ip = await httpClient.GetStringAsync("https://ipinfo.io/ip");
            return new NetworkInfoModel(ip);
        }
    }

    public interface ISunInfoService
    {
        Task<SunInfoModel> GetSunInfo();
    }

    public interface ILocationService
    {
        Task<LocationInfoModel> GetLocationInfo();
    }

    public interface INetworkService
    {
        Task<NetworkInfoModel> GetNetworkInfo();
    }
}
using System.Threading.Tasks;
using SunInfo.Model;
using System;
using Newtonsoft.Json;
using System.Net.Http;

namespace SunInfo.Services;

public class SunInfoService : ISunInfoService
{

    private readonly ILocationService _locationService;
    private readonly HttpClient _httpClient;
    public SunInfoService(ILocationService locationService)
    {
        _locationService = locationService;
        _httpClient = new HttpClient() 
        {
            BaseAddress = new Uri("https://api.sunrise-sunset.org")
        };
    }

    public async Task<SunInfoModel> GetSunInfo()
    {
        var location = await _locationService.GetLocationInfo();

        var url = $"/json?lat={location.Latitude}&lng={location.Longitude}&formatted=0";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
              
        var json = await response.Content.ReadAsStringAsync();
        var resp = JsonConvert.DeserializeObject<ApiResponse>(json);
        //var content = await response.Content.ReadFromJsonAsync<ApiResponse>();

        if (resp is null || resp.Status != "OK")
            throw new Exception("Could not get sun info from api");

        var content = resp.Results;
        var result = new SunInfoModel
        {
            Sunrise = content.Sunrise.ToLocalTime().TimeOfDay,
            Sunset = content.Sunset.ToLocalTime().TimeOfDay,
            City = location.City,
            Daylight = TimeSpan.FromSeconds(content.DayLength),
            Date = DateOnly.FromDateTime(content.Sunrise.ToLocalTime().Date)
        };
        return result;
    }

    public class ApiResponse
    {
        public ApiContent Results { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
    public class ApiContent
    {
        public DateTimeOffset Sunrise { get; set; }
        public DateTimeOffset Sunset { get; set; }

        [JsonProperty("day_length")]
        public long DayLength { get; set; }
    }
}

public class FakeSunInfoService : ISunInfoService
{
    public async Task<SunInfoModel> GetSunInfo()
    {
        await Task.Delay(3000);
        return new SunInfoModel
        {
            Sunrise = DateTime.Now.TimeOfDay,
            Sunset = DateTime.Now.TimeOfDay,
            Daylight = TimeSpan.FromMinutes(366),
            City = "FakeCity"
        };
    }
}
public class ErrorSunInfoService : ISunInfoService
{
    public async Task<SunInfoModel> GetSunInfo()
    {
        await Task.Delay(2000);
        throw new Exception("Error");
    }
}


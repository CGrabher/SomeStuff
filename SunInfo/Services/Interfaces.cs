using System.Threading.Tasks;
using SunInfo.Model;

namespace SunInfo.Services;

public interface INetworkService
{
    Task<NetworkInfoModel> GetNetworkInfo();
}
public interface ILocationService
{
    Task<LocationInfoModel> GetLocationInfo();
}
public interface ISunInfoService
{
    Task<SunInfoModel> GetSunInfo();
}


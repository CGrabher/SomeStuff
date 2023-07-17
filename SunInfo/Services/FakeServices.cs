using SunInfo.Model;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SunInfo.Services
{
    internal class FakeServices
    {

    }

    public class FakeSunInfoService : ISunInfoService
    {
        public async Task<SunInfoModel> GetSunInfo()
        {
            await Task.Delay(3000);
            return new SunInfoModel
            {
                Sunrise = DateTime.UtcNow.TimeOfDay,
                Sunset = DateTime.UtcNow.TimeOfDay
            };
        }
    }
}

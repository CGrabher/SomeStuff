using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SunInfo.Services;


namespace SunInfo.Model
{
    public class SunInfoModel
    {
        public TimeSpan Sunrise { get; set; }

        public TimeSpan Sunset { get; set; }

        public TimeSpan Daylight { get; set; }

        public string City { get; set; }



    }
}

using System;


namespace SunInfo.Model;

public class SunInfoModel
{
    public TimeSpan Sunrise { get; set; }
    public TimeSpan Sunset { get; set; }
    public TimeSpan Daylight { get; set; }
    public string City { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    

}

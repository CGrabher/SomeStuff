using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;

public class GeolocationService
{
    private readonly HttpClient _httpClient;

    public GeolocationService()
    {
        _httpClient = new HttpClient();
    }
}







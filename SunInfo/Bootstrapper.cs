using Microsoft.Extensions.DependencyInjection;
using SunInfo.Services;
using SunInfo.View;
using SunInfo.ViewModel;
using System;

namespace SunInfo;

public static class Bootstrapper
{
    public static IServiceProvider GetServiceProvider()
    {
        var result = new ServiceCollection()
              .AddServices()
              .AddWpfStuff()
              .BuildServiceProvider();
        return result;
    }
    public static IServiceCollection AddServices(this IServiceCollection sc)
    {
        sc.AddTransient<INetworkService, NetworkService>();
        sc.AddTransient<ILocationService, LocationService>();
        sc.AddTransient<ISunInfoService, SunInfoService>();
        return sc;
    }
    public static IServiceCollection AddWpfStuff(this IServiceCollection sc)
    {
        sc.AddTransient<SunInfoViewModel>();
        sc.AddTransient<MainWindow>();
        return sc;
    }
}

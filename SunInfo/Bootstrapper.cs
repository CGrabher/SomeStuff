using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using SunInfo.Services;
using SunInfo.View;
using SunInfo.ViewModel;
using System;

namespace SunInfo;

public static class Bootstrapper
{
    public static IServiceProvider GetServiceProvider()
    {
        var logger = new LoggerConfiguration()
            .WriteTo.File("log.txt")
            .CreateLogger();

        var result = new ServiceCollection()
            .AddServices()
            .AddWpfStuff()
            .AddLogging(builder => builder.AddSerilog(logger, dispose: true))
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

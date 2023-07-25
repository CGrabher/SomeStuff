using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SunInfo.Services;
using SunInfo.View;
using SunInfo.ViewModel;
using System.Windows;

namespace SunInfo;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var sp = Bootstrapper.GetServiceProvider(); 
        MainWindow = sp.GetRequiredService<MainWindow>();
        MainWindow.Show(); 
    }

}




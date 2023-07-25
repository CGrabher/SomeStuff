using Microsoft.Extensions.Logging;
using SunInfo.ViewModel;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.IO;
using System;

namespace SunInfo.View
{
    public partial class MainWindow : Window
    {
        private readonly ILogger<MainWindow> _logger;

        public MainWindow(SunInfoViewModel sunInfoViewModel, ILogger<MainWindow> logger)
        {
            var stopwatch = Stopwatch.StartNew();

            InitializeComponent();
            DataContext = sunInfoViewModel;

            stopwatch.Stop();

            _logger = logger;
            _logger.LogInformation("Das laden der Daten dauerte {ElapsedMilliseconds}ms.", stopwatch.ElapsedMilliseconds);
            _logger.LogInformation("MainWindow wurde geöffnet.");
        }
    }
}


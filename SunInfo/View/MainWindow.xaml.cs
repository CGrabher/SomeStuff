using SunInfo.Services;
using SunInfo.ViewModel;
using System.Windows;

namespace SunInfo.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new SunInfoViewModel(new SunInfoService(new LocationService(new NetworkService())));
        }
    }
}

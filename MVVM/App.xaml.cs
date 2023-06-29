using MVVM.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var viewModel = new ViewModel.PersonDataViewModel();
            var personWindow = new PersonDataView
            {
                DataContext = viewModel
            };


            MainWindow = personWindow;
            MainWindow.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
           
        }

    }
}

using System.Windows;
using TicTacToeWPF.View;
using TicTacToeWPF.ViewModel;

namespace TicTacToeWPF;


public partial class App : Application
{

    private void Application_Startup(object sender, StartupEventArgs e)
    {

        var view = new TicTacToeWindow()
        {
            DataContext = new TicTacToeViewModel()
        };


        MainWindow = view;
        MainWindow.Show();

    }

    private void Application_Exit(object sender, ExitEventArgs e)
    {

    }

}
using SatisfactorySmartHub.Presentation.Windows;
using System.Windows;

namespace SatisfactorySmartHub.Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        MainWindow _mainWindow;

        public App(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _mainWindow.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {

        }
    }
}

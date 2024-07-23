using SatisfactorySmartHub.Application.WindowModels;
using System.Windows;

namespace SatisfactorySmartHub.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowModel windowModel)
        {
            DataContext = windowModel;
            windowModel.HubCommand.Execute(this);
            InitializeComponent();
        }
    }
}

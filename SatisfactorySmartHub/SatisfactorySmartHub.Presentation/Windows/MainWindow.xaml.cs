using SatisfactorySmartHub.Application.PresentationModels.DialogModels;
using SatisfactorySmartHub.Application.PresentationModels.WindowModels;
using SatisfactorySmartHub.Presentation.Dialogs;
using System.Windows;

namespace SatisfactorySmartHub.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowModel _viewmodel;
        private readonly IServiceProvider _serviceProvider;

        public MainWindow(MainWindowModel windowModel, IServiceProvider serviceProvider)
        {
            _viewmodel = windowModel;
            _serviceProvider = serviceProvider;
            DataContext = _viewmodel;
            _viewmodel.HubCommand.Execute(this);
            _viewmodel.NavigationService.ShowSelectRecipeDialogEvent += NavigationService_ShowRecipeSelectionDialogEvent;
            InitializeComponent();
        }

        private void NavigationService_ShowRecipeSelectionDialogEvent(object? sender, EventArgs e)
        {
            SelectRecipeDialog? dialog = (SelectRecipeDialog?)_serviceProvider.GetService(typeof(SelectRecipeDialog));

            if (dialog == null)
                return;

            if (dialog.ShowDialog() == true)
            {
                SelectRecipeDialogModel viewModel = (SelectRecipeDialogModel)dialog.DataContext;
                _viewmodel.NavigationService.SetSelectRecipeDialogResult(viewModel.GetDialogResult());
            };
        }
    }
}

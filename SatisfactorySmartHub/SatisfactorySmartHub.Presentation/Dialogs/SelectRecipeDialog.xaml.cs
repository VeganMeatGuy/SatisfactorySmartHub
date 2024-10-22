using SatisfactorySmartHub.Application.PresentationModels.DialogModels;
using System.Windows;

namespace SatisfactorySmartHub.Presentation.Dialogs;

/// <summary>
/// Interaction logic for RecipeSelectionDialog.xaml
/// </summary>
public partial class SelectRecipeDialog : Window
{
    public SelectRecipeDialog(SelectRecipeDialogModel _viewModel)
    {
        DataContext = _viewModel;
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
}

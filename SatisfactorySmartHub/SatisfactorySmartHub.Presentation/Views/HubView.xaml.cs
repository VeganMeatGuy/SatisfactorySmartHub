using Microsoft.Win32;
using SatisfactorySmartHub.Application.ViewModels;
using System.Windows.Controls;

namespace SatisfactorySmartHub.Presentation.Views;

/// <summary>
/// Interaction logic for HomeView.xaml
/// </summary>
public partial class HubView : UserControl
{
    public HubView()
    {
        InitializeComponent();
    }

    private void LoadButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        string filepath;
        var openFileDialog = new OpenFileDialog()
        {
            Filter = "json-Datei | *.json",
            DefaultExt = "json",
        };

        if (openFileDialog.ShowDialog() == true)
        {
            filepath = openFileDialog.FileName;
        }
        else
            return;

        HubViewModel dc = (HubViewModel)DataContext;
        dc.ImportCorporation(filepath);
    }
}

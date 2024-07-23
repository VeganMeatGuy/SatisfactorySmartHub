using Microsoft.Win32;
using SatisfactorySmartHub.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SatisfactorySmartHub.Presentation.Views
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : UserControl
    {
        public AdminView()
        {
            InitializeComponent();
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            AdminViewModel dc = (AdminViewModel)DataContext;
            string filepath;


            var saveFileDialog = new SaveFileDialog()
            {
                Filter = "json-Datei | *.json",
                DefaultExt = "json",
                FileName = dc.ExportName,
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                filepath = saveFileDialog.FileName;
            }
            else
                return;

            dc.ExportCorporation(filepath);
        }

    }
}

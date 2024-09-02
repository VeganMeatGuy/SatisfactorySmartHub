using SatisfactorySmartHub.Application.Common;
using SatisfactorySmartHub.Domain.Models;
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

namespace SatisfactorySmartHub.Presentation.Controls
{
    /// <summary>
    /// Interaction logic for RecipeSelector.xaml
    /// </summary>
    public partial class RecipeSelectionDialog : UserControl
    {
        public RecipeSelectionDialog()
        {
            InitializeComponent();
        }

        public static DependencyProperty ConfirmProperty
        = DependencyProperty.Register("Confirm", typeof(ICommand), typeof(RecipeSelectionDialog));

        public ICommand Confirm
        {
            get { return (ICommand)GetValue(ConfirmProperty); }
            set { SetValue(ConfirmProperty, value); }
        }

        public static DependencyProperty RecipeListProperty
        = DependencyProperty.Register("RecipeList", typeof(ReadonlyObservableList<RecipeModel>), typeof(RecipeSelectionDialog));

        public ReadonlyObservableList<RecipeModel> RecipeList
        {
            get { return (ReadonlyObservableList<RecipeModel>)GetValue(RecipeListProperty); }
            set { SetValue(RecipeListProperty, value); }
        }

    }
}

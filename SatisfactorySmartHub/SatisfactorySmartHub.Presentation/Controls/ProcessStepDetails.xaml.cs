using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
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
    /// Interaction logic for ProcessStepDetails.xaml
    /// </summary>
    public partial class ProcessStepDetails : UserControl
    {
        public ProcessStepDetails()
        {
            InitializeComponent();
        }

        public static DependencyProperty SelectRecipeProperty
            = DependencyProperty.Register("SelectRecipe", typeof(ICommand), typeof(ProcessStepDetails));

        public ICommand SelectRecipe
        {
            get { return (ICommand)GetValue(SelectRecipeProperty); }
            set { SetValue(SelectRecipeProperty, value); }
        }

        public static DependencyProperty ProcessStepProperty
            = DependencyProperty.Register("ProcessStep", typeof(IProcessStepDto), typeof(ProcessStepDetails));
        
        public IProcessStepDto ProcessStep
        {
            get { return (IProcessStepDto)GetValue(ProcessStepProperty); }
            set { SetValue(ProcessStepProperty, value); }
        }

        public string RecipeButtonText => test1 == false ? "Rezept auswählen..." : "Rezept ändern...";

        public bool test1 => ProcessStep.RecipeId == null ? false : true;

    }
}

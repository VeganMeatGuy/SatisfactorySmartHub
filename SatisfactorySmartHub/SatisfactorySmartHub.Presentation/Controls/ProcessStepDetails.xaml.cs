using SatisfactorySmartHub.Application.DataTranferObjects;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            = DependencyProperty.Register("ProcessStep", typeof(ProcessStepDto), typeof(ProcessStepDetails));

        public ProcessStepDto ProcessStep
        {
            get { return (ProcessStepDto)GetValue(ProcessStepProperty); }
            set { SetValue(ProcessStepProperty, value); }
        }

        public string RecipeButtonText => test1 == false ? "Rezept auswählen..." : "Rezept ändern...";

        public bool test1 => ProcessStep.RecipeId == null ? false : true;

    }
}

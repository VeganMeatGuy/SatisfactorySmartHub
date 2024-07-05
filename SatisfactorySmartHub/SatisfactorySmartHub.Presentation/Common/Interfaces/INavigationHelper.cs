using SatisfactorySmartHub.Presentation.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Presentation.Common.Interfaces
{
    public interface INavigationHelper
    {
        /// <summary>
        /// The current view model.
        /// </summary>
        ViewModelBase CurrentView { get; }

        /// <summary>
        /// Navigates to the provided view model.
        /// </summary>
        /// <typeparam name="T">The view model to navigate to.</typeparam>
        void NavigateMainWindowTo<T>() where T : ViewModelBase;
    }
}

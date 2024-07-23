using SatisfactorySmartHub.Application.ViewModels.Base;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;

public interface INavigationService
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

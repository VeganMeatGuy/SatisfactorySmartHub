using SatisfactorySmartHub.Application.ViewModels.Base;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;

public interface INavigationService
{
    /// <summary>
    /// The current view model.
    /// </summary>
    ViewModelBase CurrentMainView { get; }

    /// <summary>
    /// Navigates to the provided view model.
    /// </summary>
    /// <typeparam name="T">The view model to navigate to.</typeparam>
    void NavigateMainViewTo<T>() where T : ViewModelBase;

    /// <summary>
    /// The current view model.
    /// </summary>
    ViewModelBase CurrentAdminView { get; }

    /// <summary>
    /// Navigates to the provided view model.
    /// </summary>
    /// <typeparam name="T">The view model to navigate to.</typeparam>
    void NavigateAdminViewTo<T>() where T : ViewModelBase;
}

using ErrorOr;
using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects.DialogResults;
using SatisfactorySmartHub.Application.PresentationModels.ViewModels.Base;
using System.ComponentModel;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;

public interface INavigationService : INotifyPropertyChanged
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


    event EventHandler ShowSelectRecipeDialogEvent;
    void SetSelectRecipeDialogResult(ISelectRecipeDialogResult result);
    ErrorOr<ISelectRecipeDialogResult> ShowSelectRecipeDialog();
}

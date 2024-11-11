using ErrorOr;
using SatisfactorySmartHub.Application.DataTranferObjects.DialogResults;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.PresentationModels.ViewModels.Base;
using SatisfactorySmartHub.Domain.Common;

namespace SatisfactorySmartHub.Application.Services;
public sealed class NavigationService(Func<Type, ViewModelBase> viewModelFactory) : ObservableObjectBase, INavigationService
{
    private ViewModelBase _currentMainView = default!;
    private ViewModelBase _currentAdminView = default!;


    private SelectRecipeDialogResult? _recipeSelectionDialogResult;


    public ViewModelBase CurrentMainView
    {
        get => _currentMainView;
        private set => SetProperty(ref _currentMainView, value);
    }

    public ViewModelBase CurrentAdminView
    {
        get => _currentAdminView;
        private set => SetProperty(ref _currentAdminView, value);
    }

    public event EventHandler ShowSelectRecipeDialogEvent;

    public void NavigateAdminViewTo<T>() where T : ViewModelBase
    => CurrentAdminView = viewModelFactory.Invoke(typeof(T));

    public void NavigateMainViewTo<T>() where T : ViewModelBase
        => CurrentMainView = viewModelFactory.Invoke(typeof(T));

    public void SetSelectRecipeDialogResult(SelectRecipeDialogResult result)
    {
        _recipeSelectionDialogResult = result;
    }

    public ErrorOr<SelectRecipeDialogResult> ShowSelectRecipeDialog()
    {
        _recipeSelectionDialogResult = null;

        //invoke Event, Presentation has chance to chance to call the SetRecipeSelectionDialogResult method and set the DialogResult
        ShowSelectRecipeDialogEvent?.Invoke(this, EventArgs.Empty);

        if (_recipeSelectionDialogResult == null)
            return Error.Failure();

        SelectRecipeDialogResult DialogResult = (SelectRecipeDialogResult)_recipeSelectionDialogResult;

        SelectRecipeDialogResult returnValue = DialogResult;
        _recipeSelectionDialogResult = null;

        return returnValue;
    }
}

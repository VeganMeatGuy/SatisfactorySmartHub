using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.ViewModels.Base;
using SatisfactorySmartHub.Domain.Common;

namespace SatisfactorySmartHub.Application.Services;
public sealed class NavigationService(Func<Type, ViewModelBase> viewModelFactory) : ObservableObjectBase, INavigationService
{
    private ViewModelBase _currentMainView = default!;
    private ViewModelBase _currentAdminView = default!;

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

    public void NavigateAdminViewTo<T>() where T : ViewModelBase
    => CurrentAdminView = viewModelFactory.Invoke(typeof(T));

    public void NavigateMainViewTo<T>() where T : ViewModelBase
        => CurrentMainView = viewModelFactory.Invoke(typeof(T));

}

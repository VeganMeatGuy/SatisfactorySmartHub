using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.ViewModels.Base;
using SatisfactorySmartHub.Domain.Common;

namespace SatisfactorySmartHub.Application.Services;
public sealed class NavigationService(Func<Type, ViewModelBase> viewModelFactory) : ObservableObjectBase, INavigationService
{
    private ViewModelBase _currentView = default!;

    public ViewModelBase CurrentView
    {
        get => _currentView;
        private set => SetProperty(ref _currentView, value);
    }

    public void NavigateMainWindowTo<T>() where T : ViewModelBase
        => CurrentView = viewModelFactory.Invoke(typeof(T));

}

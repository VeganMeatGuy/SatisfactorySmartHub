using SatisfactorySmartHub.Domain.Common;
using SatisfactorySmartHub.Presentation.Common.Interfaces;
using SatisfactorySmartHub.Presentation.ViewModels.Base;

namespace SatisfactorySmartHub.Presentation.Common
{
    public sealed class MainNavigationHelper(Func<Type, ViewModelBase> viewModelFactory) : ObservableObjectBase, INavigationHelper
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
}

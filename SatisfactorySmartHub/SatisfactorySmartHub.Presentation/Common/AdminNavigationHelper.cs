using SatisfactorySmartHub.Domain.Common;
using SatisfactorySmartHub.Presentation.Common.Interfaces;
using SatisfactorySmartHub.Presentation.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Presentation.Common;

public sealed class AdminNavigationHelper(Func<Type, ViewModelBase> viewModelFactory) : ObservableObjectBase, INavigationHelper
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

using SatisfactorySmartHub.Presentation.Common.Interfaces;
using SatisfactorySmartHub.Presentation.Common;
using SatisfactorySmartHub.Presentation.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace SatisfactorySmartHub.Presentation.ViewModels;

public sealed class AdminViewModel(AdminNavigationHelper navigationHelper) : ViewModelBase
{
    private IRelayCommand? _corporationCommand;

    public INavigationHelper NavigationHelper => navigationHelper;

    public IRelayCommand CorporationCommand => _corporationCommand ??= new RelayCommand(NavigationHelper.NavigateMainWindowTo<CorporationViewModel>);

}

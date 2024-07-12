using CommunityToolkit.Mvvm.Input;
using SatisfactorySmartHub.Presentation.Common;
using SatisfactorySmartHub.Presentation.Common.Interfaces;
using SatisfactorySmartHub.Presentation.ViewModels;
using SatisfactorySmartHub.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Presentation.WindowModels;

public sealed class MainWindowModel(INavigationHelper navigationHelper)
{
    private IRelayCommand? _hubCommand;
    private IRelayCommand? _adminCommand;

    public INavigationHelper NavigationHelper => navigationHelper;

    public IRelayCommand HubCommand => _hubCommand ??= new RelayCommand(NavigationHelper.NavigateMainWindowTo<HubViewModel>);

    public IRelayCommand AdminCommand => _adminCommand ??= new RelayCommand(NavigationHelper.NavigateMainWindowTo<AdminViewModel>);
}

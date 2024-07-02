using CommunityToolkit.Mvvm.Input;
using SatisfactorySmartHub.Presentation.Common;
using SatisfactorySmartHub.Presentation.Common.Interfaces;
using SatisfactorySmartHub.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Presentation.WindowModels;

public sealed class MainWindowModel(INavigationHelper navigationHelper)
{
    private IRelayCommand? _homeCommand;

    public INavigationHelper NavigationHelper => navigationHelper;

    public IRelayCommand HomeCommand => _homeCommand ??= new RelayCommand(NavigationHelper.NavigateTo<HubViewModel>);
}

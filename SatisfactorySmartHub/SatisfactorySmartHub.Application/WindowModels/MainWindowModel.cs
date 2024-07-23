using CommunityToolkit.Mvvm.Input;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.ViewModels;

namespace SatisfactorySmartHub.Application.WindowModels;

public sealed class MainWindowModel(INavigationService navigationHelper)
{
    private IRelayCommand? _hubCommand;
    private IRelayCommand? _adminCommand;

    public INavigationService NavigationHelper => navigationHelper;

    public IRelayCommand HubCommand => _hubCommand ??= new RelayCommand(NavigationHelper.NavigateMainWindowTo<HubViewModel>);

    public IRelayCommand AdminCommand => _adminCommand ??= new RelayCommand(NavigationHelper.NavigateMainWindowTo<AdminViewModel>);
}

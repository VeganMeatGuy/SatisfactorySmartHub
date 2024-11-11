using CommunityToolkit.Mvvm.Input;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.PresentationModels.ViewModels;
using SatisfactorySmartHub.Application.PresentationModels.ViewModels.Base;

namespace SatisfactorySmartHub.Application.PresentationModels.WindowModels;

public sealed class MainWindowModel(INavigationService navigationService) : ViewModelBase
{
    private IRelayCommand? _hubCommand;
    private IRelayCommand? _adminCommand;

    public INavigationService NavigationService => navigationService;

    public IRelayCommand HubCommand => _hubCommand ??= new RelayCommand(NavigationService.NavigateMainViewTo<HubViewModel>);

    public IRelayCommand AdminCommand => _adminCommand ??= new RelayCommand(NavigationService.NavigateMainViewTo<AdminViewModel>);
}

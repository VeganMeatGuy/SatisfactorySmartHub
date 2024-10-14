using CommunityToolkit.Mvvm.Input;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Application.ViewModels.Base;
using SatisfactorySmartHub.Domain.Common;
using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Application.ViewModels;

public sealed class AdminViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;

    private IRelayCommand? _corporationCommand;
    private IRelayCommand? _branchCommand;

    private bool _corporationViewIsShown;
    private bool _branchViewIsShown;
    private bool _powerPlantViewIsShown;
    private bool _logisticsViewIsShown;

    public AdminViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        _navigationService.PropertyChanged += (s,e) => NavigationChanged();
        CorporationCommand.Execute(this);
    }

    public INavigationService NavigationService => _navigationService;
    public IRelayCommand CorporationCommand => _corporationCommand ??= new RelayCommand(NavigationService.NavigateAdminViewTo<CorporationViewModel>);
    public IRelayCommand BranchCommand => _branchCommand ??= new RelayCommand(NavigationService.NavigateAdminViewTo<BranchViewModel>);

    public bool CorporationViewIsShown
    {
        get => _corporationViewIsShown;
        set => SetProperty(ref _corporationViewIsShown, value);
    }

    public bool BranchViewIsShown
    {
        get => _branchViewIsShown;
        set => SetProperty(ref _branchViewIsShown, value);
    }

    public bool PowerPlantViewIsShown
    {
        get => _powerPlantViewIsShown;
        set => SetProperty(ref _powerPlantViewIsShown, value);
    }

    public bool LogisticsViewIsShown
    {
        get => _logisticsViewIsShown;
        set => SetProperty(ref _logisticsViewIsShown, value);
    }
    private void NavigationChanged()
    {
        if (_navigationService.CurrentAdminView == null)
            return;

        switch (_navigationService.CurrentAdminView)
        {
            case CorporationViewModel _:
                CorporationViewIsShown = true;
                break;
            case BranchViewModel _:
                BranchViewIsShown = true;
                break;
            default:
                break;
        }
    }



}

using CommunityToolkit.Mvvm.Input;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.ViewModels.Base;
using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Application.ViewModels;

public sealed class CorporationViewModel : ViewModelBase
{
    private readonly ICachingService _cachingService;
    private readonly INavigationService _navigationService;
    private IRelayCommand? _addBranchCommand;

    public CorporationViewModel(ICachingService cachingService, INavigationService navigationService)
    {
        _cachingService = cachingService;
        _navigationService = navigationService;
    }

    public IRelayCommand AddBranchCommand => _addBranchCommand ??= new RelayCommand(new Action(AddBranch));
    public CorporationModel ActiveCorporation => _cachingService.ActiveCorporation;

    private void AddBranch()
    {
        _navigationService.NavigateAdminViewTo<BranchViewModel>();
    }
}

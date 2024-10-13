using CommunityToolkit.Mvvm.Input;
using SatisfactorySmartHub.Application.DataTranferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Services;
using SatisfactorySmartHub.Application.ViewModels.Base;
using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Application.ViewModels;

public sealed class CorporationViewModel : ViewModelBase
{
    private readonly ICachingService _cachingService;
    private readonly INavigationService _navigationService;
    private readonly ICorporationService _corporationService;
    private readonly IBranchService _branchService;

    private IRelayCommand? _addBranchCommand;
    private IRelayCommand? _showBranchDetailsCommand;

    private BranchModel _selectedBranchModel;

    public CorporationViewModel(ICachingService cachingService, INavigationService navigationService, ICorporationService corporationService, IBranchService branchService)
    {
        _cachingService = cachingService;
        _navigationService = navigationService;
        _corporationService = corporationService;
        _branchService = branchService;
    }

    public IRelayCommand AddBranchCommand => _addBranchCommand ??= new RelayCommand(new Action(AddBranch));
    public IRelayCommand ShowBranchDetailsCommand => _showBranchDetailsCommand ??= new RelayCommand(new Action(ShowBranchDetails));

    public ICorporationDto ActiveCorporation => _cachingService.ActiveCorporation;

    public BranchModel SelectedBranch
    {
        get => _selectedBranchModel;
        set => SetProperty(ref _selectedBranchModel, value);
    }

    private void AddBranch()
    {
        //CorporationDto? corporation = _cachingService.ActiveCorporation;

        //if (corporation == null)
        //    return;

        //BranchModel addedBranch = _branchService.GetNewBranch();

        //_corporationService.AddBranchToCorporation(addedBranch, corporation);
        //_cachingService.SetActiveBranch(addedBranch);
        //_navigationService.NavigateAdminViewTo<BranchViewModel>();
    }

    private void ShowBranchDetails()
    {
        _cachingService.SetActiveBranch(_selectedBranchModel);
        _navigationService.NavigateAdminViewTo<BranchViewModel>();
    }
}

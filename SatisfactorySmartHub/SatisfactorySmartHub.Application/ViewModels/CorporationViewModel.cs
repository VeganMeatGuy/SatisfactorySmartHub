using CommunityToolkit.Mvvm.Input;
using ErrorOr;
using SatisfactorySmartHub.Application.Common;
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

    private IRelayCommand? _saveCorporationCommand;
    private IRelayCommand? _addBranchCommand;
    private IRelayCommand? _showBranchDetailsCommand;

    private List<IBranchDto> _branchesDisplayDataSource = [];
    private ReadonlyObservableList<IBranchDto> _branches = new();
    private IBranchDto? _selectedBranchModel;

    public CorporationViewModel(ICachingService cachingService, INavigationService navigationService, ICorporationService corporationService, IBranchService branchService)
    {
        _cachingService = cachingService;
        _navigationService = navigationService;
        _corporationService = corporationService;
        _branchService = branchService;

        UpdateBranchesDataSource();
        _branches = new ReadonlyObservableList<IBranchDto>(_branchesDisplayDataSource);

    }

    private ErrorOr<Success> UpdateBranchesDataSource()
    {
        _branchesDisplayDataSource.Clear();
        _branchesDisplayDataSource.AddRange(_branchService.) // get branches for IDCorp (IGenericRepo.getbyCondition)
    }

    public IRelayCommand SaveCorporationCommand => _saveCorporationCommand ??= new RelayCommand(new Action(SaveCorporation));
    public IRelayCommand AddBranchCommand => _addBranchCommand ??= new RelayCommand(new Action(AddBranch));
    public IRelayCommand ShowBranchDetailsCommand => _showBranchDetailsCommand ??= new RelayCommand(new Action(ShowBranchDetails));

    public ICorporationDto ActiveCorporation => _cachingService.ActiveCorporation;

    public IBranchDto? SelectedBranch
    {
        get => _selectedBranchModel;
        set => SetProperty(ref _selectedBranchModel, value);
    }

    private void ShowBranchDetails()
    {
        _cachingService.SetActiveBranch(_selectedBranchModel);
        _navigationService.NavigateAdminViewTo<BranchViewModel>();
    }

    private void SaveCorporation()
    {
        ErrorOr<Updated> result = _corporationService.UpdateCorporation(ActiveCorporation);
    }

    private void AddBranch()
    {
        ICorporationDto? corporation = _cachingService.ActiveCorporation;

        if (corporation == null)
            return;

        ErrorOr<IBranchDto> addBranchResult = _branchService.AddBranch("new Branch");

        if (addBranchResult.IsError)
            return;

        ErrorOr<Success> AddBranchToCorporationResult = _corporationService.AddBranchToCorporation(addBranchResult.Value, ActiveCorporation);

        if (AddBranchToCorporationResult.IsError)
            return;

        //_cachingService.SetActiveBranch(addBranchResult.Value);

        //_navigationService.NavigateAdminViewTo<BranchViewModel>();
    }


}

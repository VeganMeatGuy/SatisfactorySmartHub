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
    private readonly ICorporationService _corporationService;
    private readonly ICachingService _cachingService;
    private readonly IUserDataService _userOptionsHelper;

    private IRelayCommand? _corporationCommand;
    private IRelayCommand? _branchCommand;
    private IRelayCommand? _saveCommand;

    private bool _corporationViewIsShown;
    private bool _branchViewIsShown;
    private bool _powerPlantViewIsShown;
    private bool _logisticsViewIsShown;

    private string _saveHint = string.Empty;
    private bool _exportPossible = false;

    public AdminViewModel(
        INavigationService navigationService,
        ICorporationService corporationService,
        ICachingService cachingService,
        IUserDataService userOptionsHelper)
    {
        _navigationService = navigationService;
        _corporationService = corporationService;
        _cachingService = cachingService;
        _userOptionsHelper = userOptionsHelper;

        _navigationService.PropertyChanged += (s,e) => NavigationChanged();

        CorporationCommand.Execute(this);
    }

    public INavigationService NavigationService => _navigationService;
    public string SaveHint
    {
        get => _saveHint;
        set => SetProperty(ref _saveHint, value);
    }
    public bool ExportPossible => _cachingService.ActiveCorporationIsSet;

    public string ExportName => _cachingService.ActiveCorporation.Name ?? string.Empty;

    public IRelayCommand CorporationCommand => _corporationCommand ??= new RelayCommand(NavigationService.NavigateAdminViewTo<CorporationViewModel>);
    public IRelayCommand BranchCommand => _branchCommand ??= new RelayCommand(NavigationService.NavigateAdminViewTo<BranchViewModel>);
    public IRelayCommand SaveCommand => _saveCommand ?? new RelayCommand(new Action(SaveCorporation));

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



    public void ExportCorporation(string filepath)
    {
        //CorporationModel exportCorporation = _cachingService.ActiveCorporation;
        //_corporationService.ExportCorporation(exportCorporation, filepath);
        //SaveHint = "Export erfolgreich.";
    }

    private void SaveCorporation()
    {
        //if (_cachingService.ActiveCorporation == null)
        //{
        //    SaveHint = "Kein Konzern zum speichern geladen.";
        //    return;
        //}

        //bool overWrite = _userOptionsHelper.GetUserData().OverWriteSaveFile;

        //_corporationService.SaveCorporation(_cachingService.ActiveCorporation, overWrite);
        //SaveHint = "Speichern erfolgreich.";
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

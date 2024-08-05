using CommunityToolkit.Mvvm.Input;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Application.ViewModels.Base;
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
    private string _saveHint = string.Empty;
    private bool _exportPossible = false;

    public AdminViewModel(
        INavigationService navigationHelper,
        ICorporationService corporationService,
        ICachingService cachingService,
        IUserDataService userOptionsHelper)
    {
        _navigationService = navigationHelper;
        _corporationService = corporationService;
        _cachingService = cachingService;
        _userOptionsHelper = userOptionsHelper;

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


    public void ExportCorporation(string filepath)
    {
        CorporationModel exportCorporation = _cachingService.ActiveCorporation;
        _corporationService.ExportCorporation(exportCorporation, filepath);
        SaveHint = "Export erfolgreich.";
    }

    private void SaveCorporation()
    {
        if (_cachingService.ActiveCorporation == null)
        {
            SaveHint = "Kein Konzern zum speichern geladen.";
            return;
        }

        bool overWrite = _userOptionsHelper.GetUserData().OverWriteSaveFile;

        _corporationService.SaveCorporation(_cachingService.ActiveCorporation, overWrite);
        SaveHint = "Speichern erfolgreich.";
    }

 

}

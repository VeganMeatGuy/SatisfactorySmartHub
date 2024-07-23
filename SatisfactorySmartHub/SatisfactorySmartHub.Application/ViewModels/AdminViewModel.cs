using CommunityToolkit.Mvvm.Input;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Application.ViewModels.Base;
using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Application.ViewModels;

public sealed class AdminViewModel : ViewModelBase
{
    private readonly INavigationService _navigationHelper;
    private readonly ICorporationService _corporationService;
    private readonly ICachingService _cachingService;
    private readonly IUserDataService _userOptionsHelper;

    private IRelayCommand? _corporationCommand;
    private IRelayCommand? _saveCommand;
    private string _saveHint = string.Empty;
    private bool _exportPossible = false;

    public AdminViewModel(
        INavigationService navigationHelper,
        ICorporationService corporationService,
        ICachingService cachingService,
        IUserDataService userOptionsHelper)
    {
        _navigationHelper = navigationHelper;
        _corporationService = corporationService;
        _cachingService = cachingService;
        _userOptionsHelper = userOptionsHelper;

        CorporationCommand.Execute(this);

        if (_cachingService.ActiveCorporation is not null)
            ExportPossible = true;

    }

    public INavigationService NavigationHelper => _navigationHelper;
    public string SaveHint
    {
        get => _saveHint;
        set => SetProperty(ref _saveHint, value);
    }
    public bool ExportPossible
    {
        get => _exportPossible;
        set => SetProperty(ref _exportPossible, value);
    }
    public string ExportName => _cachingService.ActiveCorporation.Name ?? string.Empty;

    public IRelayCommand CorporationCommand => _corporationCommand ??= new RelayCommand(NavigationHelper.NavigateMainWindowTo<CorporationViewModel>);
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

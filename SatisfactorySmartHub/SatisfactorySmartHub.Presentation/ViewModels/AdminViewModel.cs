using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Domain.Models;
using SatisfactorySmartHub.Presentation.Common;
using SatisfactorySmartHub.Presentation.Common.Interfaces;
using SatisfactorySmartHub.Presentation.Interfaces.Services;
using SatisfactorySmartHub.Presentation.ViewModels.Base;

namespace SatisfactorySmartHub.Presentation.ViewModels;

public sealed class AdminViewModel : ViewModelBase
{
    private readonly INavigationHelper _navigationHelper;
    private readonly ICorporationService _corporationService;
    private readonly ICachingService _cachingService;
    private readonly IUserDataService _userOptionsHelper;

    private IRelayCommand? _corporationCommand;
    private IRelayCommand? _saveCommand;
    private IRelayCommand? _exportCommand;
    private string _saveHint = string.Empty;

    public AdminViewModel(
        INavigationHelper navigationHelper,
        ICorporationService corporationService,
        ICachingService cachingService,
        IUserDataService userOptionsHelper)
    {
        _navigationHelper = navigationHelper;
        _corporationService = corporationService;
        _cachingService = cachingService;
        _userOptionsHelper = userOptionsHelper;

        CorporationCommand.Execute(this);
    }

    public INavigationHelper NavigationHelper => _navigationHelper;
    public string SaveHint
    {
        get => _saveHint;
        set => SetProperty(ref _saveHint, value);
    }

    public IRelayCommand CorporationCommand => _corporationCommand ??= new RelayCommand(NavigationHelper.NavigateMainWindowTo<CorporationViewModel>);
    public IRelayCommand SaveCommand => _saveCommand ?? new RelayCommand(new Action(SaveCorporation));
    public IRelayCommand ExportCommand => _exportCommand ?? new RelayCommand(new Action(ExportCorporation));

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

    private void ExportCorporation()
    {
        if (_cachingService.ActiveCorporation == null)
        {
            SaveHint = "Kein Konzern zum exportieren geladen.";
            return;
        }

        string filepath;

        var saveFileDialog = new SaveFileDialog()
        {
            Filter = "json-Datei | *.json",
            DefaultExt = "json",
            FileName = _cachingService.ActiveCorporation.Name,
        };

        if (saveFileDialog.ShowDialog() == true)
        {
            filepath = saveFileDialog.FileName;
        }
        else
            return;

        CorporationModel exportCorporation = _cachingService.ActiveCorporation;
        _corporationService.ExportCorporation(exportCorporation, filepath);
        SaveHint = "Export erfolgreich.";
    }

}

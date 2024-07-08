using SatisfactorySmartHub.Presentation.Common.Interfaces;
using SatisfactorySmartHub.Presentation.Common;
using SatisfactorySmartHub.Presentation.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using Microsoft.Win32;
using SatisfactorySmartHub.Presentation.Interfaces.Services;
using SatisfactorySmartHub.Presentation.Services;
using SatisfactorySmartHub.Domain.Models;
using System.IO;

namespace SatisfactorySmartHub.Presentation.ViewModels;

public sealed class AdminViewModel : ViewModelBase
{
    private readonly AdminNavigationHelper _navigationHelper;
    private readonly ICorporationService _corporationService;
    private readonly ICachingService _cachingService;

    private IRelayCommand? _corporationCommand;
    private IRelayCommand? _saveCommand;
    private IRelayCommand? _exportCommand;
    private string _saveHint = string.Empty;

    public AdminViewModel(AdminNavigationHelper navigationHelper, ICorporationService corporationService, ICachingService cachingService)
    {
        _navigationHelper = navigationHelper;
        _corporationService = corporationService;
        _cachingService = cachingService;

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

        _corporationService.SaveCorporation(_cachingService.ActiveCorporation, true);
        SaveHint = "Speichern erfolgreich.";
    }

    private void ExportCorporation()
    {
        if (_cachingService.ActiveCorporation == null)
        {
            SaveHint = "Kein Konzern zum exportieren geladen.";
            return;
        }

        string folderPath;

        var openFolderDialog = new OpenFolderDialog();

        if (openFolderDialog.ShowDialog() == true)
        {
            folderPath = openFolderDialog.FolderName;
        }
        else
            return;

        CorporationModel exportCorporation = _cachingService.ActiveCorporation;
        _corporationService.ExportCorporation(exportCorporation, folderPath);
        SaveHint = "Export erfolgreich.";
    }

}

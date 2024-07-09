using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Domain.Models;
using SatisfactorySmartHub.Presentation.Common;
using SatisfactorySmartHub.Presentation.Common.Interfaces;
using SatisfactorySmartHub.Presentation.Interfaces.Services;
using SatisfactorySmartHub.Presentation.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SatisfactorySmartHub.Presentation.ViewModels;

public sealed class HubViewModel : ViewModelBase
{
    private readonly ICorporationService _corporationService;
    private readonly ICachingService _cachingService;
    private readonly IUserOptionsHelper _userOptionsHelper;


    private IRelayCommand? _loadCompanyCommand;
    private IRelayCommand? _createCompanyCommand;
    private IRelayCommand? _overWriteSaveFileCommand;
    private string _corporationName = string.Empty;
    private string _createHint = string.Empty;
    private string _loadHint = string.Empty;
    private bool _overWriteSaveFile;


    public HubViewModel(ICorporationService corporationService, ICachingService cachingService, IUserOptionsHelper userOptionsHelper)
    {
        _corporationService = corporationService;
        _cachingService = cachingService;
        _userOptionsHelper = userOptionsHelper;

        if (cachingService.ActiveCorporation != null)
            LoadHint = $"{cachingService.ActiveCorporation.Name} ist aktuell geladen.";

        OverWriteSaveFile = _userOptionsHelper.GetUserOptions().OverWriteSaveFile;
    }

    public IRelayCommand CreateCompanyCommand => _createCompanyCommand ?? new RelayCommand(new Action(CreateCompany));
    public IRelayCommand LoadCompanyCommand => _loadCompanyCommand ?? new RelayCommand(new Action(LoadCompany));
    public IRelayCommand OverWriteSaveFileCommand => _overWriteSaveFileCommand ?? new RelayCommand(new Action(ChangeOverWriteSaveFileOption));

    public string CorporationName
    {
        get => _corporationName;
        set => SetProperty(ref _corporationName, value);
    }

    public string CreateHint
    {
        get => _createHint;
        set => SetProperty(ref _createHint, value);
    }

    public string LoadHint
    {
        get => _loadHint;
        set => SetProperty(ref _loadHint, value);
    }

    public bool OverWriteSaveFile
    {
        get => _overWriteSaveFile;
        set => SetProperty(ref _overWriteSaveFile, value);
    }

    private void CreateCompany()
    {
        if (CorporationName == string.Empty)
        {
            CreateHint = "Vergebe bitte einen Namen für deinen Konzern.";
            return;
        }

        _cachingService.ActiveCorporation = _corporationService.GetNewCorporation(CorporationName);

        CreateHint = $"{_cachingService.ActiveCorporation.Name} wurde erfolgreich erstellt.";

        LoadHint = $"{_cachingService.ActiveCorporation.Name} ist aktuell geladen.";
    }

    private void ChangeOverWriteSaveFileOption()
    {
        IUserOptions Options = _userOptionsHelper.GetUserOptions();
        Options.OverWriteSaveFile = OverWriteSaveFile;
        _userOptionsHelper.SetUserOptions(Options);
    }

    private void LoadCompany()
    {

    }
}

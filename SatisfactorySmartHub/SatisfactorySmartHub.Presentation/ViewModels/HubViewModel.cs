using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Domain.Models;
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


    private IRelayCommand? _loadCompanyCommand;
    private IRelayCommand? _createCompanyCommand;
    private string _corporationName = string.Empty;
    private string _createHint = string.Empty;
    private string _loadHint = string.Empty;


    public HubViewModel(ICorporationService corporationService, ICachingService cachingService)
    {
        _corporationService = corporationService;
        _cachingService = cachingService;

        if (cachingService.ActiveCorporation != null)
            LoadHint = $"{cachingService.ActiveCorporation.Name} ist aktuell geladen.";
    }

    public IRelayCommand CreateCompanyCommand => _createCompanyCommand ?? new RelayCommand(new Action(CreateCompany));
    public IRelayCommand LoadCompanyCommand => _loadCompanyCommand ?? new RelayCommand(new Action(LoadCompany));

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





    private void LoadCompany()
    {

    }
}

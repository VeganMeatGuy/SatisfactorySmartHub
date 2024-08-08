using CommunityToolkit.Mvvm.Input;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Application.ViewModels.Base;
using SatisfactorySmartHub.Domain.Models;
using System.Collections.ObjectModel;

namespace SatisfactorySmartHub.Application.ViewModels;

public sealed class HubViewModel : ViewModelBase
{
    private readonly ICorporationService _corporationService;
    private readonly ICachingService _cachingService;
    private readonly IUserDataService _userOptionsHelper;

    private IRelayCommand? _createCorporationCommand;
    private IRelayCommand? _loadCorporationCommand;
    private IRelayCommand? _overWriteSaveFileCommand;
    private string _corporationName = string.Empty;
    private string _createHint = string.Empty;
    private string _loadHint = string.Empty;
    private bool _overWriteSaveFile;
    private ObservableCollection<string> _saveFiles = new();
    private string? _selectedSaveFile;

    public HubViewModel(
        ICorporationService corporationService,
        ICachingService cachingService,
        IUserDataService userOptionsHelper)
    {
        _corporationService = corporationService;
        _cachingService = cachingService;
        _userOptionsHelper = userOptionsHelper;

        if (_cachingService.ActiveCorporation != null)
            LoadHint = $"{_cachingService.ActiveCorporation.Name} ist aktuell geladen.";
        else
            LoadHint = $"kein Konzern geladen.";

        OverWriteSaveFile = _userOptionsHelper.GetUserData().OverWriteSaveFile;

        _saveFiles = new(_corporationService.GetSaveFiles());
    }

    public IRelayCommand CreateCorporationCommand => _createCorporationCommand ?? new RelayCommand(new Action(CreateCorporation));
    public IRelayCommand LoadCorporationCommand => _loadCorporationCommand ?? new RelayCommand(new Action(LoadCorporation));
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

    public ObservableCollection<string> SaveFiles
    {
        get => _saveFiles;
        set => SetProperty(ref _saveFiles, value);
    }

    public string? SelectedSaveFile
    {
        get => _selectedSaveFile;
        set => SetProperty(ref _selectedSaveFile, value);
    }


    public void ImportCorporation(string filePath)
    {
        _cachingService.SetActiveCorporation(_corporationService.GetCorporationFromFile(filePath));
        LoadHint = $"{_cachingService.ActiveCorporation.Name} ist aktuell geladen.";
    }

    private void CreateCorporation()
    {
        if (CorporationName == string.Empty)
        {
            CreateHint = "Vergebe bitte einen Namen für deinen Konzern.";
            return;
        }

        _cachingService.SetActiveCorporation(_corporationService.GetNewCorporation(CorporationName));

        CreateHint = string.Empty;

        LoadHint = $"{_cachingService.ActiveCorporation.Name} wurde erstellt und ist geladen.";
    }

    private void ChangeOverWriteSaveFileOption()
    {
        UserDataModel Options = _userOptionsHelper.GetUserData();
        Options.OverWriteSaveFile = OverWriteSaveFile;
        _userOptionsHelper.SetUserData(Options);
    }

    private void LoadCorporation()
    {
        if (SelectedSaveFile == null)
        {
            LoadHint = "Bitte Speicherdatei auswählen.";
            return;
        }

        _cachingService.SetActiveCorporation(_corporationService.GetCorporationFromFile(SelectedSaveFile));
        LoadHint = $"{_cachingService.ActiveCorporation.Name} ist aktuell geladen.";

    }

}

using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Domain.Models;
using SatisfactorySmartHub.Presentation.Common.Interfaces;
using SatisfactorySmartHub.Presentation.Interfaces.Services;
using SatisfactorySmartHub.Presentation.Services;
using SatisfactorySmartHub.Presentation.ViewModels.Base;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace SatisfactorySmartHub.Presentation.ViewModels;

public sealed class HubViewModel : ViewModelBase
{
    private readonly ICorporationService _corporationService;
    private readonly ICachingService _cachingService;
    private readonly IUserOptionsHelper _userOptionsHelper;

    private IRelayCommand? _createCorporationCommand;
    private IRelayCommand? _loadCorporationCommand;
    private IRelayCommand? _importCorporationCommand;
    private IRelayCommand? _overWriteSaveFileCommand;
    private string _corporationName = string.Empty;
    private string _createHint = string.Empty;
    private string _loadHint = string.Empty;
    private bool _overWriteSaveFile;
    private ObservableCollection<FileInfo> _saveFiles = new();
    private FileInfo? _selectedSaveFile;

    public HubViewModel(
        ICorporationService corporationService,
        ICachingService cachingService,
        IUserOptionsHelper userOptionsHelper)
    {
        _corporationService = corporationService;
        _cachingService = cachingService;
        _userOptionsHelper = userOptionsHelper;

        if (_cachingService.ActiveCorporation != null)
            LoadHint = $"{_cachingService.ActiveCorporation.Name} ist aktuell geladen.";
        else
            LoadHint = $"kein Konzern geladen.";

        OverWriteSaveFile = _userOptionsHelper.GetUserOptions().OverWriteSaveFile;

        _saveFiles = new(_corporationService.GetSaveFiles());
    }

    public IRelayCommand CreateCorporationCommand => _createCorporationCommand ?? new RelayCommand(new Action(CreateCorporation));
    public IRelayCommand LoadCorporationCommand => _loadCorporationCommand ?? new RelayCommand(new Action(LoadCorporation));
    public IRelayCommand ImportCorporationCommand => _importCorporationCommand ?? new RelayCommand(new Action(ImportCorporation));
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

    public ObservableCollection<FileInfo> SaveFiles
    {
        get => _saveFiles;
        set => SetProperty(ref _saveFiles, value);
    }

    public FileInfo? SelectedSaveFile
    {
        get => _selectedSaveFile;
        set => SetProperty(ref _selectedSaveFile, value);
    }

    private void CreateCorporation()
    {
        if (CorporationName == string.Empty)
        {
            CreateHint = "Vergebe bitte einen Namen für deinen Konzern.";
            return;
        }

        _cachingService.ActiveCorporation = _corporationService.GetNewCorporation(CorporationName);

        CreateHint = string.Empty;

        LoadHint = $"{_cachingService.ActiveCorporation.Name} wurde erstellt und ist geladen.";
    }

    private void ChangeOverWriteSaveFileOption()
    {
        IUserOptions Options = _userOptionsHelper.GetUserOptions();
        Options.OverWriteSaveFile = OverWriteSaveFile;
        _userOptionsHelper.SetUserOptions(Options);
    }

    private void LoadCorporation()
    {
        if (SelectedSaveFile == null)
        {
            LoadHint = "Bitte Speicherdatei auswählen.";
            return;
        }
        
        _cachingService.ActiveCorporation = _corporationService.GetCorporationFromFile(SelectedSaveFile.FullName);
        LoadHint = $"{_cachingService.ActiveCorporation.Name} ist aktuell geladen.";

    }

    private void ImportCorporation()
    {
        string filepath;

        var openFileDialog = new OpenFileDialog()
        {
            Filter = "json-Datei | *.json",
            DefaultExt = "json",
        };

        if (openFileDialog.ShowDialog() == true)
        {
            filepath = openFileDialog.FileName;
        }
        else
            return;

        _cachingService.ActiveCorporation = _corporationService.GetCorporationFromFile(filepath);
        LoadHint = $"{_cachingService.ActiveCorporation.Name} ist aktuell geladen.";
    }
}

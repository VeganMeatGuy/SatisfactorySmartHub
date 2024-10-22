using CommunityToolkit.Mvvm.Input;
using ErrorOr;
using SatisfactorySmartHub.Application.Common;
using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Application.PresentationModels.ViewModels.Base;
using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Application.PresentationModels.ViewModels;

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

    private List<ICorporationDto> _coporationsDisplayedDataSource = [];
    private ReadonlyObservableList<ICorporationDto> _corporations = new();
    private ICorporationDto? _selectedCorporation;

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

        UpdateCorporationsDataSource();
        _corporations = new ReadonlyObservableList<ICorporationDto>(_coporationsDisplayedDataSource);
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

    public ReadonlyObservableList<ICorporationDto> Corporations
    {
        get => _corporations;
        set => SetProperty(ref _corporations, value);
    }

    public ICorporationDto? SelectedCorporation
    {
        get => _selectedCorporation;
        set => SetProperty(ref _selectedCorporation, value);
    }


    private void CreateCorporation()
    {
        if (CorporationName == string.Empty)
        {
            CreateHint = "Vergebe bitte einen Namen für deinen Konzern.";
            return;
        }

        ErrorOr<ICorporationDto> AddCorporationResult = _corporationService.AddCorporation(CorporationName);

        if (AddCorporationResult.IsError)
        {
            CreateHint = $"Fehler: {AddCorporationResult.FirstError.Description}";
            return;
        }

        _cachingService.SetActiveCorporation(AddCorporationResult.Value);

        CreateHint = string.Empty;

        LoadHint = $"{_cachingService.ActiveCorporation.Name} wurde erstellt und ist geladen.";

        UpdateCorporationsDataSource();

    }

    private void ChangeOverWriteSaveFileOption()
    {
        UserDataModel Options = _userOptionsHelper.GetUserData();
        Options.OverWriteSaveFile = OverWriteSaveFile;
        _userOptionsHelper.SetUserData(Options);
    }

    private void LoadCorporation()
    {
        if (SelectedCorporation == null)
        {
            LoadHint = "Bitte Konzern auswählen.";
            return;
        }

        _cachingService.SetActiveCorporation(SelectedCorporation);
        LoadHint = $"{_cachingService.ActiveCorporation.Name} ist aktuell geladen.";
    }

    private ErrorOr<Success> UpdateCorporationsDataSource()
    {
        try
        {
            _coporationsDisplayedDataSource.Clear();
            _coporationsDisplayedDataSource.AddRange(_corporationService.GetCorporations());
            Corporations.Update();
            return Result.Success;
        }
        catch (Exception ex)
        {
            return Error.Unexpected("HubViewModel.UpdateCorporationsDataSource", ex.Message);
        }
    }
}

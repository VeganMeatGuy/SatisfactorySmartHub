using CommunityToolkit.Mvvm.Input;
using ErrorOr;
using SatisfactorySmartHub.Application.Common;
using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.PresentationModels.ViewModels.Base;
using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Application.PresentationModels.ViewModels;

public sealed class BranchViewModel : ViewModelBase
{
    private readonly ICachingService _cachingService;
    private readonly IBranchService _branchService;
    private readonly IProcessStepService _processStepService;
    private readonly INavigationService _navigationService;
    private readonly IRecipeService _recipeService;


    private bool _showForeFrontContent = false;
    private bool _recipeSelectionVisible = false;

    private IRelayCommand? _saveBranchCommand;
    private IRelayCommand? _addProcessStepCommand;
    private IRelayCommand? _removeProcessStepCommand;
    private IRelayCommand? _selectProcessStepRecipeCommand;


    private IRelayCommand? _recipeSelectionConfirmedCommand;

    private List<IProcessStepDto> _processStepsDisplayDataSource = [];
    private ReadonlyObservableList<IProcessStepDto> _processSteps = new();
    private IProcessStepDto _SelectedProcessStep;

    private ReadonlyObservableList<RecipeModel> _recipeList = new ReadonlyObservableList<RecipeModel>();
    private RecipeModel _selectedRecipe;

    public BranchViewModel(
        ICachingService cachingService,
        IBranchService branchService,
        IProcessStepService processStepService,
        INavigationService navigationService,
        IRecipeService recipeService)
    {
        _cachingService = cachingService;
        _branchService = branchService;
        _processStepService = processStepService;
        _navigationService = navigationService;
        _recipeService = recipeService;

        LoadRecipes();

        if (ActiveBranch == null)
            return;

        UpdateProcessStepDataSource();
        _processSteps = new ReadonlyObservableList<IProcessStepDto>(_processStepsDisplayDataSource);
    }

    public IBranchDto ActiveBranch => _cachingService.ActiveBranch;
    public IProcessStepDto SelectedProcessStep
    {
        get => _SelectedProcessStep;
        set => SetProperty(ref _SelectedProcessStep, value);
    }
    public ReadonlyObservableList<IProcessStepDto> ProcessSteps => _processSteps;

    public IRelayCommand SaveBranchCommand => _saveBranchCommand ?? new RelayCommand(new Action(SaveBranch));
    public IRelayCommand AddProcessStepCommand => _addProcessStepCommand ?? new RelayCommand(new Action(AddProcessStep));
    public IRelayCommand RemoveProcessStepCommand => _removeProcessStepCommand ?? new RelayCommand(new Action(RemoveProcessStep));
    public IRelayCommand SelectProcessStepRecipeCommand => _selectProcessStepRecipeCommand ?? new RelayCommand(new Action(SelectProcessStepRecipe));

    private ErrorOr<Success> UpdateProcessStepDataSource()
    {
        _processStepsDisplayDataSource.Clear();

        var result = _processStepService.GetProcessStepsOfBranch(_cachingService.ActiveBranch.Id);

        _processStepsDisplayDataSource.AddRange(result.Value);
        ProcessSteps.Update();
        return Result.Success;
    }

    private void SaveBranch()
    {
        ErrorOr<Updated> result = _branchService.UpdateBranch(ActiveBranch);
    }

    private void AddProcessStep()
    {
        IBranchDto branch = _cachingService.ActiveBranch;

        if (branch == null)
            return;

        ErrorOr<IProcessStepDto> addProcessStepResult = _processStepService.AddProcessStep(branch.Id);

        if (addProcessStepResult.IsError)
            return;

        UpdateProcessStepDataSource();
    }

    private void RemoveProcessStep()
    {
        if (SelectedProcessStep == null)
            return;

        _processStepService.DeleteProcessStep(SelectedProcessStep);

        UpdateProcessStepDataSource();
    }

    private void SelectProcessStepRecipe()
    {

        var result = _navigationService.ShowSelectRecipeDialog();

        return;

        //öffne Dialog um Rezept auszuwählen
        // --> navigation service show RecipeSelectionDialog



        ///if(NavigationService.ShowRecipeSelectionDialog() == True)
        ///{
        ///
        ///}

        //var saveFileDialog = new SaveFileDialog()
        //{
        //    Filter = "json-Datei | *.json",
        //        DefaultExt = "json",
        //        FileName = dc.ExportName,
        //    };

        //if (saveFileDialog.ShowDialog() == true)
        //{
        //    filepath = saveFileDialog.FileName;
        //}

        throw new NotImplementedException();
    }



    // old>

    public bool ShowForeFrontContent
    {
        get => _showForeFrontContent;
        set => SetProperty(ref _showForeFrontContent, value);
    }
    public bool RecipeSelectionVisible
    {
        get => _recipeSelectionVisible;
        set => SetProperty(ref _recipeSelectionVisible, value);
    }
    public RecipeModel? SelectedRecipe
    {
        get => _selectedRecipe;
        set => SetProperty(ref _selectedRecipe, value);
    }
    public ReadonlyObservableList<RecipeModel> RecipeList => _recipeList;



    public IRelayCommand RecipeSelectionConfirmedCommand => _recipeSelectionConfirmedCommand ?? new RelayCommand(new Action(RecipeSelectionConfirmed));


    private void RecipeSelectionConfirmed()
    {
        //if (SelectedRecipe != null)
        //{
        //    SelectedProcessStep.Recipe = SelectedRecipe;
        //}

        //ProcessSteps.Update();

        //SelectedRecipe = null;
        //ShowForeFrontContent = false;
        //RecipeSelectionVisible = false;
    }

    private void ShowRecipeSelection()
    {
        if (SelectedProcessStep == null)
            return;
        ShowForeFrontContent = true;
        RecipeSelectionVisible = true;
    }



    private void LoadRecipes()
    {
        _recipeList = new ReadonlyObservableList<RecipeModel>(_recipeService.GetAllRecipes());
    }
}

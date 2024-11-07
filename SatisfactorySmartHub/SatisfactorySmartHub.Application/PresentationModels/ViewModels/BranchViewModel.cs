using CommunityToolkit.Mvvm.Input;
using ErrorOr;
using SatisfactorySmartHub.Application.Common;
using SatisfactorySmartHub.Application.DataTranferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.PresentationModels.ViewModels.Base;

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
    private IRelayCommand<IProcessStepDto>? _selectProcessStepRecipeCommand;


    private IRelayCommand? _recipeSelectionConfirmedCommand;

    private List<IProcessStepDto> _processStepsDisplayDataSource = [];
    private ReadonlyObservableList<IProcessStepDto> _processSteps = new();
    private IProcessStepDto _SelectedProcessStep;

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

        //LoadRecipes();

        if (ActiveBranch == null)
            return;

        UpdateProcessStepDataSource();
        _processSteps = new ReadonlyObservableList<IProcessStepDto>(_processStepsDisplayDataSource);
    }

    public BranchDto ActiveBranch => _cachingService.ActiveBranch;
    public IProcessStepDto SelectedProcessStep
    {
        get => _SelectedProcessStep;
        set => SetProperty(ref _SelectedProcessStep, value);
    }
    public ReadonlyObservableList<IProcessStepDto> ProcessSteps => _processSteps;

    public IRelayCommand SaveBranchCommand => _saveBranchCommand ?? new RelayCommand(new Action(SaveBranch));
    public IRelayCommand AddProcessStepCommand => _addProcessStepCommand ?? new RelayCommand(new Action(AddProcessStep));
    public IRelayCommand RemoveProcessStepCommand => _removeProcessStepCommand ?? new RelayCommand(new Action(RemoveProcessStep));
    public IRelayCommand<IProcessStepDto> SelectProcessStepRecipeCommand => _selectProcessStepRecipeCommand ?? new RelayCommand<IProcessStepDto>(SelectProcessStepRecipe);

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
        BranchDto branch = _cachingService.ActiveBranch;

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

    private void SelectProcessStepRecipe(IProcessStepDto? processStep)
    {

        if (processStep == null)
            return;

        var result = _navigationService.ShowSelectRecipeDialog();


        var addRecipeToProcessStepResult = _processStepService.AddRecipeToProcessStep(processStep, result.Value.RecipeId);

        if (addRecipeToProcessStepResult.IsError)
            return;

        UpdateProcessStepDataSource();
        return;
    }
}

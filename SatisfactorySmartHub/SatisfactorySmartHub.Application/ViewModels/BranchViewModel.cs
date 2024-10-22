using CommunityToolkit.Mvvm.Input;
using ErrorOr;
using SatisfactorySmartHub.Application.Common;
using SatisfactorySmartHub.Application.DataTranferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Services;
using SatisfactorySmartHub.Application.ViewModels.Base;
using SatisfactorySmartHub.Domain.Common;
using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.ViewModels;

public sealed class BranchViewModel : ViewModelBase
{
    private readonly ICachingService _cachingService;
    private readonly IBranchService _branchService;
    private readonly IProcessStepService _processStepService;
    private readonly IRecipeService _recipeService;


    private bool _showForeFrontContent = false;
    private bool _recipeSelectionVisible = false;

    private IRelayCommand? _saveBranchCommand;
    private IRelayCommand? _addProcessStepCommand;
    private IRelayCommand? _removeProcessStepCommand;


    private IRelayCommand? _selectRecipeCommand;
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
        IRecipeService recipeService)
    {
        _cachingService = cachingService;
        _branchService = branchService;
        _processStepService = processStepService;
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


    public IRelayCommand SelectRecipeCommand => _selectRecipeCommand ?? new RelayCommand(new Action(ShowRecipeSelection));
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

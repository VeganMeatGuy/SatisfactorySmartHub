using CommunityToolkit.Mvvm.Input;
using SatisfactorySmartHub.Application.Common;
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
    private readonly IProductionSiteService _productionSiteService;
    private readonly IProcessStepService _processStepService;
    private readonly IRecipeService _recipeService;


    private ProcessStepModel _activeProcessStepModel;
    private bool _showForeFrontContent = false;
    private bool _recipeSelectionVisible = false;
    private IRelayCommand? _addProcessStepCommand;
    private IRelayCommand? _removeProcessStepCommand;
    private IRelayCommand? _selectRecipeCommand;
    private IRelayCommand? _recipeSelectionConfirmedCommand;
    private ReadonlyObservableList<ProcessStepModel> _processSteps = new ReadonlyObservableList<ProcessStepModel>();
    private ReadonlyObservableList<RecipeModel> _recipeList = new ReadonlyObservableList<RecipeModel>();
    private RecipeModel _selectedRecipe;

    public BranchViewModel(
        ICachingService cachingService,
        IProductionSiteService productionSiteService,
        IProcessStepService processStepService,
        IRecipeService recipeService)
    {
        _cachingService = cachingService;
        _productionSiteService = productionSiteService;
        _processStepService = processStepService;
        _recipeService = recipeService;

        LoadRecipes();


        if (ActiveBranch == null)
            return;

        _processSteps = new ReadonlyObservableList<ProcessStepModel>(ActiveBranch.ProductionSite.ProcessSteps);
    }

    public BranchModel ActiveBranch => _cachingService.ActiveBranch;

    public ProcessStepModel SelectedProcessStep
    {
        get => _activeProcessStepModel;
        set => SetProperty(ref _activeProcessStepModel, value);
    }

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

    public ReadonlyObservableList<ProcessStepModel> ProcessSteps => _processSteps;

    public ReadonlyObservableList<RecipeModel> RecipeList => _recipeList;

    public IRelayCommand AddProcessStepCommand => _addProcessStepCommand ?? new RelayCommand(new Action(AddProcessStep));
    public IRelayCommand RemoveProcessStepCommand => _removeProcessStepCommand ?? new RelayCommand(new Action(RemoveProcessStep));
    public IRelayCommand SelectRecipeCommand => _selectRecipeCommand ?? new RelayCommand(new Action(ShowRecipeSelection));
    public IRelayCommand RecipeSelectionConfirmedCommand => _recipeSelectionConfirmedCommand ?? new RelayCommand(new Action(RecipeSelectionConfirmed));

    private void RecipeSelectionConfirmed()
    {
        var bla = SelectedRecipe;

        SelectedProcessStep.Recipe = SelectedRecipe;
        SelectedRecipe = null;
        ShowForeFrontContent = false;
        RecipeSelectionVisible = false;
    }

    private void ShowRecipeSelection()
    {
        var one = RecipeList;
        ShowForeFrontContent = true;
        RecipeSelectionVisible = true;
    }

    private void AddProcessStep()
    {
        BranchModel? branch = _cachingService.ActiveBranch;

        if (branch == null)
            return;

        ProductionSiteModel productionSite = branch.ProductionSite;

        ProcessStepModel processStep = _processStepService.GetNewProcessStep();
        _productionSiteService.AddProcessStepToProductionSite(processStep, productionSite);

        ProcessSteps.Update();
    }

    private void RemoveProcessStep()
    {
        ProductionSiteModel? productionSite = _cachingService.ActiveBranch.ProductionSite;

        if (productionSite == null)
            return;

        _productionSiteService.RemoveProcessStepFromProductionSite(SelectedProcessStep, productionSite);

        ProcessSteps.Update();
    }

    private void LoadRecipes()
    {
        _recipeList = new ReadonlyObservableList<RecipeModel>(_recipeService.GetAllRecipes());
    }
}

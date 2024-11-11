using SatisfactorySmartHub.Application.Common;
using SatisfactorySmartHub.Application.DataTranferObjects;
using SatisfactorySmartHub.Application.DataTranferObjects.DialogResults;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.PresentationModels.ViewModels.Base;

namespace SatisfactorySmartHub.Application.PresentationModels.DialogModels;

public sealed class SelectRecipeDialogModel : ViewModelBase
{
    private List<RecipeDto> _recipeDisplayDataSource = [];
    private ReadonlyObservableList<RecipeDto> _recipes = new();
    private RecipeDto _selectedRecipe;

    public SelectRecipeDialogModel(IRecipeService recipeService)
    {
        _recipeDisplayDataSource.Clear();

        var result = recipeService.GetRecipes();

        _recipeDisplayDataSource.AddRange(result);

        _recipes = new ReadonlyObservableList<RecipeDto>(_recipeDisplayDataSource);
    }

    public ReadonlyObservableList<RecipeDto> Recipes => _recipes;

    public RecipeDto SelectedRecipe
    {
        get => _selectedRecipe;
        set => SetProperty(ref _selectedRecipe, value);
    }



    public SelectRecipeDialogResult GetDialogResult()
    {
        return new SelectRecipeDialogResult(SelectedRecipe.Id);
    }
}

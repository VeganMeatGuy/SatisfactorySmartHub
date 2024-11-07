using SatisfactorySmartHub.Application.Common;
using SatisfactorySmartHub.Application.DataTranferObjects.DialogResults;
using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.PresentationModels.ViewModels.Base;

namespace SatisfactorySmartHub.Application.PresentationModels.DialogModels;

public sealed class SelectRecipeDialogModel : ViewModelBase
{
    private List<IRecipeDto> _recipeDisplayDataSource = [];
    private ReadonlyObservableList<IRecipeDto> _recipes = new();
    private IRecipeDto _selectedRecipe;

    public SelectRecipeDialogModel(IRecipeService recipeService)
    {
        _recipeDisplayDataSource.Clear();

        var result = recipeService.GetRecipes();

        _recipeDisplayDataSource.AddRange(result);

        _recipes = new ReadonlyObservableList<IRecipeDto>(_recipeDisplayDataSource);
    }

    public ReadonlyObservableList<IRecipeDto> Recipes => _recipes;

    public IRecipeDto SelectedRecipe
    {
        get => _selectedRecipe;
        set => SetProperty(ref _selectedRecipe, value);
    }



    public SelectRecipeDialogResult GetDialogResult()
    {
        return new SelectRecipeDialogResult(SelectedRecipe.Id);
    }
}

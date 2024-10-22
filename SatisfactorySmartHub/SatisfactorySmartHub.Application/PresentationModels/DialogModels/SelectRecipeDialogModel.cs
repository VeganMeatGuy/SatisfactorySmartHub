using SatisfactorySmartHub.Application.DataTranferObjects.DialogResults;
using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects.DialogResults;
using SatisfactorySmartHub.Application.PresentationModels.ViewModels.Base;

namespace SatisfactorySmartHub.Application.PresentationModels.DialogModels;

public sealed class SelectRecipeDialogModel : ViewModelBase
{
    private Guid _recipeId = Guid.Empty;
    public Guid RecipeId
    {
        get => _recipeId;
        set => SetProperty(ref _recipeId, value);
    }

    public ISelectRecipeDialogResult GetDialogResult()
    {
        return new SelectRecipeDialogResult() { RecipeId = RecipeId };
    }
}

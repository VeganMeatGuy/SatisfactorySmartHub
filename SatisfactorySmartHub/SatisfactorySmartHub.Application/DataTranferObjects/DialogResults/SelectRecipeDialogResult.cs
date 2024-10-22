using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects.DialogResults;

namespace SatisfactorySmartHub.Application.DataTranferObjects.DialogResults;

internal sealed class SelectRecipeDialogResult : ISelectRecipeDialogResult
{
    public Guid RecipeId { get; set; }

    public static SelectRecipeDialogResult Clone(SelectRecipeDialogResult og)
    {
        return new() { RecipeId = og.RecipeId };
    }
}

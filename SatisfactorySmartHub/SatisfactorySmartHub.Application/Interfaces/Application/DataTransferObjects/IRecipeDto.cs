using SatisfactorySmartHub.Application.DataTranferObjects;

namespace SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;

public interface IRecipeDto
{
    Guid Id { get; }
    string Name { get; }
    IMachineDto Machine { get; }
    IReadOnlyList<IItemWithAmountDto> Ingredients { get; }
    IItemWithAmountDto MainProduct { get; }
    IReadOnlyList<IItemWithAmountDto> ByProducts { get; }
}

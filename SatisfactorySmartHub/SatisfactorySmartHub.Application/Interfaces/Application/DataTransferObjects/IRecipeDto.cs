using SatisfactorySmartHub.Application.DataTranferObjects;

namespace SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;

public interface IRecipeDto
{
    Guid Id { get; }
    string Name { get; }
    MachineDto Machine { get; }
    IReadOnlyList<ItemWithAmountDto> Ingredients { get; }
    ItemWithAmountDto MainProduct { get; }
    IReadOnlyList<ItemWithAmountDto> ByProducts { get; }
}

using SatisfactorySmartHub.Application.DataTranferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;

namespace SatisfactorySmartHub.Application.Interfaces.Application;

public interface IRecipeDto
{
    Guid Id { get; }
    string Name { get; }
    string MachineName { get; }
    IReadOnlyList<IItemWithAmountDto> Ingredients { get; }
    IItemWithAmountDto MainProduct { get; }
    IReadOnlyList<IItemWithAmountDto> ByProducts { get; }
}

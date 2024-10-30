using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Domain.Interfaces.Entities.Base;

namespace SatisfactorySmartHub.Application.DataTranferObjects;

internal sealed class ItemWithAmountDto : IItemWithAmountDto
{
    public Guid ItemId { get; init; }

    public string ItemName { get; init; }

    public decimal Amount { get; init; } = 0m;

    internal static ItemWithAmountDto CreateFromEntity(IItemWithAmountBase itemWithAmount)
    {
        return new() { ItemId = itemWithAmount.ItemId, ItemName = itemWithAmount.Item.Name, Amount = itemWithAmount.Amount };
    }

}

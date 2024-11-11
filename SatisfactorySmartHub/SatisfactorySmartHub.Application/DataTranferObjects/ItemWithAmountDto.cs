using SatisfactorySmartHub.Domain.Interfaces.Entities.Base;

namespace SatisfactorySmartHub.Application.DataTranferObjects;

public sealed record ItemWithAmountDto(Guid ItemId, string ItemName, decimal Amount)
{
    internal static ItemWithAmountDto CreateFromEntity(IItemWithAmountBase itemWithAmount)
    {
        return new(itemWithAmount.ItemId, itemWithAmount.Item.Name, itemWithAmount.Amount);
    }

}

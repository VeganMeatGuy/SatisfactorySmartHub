namespace SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;

public interface IItemWithAmountDto
{
    Guid ItemId { get; }
    string ItemName { get; }
    decimal Amount { get; }
}

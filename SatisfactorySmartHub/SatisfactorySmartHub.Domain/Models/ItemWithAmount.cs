namespace SatisfactorySmartHub.Domain.Models;

public sealed class ItemWithAmount
{
    private ItemModel _item = new();
    private decimal _amount = 0;

    public ItemModel Item
    {
        get => _item;
        set => _item = value;
    }

    public decimal Amount
    {
        get => _amount;
        set => _amount = value;
    }
}

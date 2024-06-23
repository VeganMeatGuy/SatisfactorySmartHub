namespace SatisfactorySmartHub.Domain.Models;

internal class ItemModel
{
    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set => _name = value;
    }
}

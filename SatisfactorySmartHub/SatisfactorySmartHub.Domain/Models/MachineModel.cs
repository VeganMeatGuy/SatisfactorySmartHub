namespace SatisfactorySmartHub.Domain.Models;

public sealed class MachineModel
{
    private string _name = string.Empty;
    private int _powerConsuption = 0;

    public string Name
    {
        get => _name;
        set => _name = value;
    }
    public int PowerConsumption
    {
        get => _powerConsuption;
        set => _powerConsuption = value;
    }
}

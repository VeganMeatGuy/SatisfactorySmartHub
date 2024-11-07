namespace SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;

public interface IMachineDto
{
    Guid Id { get; }
    string Name { get; }
    int PowerConsumption { get; }
}

using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Application.DataTranferObjects;

public sealed record MachineDto(Guid Id, string Name, int PowerConsumption)
{
    internal static MachineDto CreateFromEntity(Machine machine)
    {
        return new(machine.Id, machine.Name, machine.PowerConsumption);
    }
}

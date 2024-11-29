using ErrorOr;
using SatisfactorySmartHub.Domain.Entities.Base;
using SatisfactorySmartHub.Domain.Errors;

namespace SatisfactorySmartHub.Domain.Entities;

public sealed class Machine : IdentityEntityBase
{
    public string Name { get; init; } = string.Empty;
    public int PowerConsumption { get; init; }
    public static ErrorOr<Machine> Create(Guid id, string name, int powerConsumption)
    {
        if (id == Guid.Empty)
            return DomainErrors.MachineErrors.IdCanNotBeEmptyGuid;

        if (name == null)
            return DomainErrors.MachineErrors.NameCanNotBeNull;

        if (name == string.Empty)
            return DomainErrors.MachineErrors.NameCanNotBeEmpty;

        if (powerConsumption < 0)
            return DomainErrors.MachineErrors.PowerConsumptionCanNotBeNageative;

        var machine = new Machine
        {
            Id = id,
            Name = name,
            PowerConsumption = powerConsumption
        };
        return machine;
    }
}

using ErrorOr;
using SatisfactorySmartHub.Domain.Entities.Base;
using SatisfactorySmartHub.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Entities;

public sealed class Machine : EntityBase
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int PowerConsumption { get; init; }

    public static ErrorOr<Machine> Create(int id, string name, int powerConsumption)
    {
        if (name == null)
            return DomainErrors.Machine.MachineNameCannotBeNull;

        if (name == string.Empty)
            return DomainErrors.Machine.MachineNameCannotBeEmpty;

        var machine = new Machine
        {
            Id = id,
            Name = name,
            PowerConsumption = powerConsumption
        };
        return machine;
    }
}

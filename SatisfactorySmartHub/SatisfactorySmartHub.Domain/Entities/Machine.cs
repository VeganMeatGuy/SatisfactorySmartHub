using ErrorOr;
using SatisfactorySmartHub.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Entities;

public sealed class Machine
{
    //empty constructor for EF Core
    private Machine() { }

    public Guid Id { get; init; }
    public string Name { get; private set; }
    public int PowerConsumption { get; private set; }

    public static ErrorOr<Machine> Create(string name)
    {
        if (name == null)
            return DomainErrors.Machine.MachineNameCannotBeNull;

        if (name == string.Empty)
            return DomainErrors.Machine.MachineNameCannotBeEmpty;

        var machine = new Machine
        {
            Id = Guid.NewGuid(),
            Name = name
        };
        return machine;
    }
}

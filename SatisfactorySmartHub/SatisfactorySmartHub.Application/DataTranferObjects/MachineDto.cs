using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.DataTranferObjects;

internal sealed class MachineDto : IMachineDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int PowerConsumption { get; init; }

    internal static MachineDto CreateFromEntity(Machine machine)
    {
        return new() { Id = machine.Id, Name = machine.Name, PowerConsumption = machine.PowerConsumption };
    }
}

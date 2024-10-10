using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Data;

internal static partial class StaticData
{
    internal static IReadOnlyList<Machine> Machines => _machines;

    private static readonly IReadOnlyList<Machine> _machines =
        new List<Machine>()
        {
            Machine.Create(1, "Constructor",4).Value
            ,Machine.Create(2, "Assembler",15).Value
            ,Machine.Create(3, "Manufacturer",55).Value
            ,Machine.Create(4, "Refinery",30).Value
            ,Machine.Create(5, "Packager",10).Value
            ,Machine.Create(6, "Foundry",16).Value
            ,Machine.Create(7, "Smelter",4).Value
            ,Machine.Create(8, "Blender",75).Value
            ,Machine.Create(9, "Nuclear Power Plant",0).Value
            ,Machine.Create(10, "Converter",250).Value
            ,Machine.Create(11, "Quantum Encoder",1000).Value
            ,Machine.Create(12, "Particle Accelerator",1000).Value
            ,Machine.Create(13, "Equipment Workshop",0).Value
        };
}

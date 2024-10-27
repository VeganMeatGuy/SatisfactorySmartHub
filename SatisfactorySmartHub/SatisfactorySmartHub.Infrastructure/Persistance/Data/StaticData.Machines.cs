using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Data;

internal static partial class StaticData
{
    internal static IReadOnlyList<Machine> Machines => _machines;

    private static readonly IReadOnlyList<Machine> _machines =
        new List<Machine>()
        {
            Smelter
        };

    internal static Machine Smelter => Machine.Create(Guid.Parse("629893a3-3ae2-408f-8af5-70bcea9c1d19"), "Smelter", 4).Value;
}

using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Data;

internal static partial class StaticData
{
    internal static class ItemData
    {
        internal static IReadOnlyList<Item> Items => _items;

        private static readonly IReadOnlyList<Item> _items =
        new List<Item>()
        {
            IronOre,
            IronIngot,
            IronPlate,
            };

        internal static Item IronOre => Item.Create(Guid.Parse("6c944ca5-c6ba-4df4-a08e-c06134ba1472"), "Iron Ore").Value;
        internal static Item IronIngot => Item.Create(Guid.Parse("be5c74ec-52aa-400c-a1b4-3fd3ac9a5ee5"), "Iron Ingot").Value;
        internal static Item IronPlate => Item.Create(Guid.Parse("bb7bde8d-b9ce-4d68-a852-b16e621fa3a6"), "Iron Plate").Value;

    }
}

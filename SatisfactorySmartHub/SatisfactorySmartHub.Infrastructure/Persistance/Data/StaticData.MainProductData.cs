using SatisfactorySmartHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Data;

internal static partial class StaticData
{
    internal static class MainProductData
    {
        internal static IReadOnlyList<MainProduct> MainProducts => _mainProducts;

        private static readonly IReadOnlyList<MainProduct> _mainProducts =
            new List<MainProduct>()
            {
                MainProduct.Create(RecipeData.IronIngot.Id, ItemData.IronIngot.Id, 1).Value,
                MainProduct.Create(RecipeData.IronPlate.Id, ItemData.IronPlate.Id, 2).Value,
            };
    }
}

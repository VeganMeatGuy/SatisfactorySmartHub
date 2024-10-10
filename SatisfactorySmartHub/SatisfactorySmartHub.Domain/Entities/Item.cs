using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SatisfactorySmartHub.Domain.Entities.Base;
using SatisfactorySmartHub.Domain.Interfaces.Entities;

namespace SatisfactorySmartHub.Domain.Entities;

public sealed class Item : EntityBase
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;

    public static Item Create(int id, string name)
    {
        var item = new Item
        {
            Id = id,
            Name = name
        };
        return item;
    }

}

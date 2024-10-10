using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using SatisfactorySmartHub.Domain.Entities.Base;
using SatisfactorySmartHub.Domain.Errors;
using SatisfactorySmartHub.Domain.Interfaces.Entities;

namespace SatisfactorySmartHub.Domain.Entities;

public sealed class Item : EntityBase
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;

    public static ErrorOr<Item> Create(int id, string name)
    {
        if (id == 0)
            return DomainErrors.Item.ItemIdCannotBeZero;

        if (name == null)
            return DomainErrors.Item.ItemNameCannotBeNull;

        if (name == string.Empty)
            return DomainErrors.Item.ItemNameCannotBeEmpty;

        var item = new Item
        {
            Id = id,
            Name = name
        };
        return item;
    }

}

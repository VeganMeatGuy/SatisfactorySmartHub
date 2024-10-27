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

public sealed class Item : IdentityEntityBase
{
    //empty constructor for EF Core
    private Item() { }

    public string Name { get; init; } = string.Empty;

    public static ErrorOr<Item> Create(Guid id, string name)
    {
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

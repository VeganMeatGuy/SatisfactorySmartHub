using ErrorOr;
using SatisfactorySmartHub.Domain.Entities.Base;
using SatisfactorySmartHub.Domain.Errors;

namespace SatisfactorySmartHub.Domain.Entities;

public sealed class Item : IdentityEntityBase
{
    //empty constructor for EF Core
    private Item() { }

    public string Name { get; init; } = string.Empty;

    public static ErrorOr<Item> Create(Guid id, string name)
    {
        if (name == null)
            return DomainErrors.ItemErrors.NameCanNotBeNull;

        if (name == string.Empty)
            return DomainErrors.ItemErrors.NameCanNotBeEmpty;

        if (id == Guid.Empty)
            return DomainErrors.ItemErrors.IdCanNotBeEmptyGuid;

        var item = new Item
        {
            Id = id,
            Name = name
        };
        return item;
    }

}

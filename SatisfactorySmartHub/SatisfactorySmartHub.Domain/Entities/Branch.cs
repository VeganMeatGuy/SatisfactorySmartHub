using SatisfactorySmartHub.Domain.Entities.Base;

namespace SatisfactorySmartHub.Domain.Entities;

public sealed class Branch : IdentityEntityBase
{
    //empty constructor for EF Core
    private Branch() { }

    public string Name { get; private set; } = string.Empty;

    //foreign key
    public Guid? CorporationId { get; private set; }

    //navigational properties
    public Corporation? Corporation { get; private set; }

}

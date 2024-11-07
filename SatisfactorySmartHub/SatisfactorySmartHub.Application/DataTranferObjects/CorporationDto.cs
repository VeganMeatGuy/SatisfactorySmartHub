using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Application.DataTranferObjects;

public sealed record CorporationDto(Guid Id, string Name)
{
    internal static CorporationDto CreateFromEntity(Corporation corporation)
    {
        return new(corporation.Id, corporation.Name);
    }
}

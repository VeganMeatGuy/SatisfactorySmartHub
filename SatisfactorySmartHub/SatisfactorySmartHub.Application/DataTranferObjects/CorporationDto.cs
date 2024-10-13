using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Application.DataTranferObjects;

internal sealed class CorporationDto : ICorporationDto
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    internal static CorporationDto CreateFromEntity(Corporation corporation)
    {
        return new() { Id = corporation.Id, Name = corporation.Name };
    }
}

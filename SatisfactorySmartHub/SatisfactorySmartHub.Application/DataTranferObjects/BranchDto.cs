using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Application.DataTranferObjects;

public sealed record BranchDto(Guid Id, string Name, Guid? CorporationId)
{
    internal static BranchDto CreateFromEntity(Branch branch)
    {
        return new(branch.Id, branch.Name, branch.CorporationId);
    }
}

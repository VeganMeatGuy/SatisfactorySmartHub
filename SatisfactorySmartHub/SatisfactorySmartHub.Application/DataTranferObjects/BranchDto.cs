using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.DataTranferObjects;

public sealed record BranchDto(Guid Id, string Name, Guid? CorporationId)
{
    internal static BranchDto CreateFromEntity(Branch branch)
    {
        return new(branch.Id, branch.Name, branch.CorporationId);
    }
}

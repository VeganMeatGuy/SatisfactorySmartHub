using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.DataTranferObjects;

internal sealed class BranchDto : IBranchDto
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;

    public Guid? CorporationId { get; init; }

    internal static BranchDto CreateFromEntity(Branch branch)
    {
        return new() { Id = branch.Id, Name = branch.Name, CorporationId = branch.CorporationId };
    }
}

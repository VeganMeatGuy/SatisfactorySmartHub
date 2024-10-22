using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Application.DataTranferObjects;

internal sealed class ProcessStepDto : IProcessStepDto
{
    public Guid Id { get; init; }
    public Guid BranchId { get; init; }

    internal static ProcessStepDto CreateFromEntity(ProcessStep processStep)
    {
        return new()
        {
            Id = processStep.Id,
            BranchId = processStep.BranchId
        };
    }
}

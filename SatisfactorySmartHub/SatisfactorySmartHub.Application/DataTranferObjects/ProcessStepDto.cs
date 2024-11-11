using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Application.DataTranferObjects;

public sealed record ProcessStepDto(Guid Id, Guid BranchId, Guid? RecipeId)
{
    internal static ProcessStepDto CreateFromEntity(ProcessStep processStep)
    {
        return new(processStep.Id, processStep.BranchId, processStep.RecipeId);
    }
}

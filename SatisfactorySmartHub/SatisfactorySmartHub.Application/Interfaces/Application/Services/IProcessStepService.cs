using ErrorOr;
using SatisfactorySmartHub.Application.DataTranferObjects;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;

/// <summary>
/// The process step service interface.
/// </summary>
public interface IProcessStepService
{
    public ErrorOr<ProcessStepDto> AddProcessStep(Guid branchId);
    public ErrorOr<Updated> UpdateProcessStep(ProcessStepDto processStep);
    public ErrorOr<Deleted> DeleteProcessStep(ProcessStepDto processStep);
    public ErrorOr<IEnumerable<ProcessStepDto>> GetProcessStepsOfBranch(Guid branchId);
    ErrorOr<Success> AddRecipeToProcessStep(ProcessStepDto processStep, Guid recipeId);
}

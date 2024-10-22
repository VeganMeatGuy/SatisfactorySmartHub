using ErrorOr;
using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;

/// <summary>
/// The process step service interface.
/// </summary>
public interface IProcessStepService
{
    public ErrorOr<IProcessStepDto> AddProcessStep(Guid branchId);
    public ErrorOr<Updated> UpdateProcessStep(IProcessStepDto processStep);
    public ErrorOr<Deleted> DeleteProcessStep(IProcessStepDto processStep);
    public ErrorOr<IEnumerable<IProcessStepDto>> GetProcessStepsOfBranch(Guid branchId);
}

using ErrorOr;
using SatisfactorySmartHub.Application.DataTranferObjects;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;

/// <summary>
/// The branch service interface.
/// </summary>
public interface IBranchService
{
    public ErrorOr<BranchDto> AddBranch(string branchName);

    public ErrorOr<Updated> UpdateBranch(BranchDto branch);

    public ErrorOr<IEnumerable<BranchDto>> GetBranchesOfCorporation(Guid corporationId);
}

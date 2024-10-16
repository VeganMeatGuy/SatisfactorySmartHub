using ErrorOr;
using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;

/// <summary>
/// The branch service interface.
/// </summary>
public interface IBranchService
{
    public ErrorOr<IBranchDto> AddBranch(string branchName);

    public ErrorOr<Updated> UpdateBranch(IBranchDto branch);
}

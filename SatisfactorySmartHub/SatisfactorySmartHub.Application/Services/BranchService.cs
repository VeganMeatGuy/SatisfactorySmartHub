using ErrorOr;
using SatisfactorySmartHub.Application.DataTranferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Application.Services;

/// <summary>
/// The branch service class.
/// It implements  the <see cref="IBranchService"/> interface.
/// </summary>
internal sealed class BranchService(
    IRepositoryService repositoryService) : IBranchService
{
    public ErrorOr<IBranchDto> AddBranch(string branchName)
    {
        ErrorOr<Branch> CreateBranchResult = Branch.Create(branchName);

        if (CreateBranchResult.IsError)
        {
            //do something to error handling
            // something like: return ApplicationErrors.CorporationService.CorporationWasNotInDb;
            return Error.Unexpected();
        }

        Branch newBranch = CreateBranchResult.Value;

        Branch? dbBranch = repositoryService.BranchRepository.GetById(newBranch.Id);

        if (dbBranch != null)
        {
            return Error.Failure();
        }

        repositoryService.BranchRepository.Create(newBranch);

        return BranchDto.CreateFromEntity(newBranch);
    }

    public ErrorOr<IEnumerable<IBranchDto>> GetBranchesOfCorporation(Guid corporationId)
    {
        try
        {
            List<BranchDto> result = [];
            var reporResult = repositoryService.BranchRepository.GetManyByCondition(x => x.CorporationId == corporationId);

            foreach (Branch branch in reporResult)
            {
                result.Add(BranchDto.CreateFromEntity(branch));
            }

            return result;
        }
        catch (Exception ex)
        {
            return new List<BranchDto>();
        }
    }

    public ErrorOr<Updated> UpdateBranch(IBranchDto branch)
    {
        Branch? dbBranch = repositoryService.BranchRepository.GetById(branch.Id);

        if (dbBranch == null)
            return Error.Conflict();

        if (dbBranch.Name.Equals(branch.Name))
            return Error.Conflict();

        dbBranch.ChangeName(branch.Name);

        repositoryService.BranchRepository.Update(dbBranch);

        return Result.Updated;
    }
}

using ErrorOr;
using SatisfactorySmartHub.Application.DataTranferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Application.Services;

internal sealed class CorporationService(
    IRepositoryService repositoryService) : ICorporationService
{

    public IEnumerable<ICorporationDto> GetCorporations()
    {
        try
        {
            List<CorporationDto> result = new List<CorporationDto>();
            var repoResult = repositoryService.CorporationRepository.GetAll();

            foreach (Corporation corporation in repoResult)
                result.Add(CorporationDto.CreateFromEntity(corporation));
            return result;
        }
        catch
        {
            return new List<CorporationDto>();
        }
    }
    public ErrorOr<ICorporationDto> AddCorporation(string corporationName)
    {
        ErrorOr<Corporation> CreateCorporationResult = Corporation.Create(corporationName);

        if (CreateCorporationResult.IsError)
        {
            //do something to error handling
            // something like: return ApplicationErrors.CorporationService.CorporationWasNotInDb;
            return Error.Unexpected();
        }

        Corporation newCorporation = CreateCorporationResult.Value;

        Corporation? dbCorporation = repositoryService.CorporationRepository.GetById(newCorporation.Id);

        if (dbCorporation != null)
        {
            return Error.Failure();
        }

        repositoryService.CorporationRepository.Create(newCorporation);

        return CorporationDto.CreateFromEntity(newCorporation);
    }

    public ErrorOr<Updated> UpdateCorporation(ICorporationDto corporation)
    {
        Corporation? dbCorporation = repositoryService.CorporationRepository.GetById(corporation.Id);

        if (dbCorporation == null)
            return Error.Conflict();

        if (dbCorporation.Name.Equals(corporation.Name))
            return Error.Conflict();
            
        dbCorporation.ChangeName(corporation.Name);

        repositoryService.CorporationRepository.Update(dbCorporation);

        return Result.Updated;
    }
    
    public ErrorOr<Success> AddBranchToCorporation(IBranchDto branch, ICorporationDto corporation)
    {
        Corporation? dbCorporation = repositoryService.CorporationRepository.GetById(corporation.Id);

        if(dbCorporation == null)
            return Error.NotFound();

        Branch? dbBranch = repositoryService.BranchRepository.GetById(branch.Id);


        dbBranch.ChangeCorporationId(dbCorporation.Id);

        repositoryService.BranchRepository.Update(dbBranch);

        return Result.Success;
    }
}

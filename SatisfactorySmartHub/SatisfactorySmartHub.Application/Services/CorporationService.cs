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
    ICorporationFileService corporationFileService,
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
            return Error.Validation();
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
    
    public void AddBranchToCorporation(BranchModel branch, CorporationModel corporation)
    {
        corporation.Branches.Add(branch);
    }

    public bool ExportCorporation(CorporationModel corporation, string filePath)
    {
        if (corporation is null)
            throw new ArgumentNullException(nameof(corporation));

        try
        {
            return corporationFileService.ExportCorporation(corporation, filePath);
        }
        catch (Exception)
        {
            return false;
        }
    }

    public CorporationModel GetCorporationFromFile(string filePath)
    {
        if (filePath is null)
            throw new ArgumentNullException(nameof(filePath));

        if (filePath == string.Empty)
            throw new ArgumentException(nameof(filePath));

        return corporationFileService.GetCorporation(filePath);
    }

    public ICollection<string> GetSaveFiles() => corporationFileService.GetSaveFiles();

    public bool SaveCorporation(CorporationModel corporation, bool overrideFile)
    {
        if (corporation is null)
            throw new ArgumentNullException(nameof(corporation));

        try
        {
            return corporationFileService.SaveCorporation(corporation, overrideFile);
        }
        catch (Exception)
        {
            return false;
        }
    }

}

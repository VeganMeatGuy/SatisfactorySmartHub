using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Services;

internal sealed class CorporationService(
    ICorporationFileService corporationFileService,
    IRepositoryService repositoryService) : ICorporationService
{
    public Corporation GetNewCorporation(string corporationName)
    {
        return Corporation.Create(corporationName).Value;
    }

    public IEnumerable<Corporation> GetCorporations()
    {
        try
        {
            return repositoryService.CorporationRepository.GetAll();
        }
        catch
        {
            return new List<Corporation>();
        }
    }

    public bool Update(Corporation corporation)
    {
        try
        {
            Corporation? dbCorporation = repositoryService.CorporationRepository.GetById(corporation.Id);


            if (dbCorporation is null)
            {
                repositoryService.CorporationRepository.Create(corporation);
            }
            else
            {
                repositoryService.CorporationRepository.Update(corporation);
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
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

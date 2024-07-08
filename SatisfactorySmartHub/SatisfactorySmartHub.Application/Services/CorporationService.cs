using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories.FileBased;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Services;

internal sealed class CorporationService(IRepositoryService repositoryService) : ICorporationService
{
    public void ExportCorporation(CorporationModel corporation, string folderPath)
    {
        ICorporationModelFileRepository repo = repositoryService.CorporationModelFileRepository;
        repo.ExportCorporation(corporation, folderPath);
    }

    public CorporationModel GetNewCorporation(string corporationName)
    {
        return new CorporationModel() { Name = corporationName };
    }

    public void SaveCorporation(CorporationModel corporation, bool overrideFile)
    {
        ICorporationModelFileRepository repo = repositoryService.CorporationModelFileRepository;
        repo.SaveCorporation(corporation, overrideFile);
    }
}

using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Services;

internal sealed class CorporationService(ICorporationFileService corporationFileService) : ICorporationService
{
    public void ExportCorporation(CorporationModel corporation, string filePath)
    {
        corporationFileService.ExportCorporation(corporation, filePath);
    }

    public CorporationModel GetCorporationFromFile(string filePath)
    {
        return corporationFileService.GetCorporation(filePath);
    }

    public CorporationModel GetNewCorporation(string corporationName)
    {
        return new CorporationModel() { Name = corporationName };
    }

    public ICollection<string> GetSaveFiles() => corporationFileService.GetSaveFiles();

    public void SaveCorporation(CorporationModel corporation, bool overrideFile)
    {
        corporationFileService.SaveCorporation(corporation, overrideFile);
    }
}

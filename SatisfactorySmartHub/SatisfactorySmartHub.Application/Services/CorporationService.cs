using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Services;

internal sealed class CorporationService(ICorporationFileService corporationFileService) : ICorporationService
{
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

    public CorporationModel GetNewCorporation(string corporationName)
    {
        if (corporationName is null)
            throw new ArgumentNullException(nameof(corporationName));

        if (corporationName == string.Empty)
            throw new ArgumentException(nameof(corporationName));

        return new CorporationModel() { Name = corporationName };
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

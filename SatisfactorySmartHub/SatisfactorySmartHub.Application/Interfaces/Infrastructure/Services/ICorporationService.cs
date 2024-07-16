using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;

public interface ICorporationService
{
    CorporationModel GetNewCorporation(string corporationName);
    CorporationModel GetCorporationFromFile(string filePath);
    void SaveCorporation(CorporationModel corporation, bool overrideFile);
    void ExportCorporation(CorporationModel corporation, string filePath);
    ICollection<string> GetSaveFiles();
}

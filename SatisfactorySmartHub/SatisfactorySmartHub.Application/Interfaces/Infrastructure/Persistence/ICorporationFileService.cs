using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;

public interface ICorporationFileService
{
    string DefaultFolderPath { get; }
    ICollection<string> GetSaveFiles();
    bool ExportCorporation(CorporationModel corporation, string filePath);
    CorporationModel GetCorporation(string filePath);
    bool SaveCorporation(CorporationModel corporation, bool overrideFile);
}
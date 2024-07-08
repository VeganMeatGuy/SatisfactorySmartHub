using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories.FileBased;

public interface ICorporationModelFileRepository
{
    void ExportCorporation(CorporationModel corporation, string folderPath);
    CorporationModel GetCorporation(string filePath);
    void SaveCorporation(CorporationModel corporation, bool overrideFile);
}
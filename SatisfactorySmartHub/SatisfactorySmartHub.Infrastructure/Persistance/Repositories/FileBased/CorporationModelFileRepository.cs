using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories.FileBased;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Repositories.FileRepository;

internal class CorporationModelFileRepository : ICorporationModelFileRepository
{
    public void ExportCorporation(CorporationModel corporation, string filePath)
    {
        string jsonData = JsonSerializer.Serialize(corporation);
        File.WriteAllText(filePath, jsonData);
    }

    public CorporationModel GetCorporation(string filePath)
    {
        throw new NotImplementedException();
    }

    public void SaveCorporation(CorporationModel corporation, bool overrideFile)
    {
        string folderPath = Path.Combine(Environment.CurrentDirectory, "SaveFiles");
        if (Directory.Exists(folderPath) == false)
            Directory.CreateDirectory(folderPath);

        string jsonData = JsonSerializer.Serialize(corporation);

        string fileName;

        if (overrideFile)
            fileName = $"{corporation.Name}.json";
        else
            fileName = $"{corporation.Name}_{DateTime.Now:yyyy-dd-M--HH-mm-ss}_{Guid.NewGuid()}.json";

        string savingPath = Path.Combine(folderPath, fileName);
        File.WriteAllText(savingPath, jsonData);

    }
}

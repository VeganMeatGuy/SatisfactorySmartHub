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
    private readonly string _defaultFolderPath = Path.Combine(Environment.CurrentDirectory, "SaveFiles");

    public string DefaultFolderPath => _defaultFolderPath;

    public ICollection<FileInfo> GetSaveFiles()
    {

        if (Directory.Exists(_defaultFolderPath))
        {
            DirectoryInfo di = new DirectoryInfo(_defaultFolderPath);
            return di.EnumerateFiles().ToList<FileInfo>();
        }
        else
            return new List<FileInfo>();
    }


    public void ExportCorporation(CorporationModel corporation, string filePath)
    {
        string jsonData = JsonSerializer.Serialize(corporation);
        File.WriteAllText(filePath, jsonData);
    }

    public CorporationModel GetCorporation(string filePath)
    {
        if (Path.Exists(filePath) == false)
            throw new Exception();

        string json = File.ReadAllText(filePath);

        CorporationModel? result = JsonSerializer.Deserialize<CorporationModel>(json);

        if (result == null)
            throw new Exception();
        else 
            return result;
    }

    public void SaveCorporation(CorporationModel corporation, bool overrideFile)
    {
        if (Directory.Exists(_defaultFolderPath) == false)
            Directory.CreateDirectory(_defaultFolderPath);

        string jsonData = JsonSerializer.Serialize(corporation);

        string fileName;

        if (overrideFile)
            fileName = $"{corporation.Name}.json";
        else
            fileName = $"{corporation.Name}_{DateTime.Now:yyyy-dd-M--HH-mm-ss}_{Guid.NewGuid()}.json";

        string savingPath = Path.Combine(_defaultFolderPath, fileName);
        File.WriteAllText(savingPath, jsonData);

    }
}

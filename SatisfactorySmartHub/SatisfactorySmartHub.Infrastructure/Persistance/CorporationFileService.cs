using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Domain.Models;
using SatisfactorySmartHub.Infrastructure.Interfaces.Provider;
using System.Text.Json;


namespace SatisfactorySmartHub.Infrastructure.Persistance;

internal class CorporationFileService(IFileProvider fileProvider, IDirectoryProvider directoryProvider) : ICorporationFileService
{
    private readonly string _defaultFolderPath = Path.Combine(Environment.CurrentDirectory, "SaveFiles");

    public string DefaultFolderPath => _defaultFolderPath;

    public ICollection<string> GetSaveFiles()
    {
        if (directoryProvider.Exists(_defaultFolderPath))
            return directoryProvider.GetFiles(_defaultFolderPath).ToList();
        else
            return new List<string>();
    }


    public void ExportCorporation(CorporationModel corporation, string filePath)
    {
        string jsonData = JsonSerializer.Serialize(corporation);
        fileProvider.WriteAllText(filePath, jsonData);
    }

    public CorporationModel GetCorporation(string filePath)
    {
        if (fileProvider.Exists(filePath) == false)
            throw new Exception();

        string json = fileProvider.ReadAllText(filePath);

        return JsonSerializer.Deserialize<CorporationModel>(json) ?? throw new Exception(); ;
    }

    public bool SaveCorporation(CorporationModel corporation, bool overwriteFile)
    {
        try
        { 
        directoryProvider.CreateDirectory(_defaultFolderPath);

        string jsonData = JsonSerializer.Serialize(corporation);

        string fileName;

        if (overwriteFile)
            fileName = $"{corporation.Name}.json";
        else
            fileName = $"{corporation.Name}_{DateTime.Now:yyyy-dd-M--HH-mm-ss-fff}.json";

        string savingPath = Path.Combine(_defaultFolderPath, fileName);
        fileProvider.WriteAllText(savingPath, jsonData);

        return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}

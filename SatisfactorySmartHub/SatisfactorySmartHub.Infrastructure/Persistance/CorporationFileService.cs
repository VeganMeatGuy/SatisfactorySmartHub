using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Domain.Models;
using SatisfactorySmartHub.Infrastructure.Interfaces.Provider;
using System.Text.Json;


namespace SatisfactorySmartHub.Infrastructure.Persistance;

internal class CorporationFileService(
    IFileProvider fileProvider, 
    IDirectoryProvider directoryProvider, 
    IDateTimeProvider dateTimeProvider,
    IJsonSerializer jsonSerializer) : ICorporationFileService
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


    public bool ExportCorporation(CorporationModel corporation, string filePath)
    {
        try
        {
            string jsonData = jsonSerializer.Serialize(corporation);
            fileProvider.WriteAllText(filePath, jsonData);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public CorporationModel GetCorporation(string filePath)
    {
        if(filePath is null) throw new ArgumentNullException(nameof(filePath));

        if (fileProvider.Exists(filePath) == false)
            throw new FileNotFoundException();

        string json = fileProvider.ReadAllText(filePath);

        return jsonSerializer.Deserialize<CorporationModel>(json) ?? throw new JsonException(); ;
    }

    public bool SaveCorporation(CorporationModel corporation, bool overwriteFile)
    {
        try
        {
            directoryProvider.CreateDirectory(_defaultFolderPath);

            string jsonData = jsonSerializer.Serialize(corporation);

            string fileName;

            if (overwriteFile)
                fileName = $"{corporation.Name}.json";
            else
                fileName = $"{corporation.Name}_{dateTimeProvider.Now:yyyy-MM-dd_HH-mm-ss-ff}.json";

            string savingPath = Path.Combine(_defaultFolderPath, fileName);
            fileProvider.WriteAllText(savingPath, jsonData);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

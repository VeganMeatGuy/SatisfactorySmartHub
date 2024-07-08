using SatisfactorySmartHub.Domain.Models;
using SatisfactorySmartHub.Infrastructure.Persistance.Repositories.FileRepository;
using System.Text.Json;

namespace SatisfactorySmartHub.Persistance.Repositories.FileBased;

[TestClass]
public class CorporationModelFileRepositoryTest
{
    [TestMethod]
    [DataRow("Corp1")]
    [DataRow("PetersCorp")]
    [DataRow("Corp With Blanks")]
    public void CorporationModelFileRepository_ExportCorporation_savesCorporationGivenFolder(string corporationName)
    {
        //arrange
        string testCorporationName = corporationName;
        string directoryName = Environment.CurrentDirectory;


        string path = Path.Combine(directoryName, $"{testCorporationName}.json");
        if (File.Exists(path))
            File.Delete(path);

        CorporationModelFileRepository service = new CorporationModelFileRepository();
        CorporationModel testCorporation = new CorporationModel();
        testCorporation.Name = testCorporationName;

        //act
        service.ExportCorporation(testCorporation, Environment.CurrentDirectory);

        //assert
        string textFromFile = File.ReadAllText(path);
        CorporationModel? readedCorporation = JsonSerializer.Deserialize<CorporationModel>(textFromFile);

        Assert.IsTrue(File.Exists(path));
        Assert.IsNotNull(readedCorporation);
        Assert.AreEqual(JsonSerializer.Serialize(testCorporation), textFromFile);
    }

    [TestMethod]
    [DataRow("Corp1")]
    [DataRow("PetersCorp")]
    [DataRow("Corp With Blanks")]
    public void CorporationModelFileRepository_ExportCorporation_savesCorporationInAppFolder(string corporationName)
    {
        //arrange
        string testCorporationName = corporationName;
        string folderPath = Path.Combine(Environment.CurrentDirectory, "SaveFiles");

        string path = Path.Combine(folderPath, $"{testCorporationName}.json");

        if (Directory.Exists(folderPath))
        {
            DirectoryInfo di = new DirectoryInfo(folderPath);
            foreach (FileInfo file in di.EnumerateFiles())
                file.Delete();
            Directory.Delete(folderPath, true);
        }

        CorporationModelFileRepository service = new CorporationModelFileRepository();
        CorporationModel testCorporation = new CorporationModel();
        testCorporation.Name = testCorporationName;

        //act
        service.SaveCorporation(testCorporation, true);
        service.SaveCorporation(testCorporation, true);
        service.SaveCorporation(testCorporation, false);
        service.SaveCorporation(testCorporation, false);

        //assert

        var files = Directory.GetFiles(folderPath);

        int docs = files.Count(x => x.Contains(testCorporationName));

        string textFromFile = File.ReadAllText(path);
        CorporationModel? readedCorporation = JsonSerializer.Deserialize<CorporationModel>(textFromFile);

        Assert.IsTrue(File.Exists(path));
        Assert.IsNotNull(readedCorporation);
        Assert.AreEqual(JsonSerializer.Serialize(testCorporation), textFromFile);
        Assert.AreEqual(3, docs);
    }
}
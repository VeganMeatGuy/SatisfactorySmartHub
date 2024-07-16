namespace SatisfactorySmartHub.Infrastructure.Tests.Persistance;

public sealed partial class CorporationFileServiceTests
{
    //[TestMethod]
    //[DataRow("Corp1")]
    //[DataRow("PetersCorp")]
    //[DataRow("Corp With Blanks")]
    //public void CorporationModelFileRepository_ExportCorporation_savesCorporationGivenFolder(string corporationName)
    //{
    //    //arrange
    //    string testCorporationName = corporationName;
    //    string directoryName = Environment.CurrentDirectory;


    //    string path = Path.Combine(directoryName, $"{testCorporationName}.json");
    //    if (File.Exists(path))
    //        File.Delete(path);

    //    CorporationFileService service = new CorporationFileService();
    //    CorporationModel testCorporation = new CorporationModel();
    //    testCorporation.Name = testCorporationName;

    //    //act
    //    service.ExportCorporation(testCorporation, path);

    //    //assert
    //    string textFromFile = File.ReadAllText(path);
    //    CorporationModel? readedCorporation = JsonSerializer.Deserialize<CorporationModel>(textFromFile);

    //    Assert.IsTrue(File.Exists(path));
    //    Assert.IsNotNull(readedCorporation);
    //    Assert.AreEqual(JsonSerializer.Serialize(testCorporation), textFromFile);
    //}

    //[TestMethod]
    //[DataRow("Corp1")]
    //[DataRow("PetersCorp")]
    //[DataRow("Corp With Blanks")]
    //public void CorporationModelFileRepository_ExportCorporation_savesCorporationInAppFolder(string corporationName)
    //{
    //    //arrange
    //    CorporationFileService service = new CorporationFileService();
    //    string folderPath = service.DefaultFolderPath;
    //    string path = Path.Combine(folderPath, $"{corporationName}.json");
    //    CorporationModel testCorporation = new CorporationModel();
    //    testCorporation.Name = corporationName;

    //    //act
    //    service.SaveCorporation(testCorporation, true);
    //    service.SaveCorporation(testCorporation, true);
    //    service.SaveCorporation(testCorporation, false);
    //    service.SaveCorporation(testCorporation, false);

    //    //assert

    //    var files = Directory.GetFiles(folderPath);

    //    int docs = files.Count(x => x.Contains(corporationName));

    //    string textFromFile = File.ReadAllText(path);
    //    CorporationModel? readedCorporation = JsonSerializer.Deserialize<CorporationModel>(textFromFile);

    //    Assert.IsTrue(File.Exists(path));
    //    Assert.IsNotNull(readedCorporation);
    //    Assert.AreEqual(JsonSerializer.Serialize(testCorporation), textFromFile);
    //    Assert.AreEqual(3, docs);
    //}

    //[TestMethod]
    //public void CorporationModelFileRepository_ExportCorporation()
    //{
    //    //arrange
    //    CorporationFileService service = new CorporationModelFileRepository();
    //    string folderPath = service.DefaultFolderPath;
    //    string testCorporationName = "TestCorporation1";
    //    CorporationModel testCorporation = new CorporationModel();
    //    testCorporation.Name = testCorporationName;
    //    string path = Path.Combine(folderPath, $"{testCorporationName}.json");

    //    //act
    //    service.SaveCorporation(testCorporation, true);
    //    service.SaveCorporation(testCorporation, true);
    //    service.SaveCorporation(testCorporation, false);
    //    service.SaveCorporation(testCorporation, false);

    //    //assert

    //    ICollection<FileInfo> saveFiles = service.GetSaveFiles();
    //    int testCorporationCount = saveFiles.Count(x => x.Name.Contains(testCorporationName));

    //    Assert.AreEqual(3, saveFiles.Count);
    //    Assert.AreEqual(3, testCorporationCount);
    //}
}

using Moq;
using SatisfactorySmartHub.Domain.Models;
using SatisfactorySmartHub.Infrastructure.Persistance;

namespace SatisfactorySmartHub.Infrastructure.Tests.Persistance;

public sealed partial class CorporationFileServiceTests
{
    [TestMethod]
    [TestCategory("Methods")]
    public void ExportCorporation_ShouldReturnTrue_WhenExportWasSucceddful()
    {
        //arrange
        string testCorporationName = "unitteest";

        CorporationFileService service = CreateMockedInstance();

        CorporationModel corporation = new CorporationModel();
        corporation.Name = testCorporationName;

        string validFilePath = Path.Combine(service.DefaultFolderPath, "unittest.json");

        //act
        bool result = service.ExportCorporation(corporation, validFilePath);

        //assert
        Assert.IsTrue(result);
        _fileProviderMock.Verify(x => x.WriteAllText(validFilePath, It.IsAny<string>()), Times.Once());
    }

    [TestMethod]
    [TestCategory("Methods")]
    public void ExportCorporation_ShouldReturnfalse_WhenExportWasNotSucceddful()
    {
        //arrange
        string testCorporationName = "unitteest";

        CorporationFileService service = CreateMockedInstance();
        _fileProviderMock.Setup(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>())).Throws(new Exception());
        CorporationModel corporation = new CorporationModel();
        corporation.Name = testCorporationName;

        string validFilePath = Path.Combine(service.DefaultFolderPath, "unittest.json");

        //act
        bool result = service.ExportCorporation(corporation, validFilePath);

        //assert
        Assert.IsFalse(result);
        _fileProviderMock.Verify(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
    }
}

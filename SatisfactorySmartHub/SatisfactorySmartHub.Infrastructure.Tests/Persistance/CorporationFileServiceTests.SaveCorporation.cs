using Moq;
using SatisfactorySmartHub.Domain.Models;
using SatisfactorySmartHub.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Tests.Persistance;

public sealed partial class CorporationFileServiceTests
{
    [TestMethod]
    [TestCategory("Methods")]
    public void SaveCorporation_ShouldReturnTrue_WhenSaveWasSuccessful()
    {
        //arrange
        string testCorporationName = "unittest"; 
        
        CorporationFileService service = CreateMockedInstance();

        CorporationModel corporation = new();
        corporation.Name = testCorporationName;

        //act
        bool result = service.SaveCorporation(corporation, true);

        //assert
        Assert.IsTrue(result);
        _fileProviderMock.Verify(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>()),Times.Once);
    }

    [TestMethod]
    [TestCategory("Methods")]
    public void SaveCorporation_ShouldReturnFalse_WhenSaveWasNotSuccessful()
    {
        //arrange
        string testCorporationName = "unittest";

        CorporationFileService service = CreateMockedInstance();
        _fileProviderMock.Setup(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>())).Throws(new Exception());

        CorporationModel corporation = new();
        corporation.Name = testCorporationName;

        //act
        bool result = service.SaveCorporation(corporation, true);
        
        //assert
        Assert.IsFalse(result);
        _fileProviderMock.Verify(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    }

    [TestMethod]
    [TestCategory("Methods")]
    public void SaveCorporation_ShouldSaveFileWithCorporationName_WhenOverWriteIsTrue()
    {
        //arrange
        string testCorporationName = "unittest";

        CorporationFileService service = CreateMockedInstance();

        string filePath = Path.Combine(service.DefaultFolderPath, $"{testCorporationName}.json");

        CorporationModel corporation = new();
        corporation.Name = testCorporationName;
        
        //act
        bool result = service.SaveCorporation(corporation, true);

        //assert
        Assert.IsTrue(result);
        _fileProviderMock.Verify(x => x.WriteAllText(filePath, It.IsAny<string>()), Times.Once);
    }

    [TestMethod]
    [TestCategory("Methods")]
    public void SaveCorporation_ShouldSaveFileWithCorporationNameAndTimeStamp_WhenOverWriteIsFalse()
    {
        //arrange
        string testCorporationName = "unittest";

        CorporationFileService service = CreateMockedInstance();
        DateTime unitTestTime = DateTime.Now;
        _dateTimeProviderMock.Setup(x => x.Now).Returns(unitTestTime);

        string filePath = Path.Combine(service.DefaultFolderPath, $"{testCorporationName}_{unitTestTime:yyyy-MM-dd_HH-mm-ss-ff}.json");

        CorporationModel corporation = new();
        corporation.Name = testCorporationName;

        //act
        bool result = service.SaveCorporation(corporation, false);

        //assert
        Assert.IsTrue(result);

        _fileProviderMock.Verify(x => x.WriteAllText(filePath, It.IsAny<string>()), Times.Once);
    }

}

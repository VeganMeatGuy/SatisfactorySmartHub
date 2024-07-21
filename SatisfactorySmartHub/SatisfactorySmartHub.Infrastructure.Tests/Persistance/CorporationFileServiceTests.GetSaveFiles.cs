using Moq;
using SatisfactorySmartHub.Infrastructure.Persistance;

namespace SatisfactorySmartHub.Infrastructure.Tests.Persistance;

public sealed partial class CorporationFileServiceTests
{
    [TestMethod]
    [TestCategory("Method")]
    public void GetSaveFiles_ReturnsListOfFileNames_WhenFilesExist()
    {
        //arrange
        CorporationFileService service = CreateMockedInstance();

        _directoryProviderMock.Setup(x => x.Exists(It.IsAny<string>())).Returns(true);
        string[] fileListMock = { "File1", "File2", "File3" };
        _directoryProviderMock.Setup(x => x.GetFiles(It.IsAny<string>())).Returns(fileListMock);

        //act 
        var result = service.GetSaveFiles();

        //assert
        Assert.AreEqual(fileListMock.ToList().Count, result.Count);
        Assert.IsInstanceOfType(result, typeof(ICollection<string>));
        _directoryProviderMock.Verify(x=> x.GetFiles(It.IsAny<string>()), Times.Once());
    }

    [TestMethod]
    [TestCategory("Method")]
    public void GetSaveFiles_ReturnsEmptyListOfFileNames_WhenNoFilesExist()
    {
        //arrange
        CorporationFileService service = CreateMockedInstance();

        _directoryProviderMock.Setup(x => x.Exists(It.IsAny<string>())).Returns(true);
        string[] fileListMock = {};
        _directoryProviderMock.Setup(x => x.GetFiles(It.IsAny<string>())).Returns(fileListMock);

        //act 
        var result = service.GetSaveFiles();

        //assert
        Assert.AreEqual(0, result.Count);
        Assert.IsInstanceOfType(result, typeof(ICollection<string>));
        _directoryProviderMock.Verify(x => x.GetFiles(It.IsAny<string>()), Times.Once());
    }

    [TestMethod]
    [TestCategory("Method")]
    public void GetSaveFiles_ReturnsEmptyListOfFileNames_WhenDirectoryDoesntExist()
    {
        //arrange
        CorporationFileService service = CreateMockedInstance();

        _directoryProviderMock.Setup(x => x.Exists(It.IsAny<string>())).Returns(false);
        //act 
        var result = service.GetSaveFiles();

        //assert
        Assert.AreEqual(0, result.Count);
        Assert.IsInstanceOfType(result, typeof(ICollection<string>));

    }
}

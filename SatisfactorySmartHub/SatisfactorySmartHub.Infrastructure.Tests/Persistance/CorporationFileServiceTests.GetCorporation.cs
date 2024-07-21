using Moq;
using SatisfactorySmartHub.Domain.Models;
using SatisfactorySmartHub.Infrastructure.Persistance;
using System.Text.Json;

namespace SatisfactorySmartHub.Infrastructure.Tests.Persistance;

public sealed partial class CorporationFileServiceTests
{
    [TestMethod]
    [TestCategory("Method")]
    public void GetCorporation_ShouldReturnCorporationModel_WhenFunctionSuccessfull()
    {
        //arrange
        CorporationFileService service = CreateMockedInstance();

        CorporationModel corporation = new CorporationModel();

        _fileProviderMock.Setup(x => x.Exists(It.IsAny<string>())).Returns(true);
        _jsonSerializerMock.Setup(x => x.Deserialize<CorporationModel>(It.IsAny<string>())).Returns(corporation);

        //act
        CorporationModel result = service.GetCorporation("");

        //assert
        Assert.AreEqual(result, corporation);
        _fileProviderMock.Verify(x => x.ReadAllText(It.IsAny<string>()),Times.Once());
        _jsonSerializerMock.Verify(x => x.Deserialize<CorporationModel>(It.IsAny<string>()), Times.Once());
    }

    [TestMethod]
    [TestCategory("Method")]
    [ExpectedException (typeof(ArgumentNullException))]
    public void GetCorporation_ShouldThrowArgumentNullException_WhenParameterFilePathIsNull()
    {
        //arrange
        CorporationFileService service = CreateMockedInstance();
        string? nullFilePath = null;

        //act
        var result = service.GetCorporation(nullFilePath);
    }

    [TestMethod]
    [TestCategory("Method")]
    [ExpectedException(typeof(FileNotFoundException))]
    public void GetCorporation_ShouldThrowFileNotFoundException_WhenFilePathIsNotFound()
    {
        //arrange
        CorporationFileService service = CreateMockedInstance();
        _fileProviderMock.Setup(x => x.Exists(It.IsAny<string>())).Returns(false);

        //act
        var result = service.GetCorporation("");
    }

    [TestMethod]
    [TestCategory("Method")]
    [ExpectedException(typeof(JsonException))]
    public void GetCorporation_ShouldThrowJsonException_WhenStringIsNotDeserializeable()
    {
        //arrange
        CorporationFileService service = CreateMockedInstance();
        _fileProviderMock.Setup(x => x.Exists(It.IsAny<string>())).Returns(true);
        _fileProviderMock.Setup(x => x.ReadAllText(It.IsAny<string>())).Returns("unittest");

        //act
        var result = service.GetCorporation("unittest");
    }

    [TestMethod]
    [TestCategory("Method")]
    [ExpectedException(typeof(IOException))]
    public void GetCorporation_ShouldThrowJsonException_WhenFileIsNotReadable()
    {
        //arrange
        CorporationFileService service = CreateMockedInstance();
        _fileProviderMock.Setup(x => x.Exists(It.IsAny<string>())).Returns(true);
        _fileProviderMock.Setup(x => x.ReadAllText(It.IsAny<string>())).Throws(new IOException());

        //act
        var result = service.GetCorporation("unittest");
    }
}

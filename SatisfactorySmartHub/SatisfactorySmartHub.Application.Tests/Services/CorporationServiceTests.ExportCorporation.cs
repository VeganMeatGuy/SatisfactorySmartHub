using Moq;
using SatisfactorySmartHub.Application.Services;
using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Tests.Services;

public sealed partial class CorporationServiceTests
{
    [TestMethod]
    [TestCategory("Method")]
    public void ExportCorporation_ReturnsTrue_WhenExportWasSuccessfull()
    {
        //arrange
        CorporationService service = CreateMockedInstance();
        CorporationModel corporationModel = new();
        string filePath = "validPath";
        _corporationFileServiceMock.Setup(x => x.ExportCorporation(It.IsAny<CorporationModel>(), It.IsAny<string>())).Returns(true);
        // act
        bool result = service.ExportCorporation(corporationModel, filePath);

        // assert
        Assert.IsTrue(result);
        _corporationFileServiceMock.Verify(x => x.ExportCorporation(It.IsAny<CorporationModel>(), It.IsAny<string>()), Times.Once);
    }

    [TestMethod]
    [TestCategory("Method")]
    public void ExportCorporation_ReturnsFalse_WhenExportWasNotSuccessfull()
    {
        //arrange
        CorporationService service = CreateMockedInstance();
        CorporationModel corporationModel = new();
        string filePath = "validPath";
        _corporationFileServiceMock.Setup(x => x.ExportCorporation(It.IsAny<CorporationModel>(), It.IsAny<string>())).Returns(false);
        // act
        bool result = service.ExportCorporation(corporationModel, filePath);

        // assert
        Assert.IsFalse(result);
        _corporationFileServiceMock.Verify(x => x.ExportCorporation(It.IsAny<CorporationModel>(), It.IsAny<string>()), Times.Once);
    }

    [TestMethod]
    [TestCategory("Method")]
    public void ExportCorporation_ReturnsFalse_WhenExportThrowsException()
    {
        //arrange
        CorporationService service = CreateMockedInstance();
        CorporationModel corporationModel = new();
        string filePath = "validPath";
        _corporationFileServiceMock.Setup(x => x.ExportCorporation(It.IsAny<CorporationModel>(), It.IsAny<string>())).Throws(new Exception());
        // act
        bool result = service.ExportCorporation(corporationModel, filePath);

        // assert
        Assert.IsFalse(result);
        _corporationFileServiceMock.Verify(x => x.ExportCorporation(It.IsAny<CorporationModel>(), It.IsAny<string>()), Times.Once);
    }

    [TestMethod]
    [TestCategory("Method")]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ExportCorporation_ThrowsArgumentNullExeption_WhenParameterCorporationIsNull()
    {
        //arrange
        CorporationService service = CreateMockedInstance();
        CorporationModel corporationModel = null;
        string filePath = "validPath";
        // act
        bool result = service.ExportCorporation(corporationModel, filePath);

        // assert
        _corporationFileServiceMock.Verify(x => x.ExportCorporation(It.IsAny<CorporationModel>(), It.IsAny<string>()), Times.Never);
    }
}

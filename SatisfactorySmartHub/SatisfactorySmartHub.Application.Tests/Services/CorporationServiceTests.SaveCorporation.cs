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
    [DataRow(true)]
    [DataRow(false)]
    public void SaveCorporation_ReturnsTrue_WhenSaveWasSuccessfull(bool overwriteFile)
    {
        //arrange
        CorporationService service = CreateMockedInstance();
        CorporationModel corporationModel = new();
        _corporationFileServiceMock.Setup(x => x.SaveCorporation(It.IsAny<CorporationModel>(), It.IsAny<bool>())).Returns(true);
        // act
        bool result = service.SaveCorporation(corporationModel, overwriteFile);

        // assert
        Assert.IsTrue(result);
        _corporationFileServiceMock.Verify(x => x.SaveCorporation(It.IsAny<CorporationModel>(), It.IsAny<bool>()), Times.Once);
    }

    [TestMethod]
    [TestCategory("Method")]
    [DataRow(true)]
    [DataRow(false)]
    public void SaveCorporation_ReturnsFalse_WhenSaveWasNotSuccessfull(bool overwriteFile)
    {
        //arrange
        CorporationService service = CreateMockedInstance();
        CorporationModel corporationModel = new();
        _corporationFileServiceMock.Setup(x => x.SaveCorporation(It.IsAny<CorporationModel>(), It.IsAny<bool>())).Returns(false);
        // act
        bool result = service.SaveCorporation(corporationModel, overwriteFile);

        // assert
        Assert.IsFalse(result);
        _corporationFileServiceMock.Verify(x => x.SaveCorporation(It.IsAny<CorporationModel>(), It.IsAny<bool>()), Times.Once);
    }

    [TestMethod]
    [TestCategory("Method")]
    [DataRow(true)]
    [DataRow(false)]
    public void SaveCorporation_ReturnsFalse_WhenSaveThrowsException(bool overwriteFile)
    {
        //arrange
        CorporationService service = CreateMockedInstance();
        CorporationModel corporationModel = new();
        _corporationFileServiceMock.Setup(x => x.SaveCorporation(It.IsAny<CorporationModel>(), It.IsAny<bool>())).Throws(new Exception());
        // act
        bool result = service.SaveCorporation(corporationModel, overwriteFile);

        // assert
        Assert.IsFalse(result);
        _corporationFileServiceMock.Verify(x => x.SaveCorporation(It.IsAny<CorporationModel>(), It.IsAny<bool>()), Times.Once);
    }

    [TestMethod]
    [TestCategory("Method")]
    [DataRow(true)]
    [DataRow(false)]
    [ExpectedException (typeof(ArgumentNullException))]
    public void SaveCorporation_ThrowsArgumentNullExeption_WhenParameterCorporationIsNull(bool overwriteFile)
    {
        //arrange
        CorporationService service = CreateMockedInstance();
        CorporationModel corporationModel = null;
        // act
        bool result = service.SaveCorporation(corporationModel, overwriteFile);

        // assert
        _corporationFileServiceMock.Verify(x => x.SaveCorporation(It.IsAny<CorporationModel>(), It.IsAny<bool>()), Times.Never);
    }
}

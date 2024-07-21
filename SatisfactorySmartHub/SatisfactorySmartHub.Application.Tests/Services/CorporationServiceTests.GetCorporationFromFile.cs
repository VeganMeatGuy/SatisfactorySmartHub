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
    public void GetCorporationFromFile_ReturnsCorporationModel_WhenValidFilePathIsGiven()
    {
        //arrange
        CorporationService service = CreateMockedInstance();
        CorporationModel corporationModel = new CorporationModel();
        _corporationFileServiceMock.Setup(x => x.GetCorporation(It.IsAny<string>())).Returns(corporationModel);

        // act
        CorporationModel? result = service.GetCorporationFromFile("somePath");

        // assert
        Assert.IsNotNull(result);
        Assert.AreSame(corporationModel, result);
    }

    [TestMethod]
    [TestCategory("Method")]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetCorporationFromFile_ThrowsArgumentNullException_WhenParameterFilePathIsNull()
    {
        //arrange
        CorporationService service = CreateMockedInstance();
        string filePath = null;

        // act
        CorporationModel? result = service.GetCorporationFromFile(filePath);
    }

    [TestMethod]
    [TestCategory("Method")]
    [ExpectedException(typeof(ArgumentException))]
    public void GetCorporationFromFile_ThrowsArgumentException_WhenParameterFilePathIsEmpty()
    {
        //arrange
        CorporationService service = CreateMockedInstance();
        string filePath = string.Empty;

        // act
        CorporationModel? result = service.GetCorporationFromFile(filePath);
    }
}

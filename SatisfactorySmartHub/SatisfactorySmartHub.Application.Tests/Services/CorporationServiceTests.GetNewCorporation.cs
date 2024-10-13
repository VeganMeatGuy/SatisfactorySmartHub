using SatisfactorySmartHub.Application.Services;
using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Application.Tests.Services;

public sealed partial class CorporationServiceTests
{
    [TestMethod]
    [TestCategory("Method")]
    public void GetNewCorporation_ReturnsCorporationModel_WhenValidNameIsGiven()
    {
        //arrange
        CorporationService service = CreateMockedInstance();
        string corporationName = "unittest";

        // act
        CorporationModel? result = service.CreateCorporation(corporationName);

        // assert
        Assert.IsNotNull(result);
        Assert.AreEqual(corporationName, result.Name);
    }

    [TestMethod]
    [TestCategory("Method")]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetNewCorporation_ThrowsArgumentNullException_WhenParameterCorporationNameIsNull()
    {
        //arrange
        CorporationService service = CreateMockedInstance();
        string corporationName = null;

        // act
        CorporationModel? result = service.CreateCorporation(corporationName);
    }

    [TestMethod]
    [TestCategory("Method")]
    [ExpectedException(typeof(ArgumentException))]
    public void GetNewCorporation_ThrowsArgumentException_WhenParameterCorporationNameIsEmpty()
    {
        //arrange
        CorporationService service = CreateMockedInstance();
        string corporationName = string.Empty;

        // act
        CorporationModel? result = service.CreateCorporation(corporationName);
    }
}

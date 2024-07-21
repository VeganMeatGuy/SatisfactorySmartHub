using Moq;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Application.Services;

namespace SatisfactorySmartHub.Application.Tests.Services;

[TestClass]
public sealed partial class CorporationServiceTests
{
    private Mock<ICorporationFileService> _corporationFileServiceMock = new();

    [TestMethod]
    [TestCategory("Constructor")]
    public void CorporationServiceTest()
    {
        //arrange
        ICorporationService? corporationService;
        
        //act
        corporationService = CreateMockedInstance();
        
        //assert
        Assert.IsNotNull(corporationService);
    }

    /// <summary>
    /// Creates a new instance of the <see cref="CorporationService"/> class with mocked dependencies.
    /// </summary>
    /// <returns>The new instance with mocked dependencies.</returns>
    private CorporationService CreateMockedInstance()
    {
        _corporationFileServiceMock = new();
        return new CorporationService(_corporationFileServiceMock.Object);
    }
}
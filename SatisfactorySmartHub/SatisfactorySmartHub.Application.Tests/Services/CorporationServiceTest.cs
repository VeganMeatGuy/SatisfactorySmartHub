using Moq;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Application.Services;
using SatisfactorySmartHub.Domain.Models;
using System.IO.Enumeration;

namespace SatisfactorySmartHub.Application.Tests.Services;

[TestClass]
public class CorporationServiceTest
{
    [TestMethod]
    public void CorporationService_GetNewCorporation_returnsNewCorporationWithRightName()
    {
        //arrange
        var repoServiceMock = new Mock<IRepositoryService>();

        CorporationService service = new CorporationService(repoServiceMock.Object);
        string testCorporationName = "TestCorp";

        //act
        var newCorporation = service.GetNewCorporation(testCorporationName);

        //assert
        Assert.IsNotNull(newCorporation);
        Assert.IsInstanceOfType(newCorporation, typeof(CorporationModel));
        Assert.AreEqual(testCorporationName, newCorporation.Name);
    }
}

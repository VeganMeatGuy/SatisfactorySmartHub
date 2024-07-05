using SatisfactorySmartHub.Application.Services;
using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Application.Tests.Services;

[TestClass]
public class CorporationServiceTest
{
    [TestMethod]
    public void CorporationService_GetNewCorporation_returnsNewCorporationWithRightName()
    {
        //arrange
        CorporationService service = new CorporationService();
        string testCorporationName = "TestCorp";

        //act
        var newCorporation = service.GetNewCorporation(testCorporationName);

        //assert
        Assert.IsNotNull(newCorporation);
        Assert.IsInstanceOfType(newCorporation, typeof(CorporationModel));
        Assert.AreEqual(testCorporationName, newCorporation.Name);
    
    }

}

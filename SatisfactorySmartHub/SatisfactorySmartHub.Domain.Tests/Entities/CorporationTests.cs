using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Domain.Tests.Entities;

[TestClass]
public sealed partial class CorporationTests
{
    private readonly static string _validCoporationName = "ValidCorporationName";

    [TestMethod]
    [TestCategory("Constructor")]
    public void CorporationTest()
    {
        //arrange
        Corporation? corporation;

        //act
        corporation = CreateMockedInstance();

        //assert
        Assert.IsNotNull(corporation);
    }

    private Corporation CreateMockedInstance()
    {
        return Corporation.Create(_validCoporationName).Value;
    }

}

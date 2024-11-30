using ErrorOr;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Domain.Errors;

namespace SatisfactorySmartHub.Domain.Tests.Entities;

public sealed partial class CorporationTests
{
    [TestMethod]
    [TestCategory("Method")]
    public void ChangeName_ReturnsError_WhenParamNameIsNull()
    {
        //act
        var result = CreateMockedInstance().ChangeName(null);

        //assert
        Assert.IsTrue(result.IsError);
        Assert.AreEqual(result.FirstError, DomainErrors.CorporationErrors.NameCannotBeNull);
    }

    [TestMethod]
    [TestCategory("Method")]
    public void ChangeName_ReturnsError_WhenParamNameIsEmpty()
    {
        //act
        var result = CreateMockedInstance().ChangeName(string.Empty);

        //assert
        Assert.IsTrue(result.IsError);
        Assert.AreEqual(result.FirstError, DomainErrors.CorporationErrors.NameCannotBeEmpty);
    }

    [TestMethod]
    [TestCategory("Method")]
    public void ChangeName_ChangesCorporationNameToGivenNameAndReturnsSuccess_WhenParamNameIsValid()
    {
        //arrange
        Corporation corporation = CreateMockedInstance();
        string newCorporationName = "NewCorporationName";


        //act
        var result = corporation.ChangeName(newCorporationName);

        //assert
        Assert.IsFalse(result.IsError);
        Assert.IsInstanceOfType<Success>(result.Value);
        Assert.AreEqual(newCorporationName, corporation.Name);
    }
}

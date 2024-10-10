using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Domain.Errors;

namespace SatisfactorySmartHub.Domain.Tests.Entities;

public sealed partial class CorporationTests
{
    [TestMethod]
    [TestCategory("Method")]
    public void Create_ReturnsError_WhenParamNameIsNull()
    {
        //act
        var result = Corporation.Create(null);

        //assert
        Assert.IsTrue(result.IsError);
        Assert.AreEqual(result.FirstError, DomainErrors.Corporation.CorporationNameCannotBeNull);
    }

    [TestMethod]
    [TestCategory("Method")]
    public void Create_ReturnsError_WhenParamNameIsEmpty()
    {
        //act
        var result = Corporation.Create(string.Empty);

        //assert
        Assert.IsTrue(result.IsError);
        Assert.AreEqual(result.FirstError, DomainErrors.Corporation.CorporationNameCannotBeEmpty);
    }

    [TestMethod]
    [TestCategory("Method")]
    public void Create_ReturnsCorporation_WhenParamsAreValid()
    {
        //act
        var result = Corporation.Create(_validCoporationName);

        //assert
        Assert.IsFalse(result.IsError);
        Assert.IsNotNull(result.Value);
        Assert.AreNotEqual(Guid.Empty, result.Value.Id);
        Assert.IsInstanceOfType(result.Value, typeof(Corporation));
    }
}
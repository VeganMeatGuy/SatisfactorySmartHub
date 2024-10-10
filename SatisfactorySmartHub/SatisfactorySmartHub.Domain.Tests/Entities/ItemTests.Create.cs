using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Domain.Errors;

namespace SatisfactorySmartHub.Domain.Tests.Entities;

public sealed partial class ItemTests
{
    [TestMethod]
    [TestCategory("Method")]
    public void Create_ReturnsError_WhenParamIdHasValueZero()
    {
        //act
        var result = Item.Create(0, _validItemName);

        //assert
        Assert.IsTrue(result.IsError);
        Assert.AreEqual(result.FirstError, DomainErrors.Item.ItemIdCannotBeZero);

    }
    [TestMethod]
    [TestCategory("Method")]
    public void Create_ReturnsError_WhenParamNameIsNull()
    {
        //act
        var result = Item.Create(_validItemId, null);

        //assert
        Assert.IsTrue(result.IsError);
        Assert.AreEqual(result.FirstError, DomainErrors.Item.ItemNameCannotBeNull);
    }

    [TestMethod]
    [TestCategory("Method")]
    public void Create_ReturnsError_WhenParamNameIsEmpty()
    {
        //act
        var result = Item.Create(_validItemId, string.Empty);

        //assert
        Assert.IsTrue(result.IsError);
        Assert.AreEqual(result.FirstError, DomainErrors.Item.ItemNameCannotBeEmpty);
    }

    [TestMethod]
    [TestCategory("Method")]
    public void Create_ReturnsItem_WhenParamsAreValid()
    {
        //act
        var result = Item.Create(_validItemId, _validItemName);

        //assert
        Assert.IsFalse(result.IsError);
        Assert.IsNotNull(result.Value);
        Assert.IsInstanceOfType(result.Value, typeof(Item));
    }
}

using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Domain.Errors;

namespace SatisfactorySmartHub.Domain.Tests.Entities;

public sealed partial class ItemTests
{
    [TestMethod]
    [TestCategory("Method")]
    public void Create_ReturnsError_WhenParamIdIsEmptyGuid()
    {
        //act
        var result = Item.Create(Guid.Empty, _validItemName);

        //assert
        Assert.IsTrue(result.IsError);
        Assert.AreEqual(result.FirstError, DomainErrors.ItemErrors.IdCanNotBeEmptyGuid);

    }
    [TestMethod]
    [TestCategory("Method")]
    public void Create_ReturnsError_WhenParamNameIsNull()
    {
        //act
        var result = Item.Create(_validItemId, null);

        //assert
        Assert.IsTrue(result.IsError);
        Assert.AreEqual(result.FirstError, DomainErrors.ItemErrors.NameCanNotBeNull);
    }

    [TestMethod]
    [TestCategory("Method")]
    public void Create_ReturnsError_WhenParamNameIsEmpty()
    {
        //act
        var result = Item.Create(_validItemId, string.Empty);

        //assert
        Assert.IsTrue(result.IsError);
        Assert.AreEqual(result.FirstError, DomainErrors.ItemErrors.NameCanNotBeEmpty);
    }

    [TestMethod]
    [TestCategory("Method")]
    public void Create_ReturnsCorrespondingItem_WhenParamsAreValid()
    {
        //act
        var result = Item.Create(_validItemId, _validItemName);

        //assert
        Assert.IsFalse(result.IsError);
        Assert.IsNotNull(result.Value);
        Assert.AreEqual(_validItemName, result.Value.Name);
        Assert.AreEqual(_validItemId, result.Value.Id);
        Assert.IsInstanceOfType(result.Value, typeof(Item));
    }
}

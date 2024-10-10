using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Domain.Tests.Entities;

[TestClass]
public sealed partial class ItemTests
{
    private readonly static int _validItemId = 1;
    private readonly static string _validItemName = "ValidItemName";

    [TestMethod]
    [TestCategory("Constructor")]
    public void ItemTest()
    {
        // arrange
        Item? item;
        //act
        item = CreateMockedInstance();

        //assert
        Assert.IsNotNull(item);
    }

    private Item CreateMockedInstance()
    {
        return Item.Create(_validItemId, _validItemName).Value;
    }

}

using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Domain.Tests.Entities;

[TestClass]
public sealed partial class ItemTests
{
    private readonly static Guid _validItemId = Guid.Parse("c1d67190-3a66-4201-a8f8-cd56f6ab10a4");
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

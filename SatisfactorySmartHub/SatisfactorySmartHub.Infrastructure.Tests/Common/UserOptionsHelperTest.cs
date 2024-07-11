using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Common;
using SatisfactorySmartHub.Infrastructure.Common;

namespace SatisfactorySmartHub.Infrastructure.Tests.Common;

[TestClass]
public class UserOptionsHelperTest
{
    [TestMethod]
    public void UserOptionsHelper_GetUserOptions()
    {
        //arrange
        UserOptionsHelper optionsHelper = new UserOptionsHelper();

        //act
        IUserOptions options = optionsHelper.GetUserOptions();

        //assert
        Assert.IsFalse(options.OverWriteSaveFile);
    }

    [TestMethod]
    public void UserOptionsHelper_SetUserOptions()
    {
        //arrange
        UserOptionsHelper optionsHelper = new UserOptionsHelper();
        IUserOptions userOptions1 = new UserOptions();

        //act
        userOptions1.OverWriteSaveFile = true;
        optionsHelper.SetUserOptions(userOptions1);
        IUserOptions userOptions2 = optionsHelper.GetUserOptions();

        //assert
        Assert.IsTrue(userOptions2.OverWriteSaveFile);

        //act
        userOptions2.OverWriteSaveFile = false;
        optionsHelper.SetUserOptions(userOptions2);
        IUserOptions userOptions3 = optionsHelper.GetUserOptions();

        //assert
        Assert.IsFalse(userOptions3.OverWriteSaveFile);
    }
}
using Microsoft.Extensions.Options;
using Microsoft.Testing.Platform.Extensions.Messages;
using Moq;
using Newtonsoft.Json;
using SatisfactorySmartHub.Domain.Models;
using SatisfactorySmartHub.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Tests.Persistance;


public sealed partial class UserDataServiceTests
{
    [TestMethod]
    [TestCategory("Methods")]
    public void SetUserData_ReturnsTrue_WhenSaveWasSuccessfull()
    {
        //arrange
        UserDataService service = CreateMockedInstance();
        UserDataModel userDataModel = new UserDataModel();

        //act
        bool result = service.SetUserData(userDataModel);

        //assert
        Assert.IsTrue(result);
        _jsonSerializerMock.Verify(x => x.Serialize(It.IsAny<UserDataModel>(), It.IsAny<JsonSerializerOptions>()), Times.Once());
        _fileProviderMock.Verify(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
    }

    [TestMethod]
    [TestCategory("Methods")]
    public void SetUserData_ReturnsFalse_WhenModelIsNotSerializeable()
    {
        //arrange
        UserDataService service = CreateMockedInstance();
        UserDataModel userDataModel = new UserDataModel();

        _jsonSerializerMock.Setup(x => x.Serialize(It.IsAny<UserDataModel>(), It.IsAny<JsonSerializerOptions>())).Throws(new Exception());

        //act
        bool result = service.SetUserData(userDataModel);

        //assert
        Assert.IsFalse(result);
        _jsonSerializerMock.Verify(x => x.Serialize(It.IsAny<UserDataModel>(), It.IsAny<JsonSerializerOptions>()), Times.Once());
    }

    [TestMethod]
    [TestCategory("Methods")]
    public void SetUserData_ReturnsFalse_WhenFileIsNotWriteable()
    {
        //arrange
        UserDataService service = CreateMockedInstance();
        UserDataModel userDataModel = new UserDataModel();

        _fileProviderMock.Setup(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>())).Throws(new Exception());

        //act
        bool result = service.SetUserData(userDataModel);

        //assert
        Assert.IsFalse(result);
        _fileProviderMock.Verify(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
    }
}
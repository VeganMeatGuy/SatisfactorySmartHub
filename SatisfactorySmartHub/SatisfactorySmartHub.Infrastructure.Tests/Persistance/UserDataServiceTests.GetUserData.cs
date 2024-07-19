using Moq;
using SatisfactorySmartHub.Domain.Models;
using SatisfactorySmartHub.Infrastructure.Persistance;
using System.Text.Json;

namespace SatisfactorySmartHub.Infrastructure.Tests.Persistance;

public sealed partial class UserDataServiceTests
{
    [TestMethod]
    [TestCategory("Methods")]
    public void GetUserData_ReturnsUserDataModel_WhenFileExist()
    {
        //arrange
        UserDataService service = CreateMockedInstance();
        UserDataModel testModel = new UserDataModel();

        _fileProviderMock.Setup(x => x.Exists(It.IsAny<string>())).Returns(true);
        _jsonSerializerMock.Setup(x => x.Deserialize<UserDataModel>(It.IsAny<string>())).Returns(testModel);

        //act
        UserDataModel result = service.GetUserData();

        //assert
        Assert.AreSame(testModel, result);
        _fileProviderMock.Verify(x => x.Exists(It.IsAny<string>()), Times.Once());
        _fileProviderMock.Verify(x => x.ReadAllText(It.IsAny<string>()), Times.Once());
        _jsonSerializerMock.Verify(x => x.Deserialize<UserDataModel>(It.IsAny<string>()), Times.Once());
    }

    [TestMethod]
    [TestCategory("Methods")]
    public void GetUserData_ReturnsNewUserDataModel_WhenFileDoesNotExist()
    {
        //arrange
        UserDataService service = CreateMockedInstance();

        _fileProviderMock.Setup(x => x.Exists(It.IsAny<string>())).Returns(false);

        //act
        UserDataModel result = service.GetUserData();

        //assert
        Assert.IsNotNull(result);
        _fileProviderMock.Verify(x => x.Exists(It.IsAny<string>()), Times.Once());
    }

    [TestMethod]
    [TestCategory("Methods")]
    [ExpectedException(typeof(JsonException))]
    public void GetUserData_ShouldThrowJsonException_WhenStringIsNotDeserializeable()
    {
        //arrange
        UserDataService service = CreateMockedInstance();

        _fileProviderMock.Setup(x => x.Exists(It.IsAny<string>())).Returns(true);
        _fileProviderMock.Setup(x => x.ReadAllText(It.IsAny<string>())).Returns("unittest");

        //act
        UserDataModel result = service.GetUserData();

    }
}

using Moq;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Infrastructure.Interfaces.Provider;
using SatisfactorySmartHub.Infrastructure.Persistance;

namespace SatisfactorySmartHub.Infrastructure.Tests.Persistance;

[TestClass]
public sealed partial class UserDataServiceTests
{
    private Mock<IFileProvider> _fileProviderMock = new();
    private Mock<IJsonSerializer> _jsonSerializerMock = new();

    [TestMethod]
    [TestCategory("Constructor")]
    public void UserDataServiceTest()
    {
        IUserDataService? userDataService;

        userDataService = CreateMockedInstance();

        Assert.IsNotNull(userDataService);
    }

    /// <summary>
    /// Creates a new instance of the <see cref="UserDataService"/> class with mocked dependencies.
    /// </summary>
    /// <returns>The new instance with mocked dependencies.</returns>
    private UserDataService CreateMockedInstance()
    {
        _fileProviderMock = new();
        _jsonSerializerMock = new();

        return new UserDataService(_fileProviderMock.Object, _jsonSerializerMock.Object);
    }

}

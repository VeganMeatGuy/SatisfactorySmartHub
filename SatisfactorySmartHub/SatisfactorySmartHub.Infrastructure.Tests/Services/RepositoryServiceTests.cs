using Moq;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Infrastructure.Services;

namespace SatisfactorySmartHub.Infrastructure.Tests.Services;

[TestClass]
public sealed partial class RepositoryServiceTests
{
    private Mock<IServiceProvider> _serviceProviderMock = new ();

    [TestMethod]
    [TestCategory("Constructor")]
    public void RepositoryServiceTest()
    {
        IRepositoryService? repositoryService;

        repositoryService = CreateMockedInstance();

        Assert.IsNotNull(repositoryService);
    }

    /// <summary>
    /// Creates a new instance of the <see cref="RepositoryService"/> class with mocked dependencies.
    /// </summary>
    /// <returns>The new instance with mocked dependencies.</returns>
    private RepositoryService CreateMockedInstance()
    {
        _serviceProviderMock = new();
        return new RepositoryService(_serviceProviderMock.Object);
    }
}

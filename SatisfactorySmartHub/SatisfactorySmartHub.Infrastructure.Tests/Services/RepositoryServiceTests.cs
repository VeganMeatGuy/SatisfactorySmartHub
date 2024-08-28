using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Tests.Services;

[TestClass]
public sealed partial class RepositoryServiceTests
{
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
        return new RepositoryService();
    }
}

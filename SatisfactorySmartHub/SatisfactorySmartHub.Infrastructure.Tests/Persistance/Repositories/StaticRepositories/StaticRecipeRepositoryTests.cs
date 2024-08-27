using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Infrastructure.Persistance.Repositories.StaticRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Tests.Persistance.Repositories.StaticRepositories;

[TestClass]
public sealed partial class StaticRecipeRepositoryTests
{
    [TestMethod]
    [TestCategory("Constructor")]
    public void StaticRecipeRepositoryTest()
    {
        IRecipeRepository? staticRecipeRepository;

        staticRecipeRepository = CreateMockedInstance();
        
        Assert.IsNotNull(staticRecipeRepository);
    }

    /// <summary>
    /// Creates a new instance of the <see cref="StaticRecipeRepository"/> class with mocked dependencies.
    /// </summary>
    /// <returns>The new instance with mocked dependencies</returns>
    private StaticRecipeRepository CreateMockedInstance()
    {
        return new StaticRecipeRepository();
    }
}

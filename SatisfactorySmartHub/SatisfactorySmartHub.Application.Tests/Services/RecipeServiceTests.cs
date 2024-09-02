using Moq;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Tests.Services;

[TestClass]
public sealed partial class RecipeServiceTests
{
    private Mock<IRepositoryService> _repositoryServiceMock = new();

    [TestMethod]
    [TestCategory("Constructor")]
    public void RecipeServiceTest()
    {
        //arrange
        IRecipeService? recipeService;

        //act
        recipeService = CreateMockedInstance();

        //assert
        Assert.IsNotNull(recipeService);
    }

    /// <summary>
    /// Creates a new instance of the <see cref="RecipeService"/> class with mocked dependencies.
    /// </summary>
    /// <returns>The new instance with mocked dependencies.</returns>
    private RecipeService CreateMockedInstance()
    {
        _repositoryServiceMock = new();
        return new RecipeService(_repositoryServiceMock.Object);
    }
}

using Moq;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Services;
using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Tests.Services;

public sealed partial class RecipeServiceTests
{
    [TestMethod]
    [TestCategory("Method")]
    public void GetAllRecipes_ReturnsCollection_WhenCalled()
    {
        //arrange
        RecipeService service = CreateMockedInstance();
        CorporationModel corporationModel = new();
        _repositoryServiceMock.Setup(x => x.StaticRecipeRepository.GetAll()).Returns(new List<RecipeModel>());

        //act
        ICollection<RecipeModel> result = service.GetAllRecipes();

        //assert
        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.Count);
    }
}

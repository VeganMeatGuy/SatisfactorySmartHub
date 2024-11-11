using SatisfactorySmartHub.Domain.Models;
using SatisfactorySmartHub.Infrastructure.Persistance.Repositories.StaticRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Tests.Persistance.Repositories.StaticRepositories;

public sealed partial class StaticRecipeRepositoryTests
{
    [TestMethod]
    [TestCategory("Methods")]
    public void GetAll_ShouldReturnCollectionOfRecipeModels()
    {
        //arrange
        StaticRecipeRepository repo = CreateMockedInstance();

        //act
        ICollection<RecipeModel> result = repo.GetAll();

        //assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Count() > 1);
    }
}

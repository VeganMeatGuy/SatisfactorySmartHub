using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories;
using SatisfactorySmartHub.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Tests.Services;

public sealed partial class RepositoryServiceTests
{
    [TestMethod]
    [TestCategory("Properties")]
    public void StaticRecipeRepository_ShouldReturnRepo()
    {
        //arrange
        RepositoryService repositoryService = new RepositoryService();

        //act
        IRecipeRepository result = repositoryService.StaticRecipeRepository;

        //assert
        Assert.IsNotNull(result);
    }

}

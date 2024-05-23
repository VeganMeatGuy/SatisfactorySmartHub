using SatisfactoryCalculator.Application.Services;
using SatisfactoryCalculator.Domain.Models;
using SatisfactoryCalculator.Infrastructure.Persistence.StaticDataModel;

namespace SatisfactoryCalculator.Tests.Application.Services;

[TestClass]
public class ProductionLineModelServiceTest
{
    [TestMethod]
    public void ProductionLineModelService_GetProductionLinesForItem()
    {
        //arrange
        ProductionLineModelService prodLineService = new ProductionLineModelService(new RecipeModelService());


        //act
        List<ProductionLineModel> productionLines = prodLineService.GetProductionLinesForItem(Items.IronRod);

        //assert
        Assert.AreEqual(productionLines.Count, 5);
    }
}

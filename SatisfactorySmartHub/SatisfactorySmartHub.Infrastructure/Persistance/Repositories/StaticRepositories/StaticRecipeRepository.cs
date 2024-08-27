using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories;
using SatisfactorySmartHub.Domain.Models;
using SatisfactorySmartHub.Infrastructure.Persistance.Repositories.StaticRepositories.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Repositories.StaticRepositories;

/// <summary>
/// The static recipe repository.
/// </summary>
internal class StaticRecipeRepository : IRecipeRepository
{
    private ICollection<RecipeModel> _recipeList = new HashSet<RecipeModel>();

    public StaticRecipeRepository()
    {
        InitializeStaticData();
    }

    public ICollection<RecipeModel> GetAll() => _recipeList;

    private void InitializeStaticData()
    {
        //Iron
        _recipeList.Add(Recipes.IronIngot);
        _recipeList.Add(Recipes.IronAlloyIngot);
        _recipeList.Add(Recipes.PureIronIngot);
        //IronRod
        _recipeList.Add(Recipes.IronRod);
        _recipeList.Add(Recipes.SteelRod);
        //Screw
        _recipeList.Add(Recipes.Screw);
        _recipeList.Add(Recipes.CastScrew);
        _recipeList.Add(Recipes.SteelScrew);
        //Steel
        _recipeList.Add(Recipes.SteelIngot);
        //SteelBeam
        _recipeList.Add(Recipes.SteelBeam);
        //HeavyModularFrames
        _recipeList.Add(Recipes.HeavyEncasedFrame);
        //HeavyOil
        _recipeList.Add(Recipes.HeavyOilResidue);
        //Fuel
        _recipeList.Add(Recipes.Fuel);
        //AluminumScrap
        _recipeList.Add(Recipes.AluminumScrap);
    }
}

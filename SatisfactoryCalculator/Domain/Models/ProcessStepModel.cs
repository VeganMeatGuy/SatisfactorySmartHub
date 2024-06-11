using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SatisfactoryCalculator.Domain.Models;

internal class ProcessStepModel
{
    private RecipeModel _recipe = new();

    public RecipeModel Recipe
    {
        get => _recipe;
        set => _recipe = value;
    }
}

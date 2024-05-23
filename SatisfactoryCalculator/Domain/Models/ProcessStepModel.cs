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
    private ICollection<ProcessStepModel> _preSteps = new HashSet<ProcessStepModel>();
    private ProcessStepModel? _postStep;
    private RecipeModel _recipe = new();

    public ICollection<ProcessStepModel> PreSteps
    {
        get => _preSteps;
        set => _preSteps = value;
    }

    public ProcessStepModel? PostStep
    {
        get => _postStep;
        set => _postStep = value;
    }
    public RecipeModel Recipe
    {
        get => _recipe;
        set => _recipe = value;
    }

}

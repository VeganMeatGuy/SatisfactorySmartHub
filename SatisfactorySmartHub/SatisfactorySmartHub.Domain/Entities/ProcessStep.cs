using ErrorOr;
using SatisfactorySmartHub.Domain.Entities.Base;
using static SatisfactorySmartHub.Domain.Errors.DomainErrors;

namespace SatisfactorySmartHub.Domain.Entities;

public sealed class ProcessStep : IdentityEntityBase
{
    //empty constructor for EF Core
    private ProcessStep() { }

    //foreign key
    public Guid BranchId { get; private set; }
    public Guid? RecipeId { get; private set; }


    //navigational property
    public Branch Branch { get; private set; }
    public Recipe? Recipe { get; private set; }
    public ProcessStepTarget? Target { get; private set; }
    public IEnumerable<MachineryConfigItem> ImplementedMachinery { get; private set; } = new List<MachineryConfigItem>();


    //Methods
    public static ErrorOr<ProcessStep> Create(Guid branchId)
    {
        var processStep = new ProcessStep()
        {
            BranchId = branchId,
        };
        return processStep;
    }

    public ErrorOr<Success> ChangeRecipeId(Guid recipeId)
    {
        RecipeId = recipeId;
        return Result.Success;
    }
}


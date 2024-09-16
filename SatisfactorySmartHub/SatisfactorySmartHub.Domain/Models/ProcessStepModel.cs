using SatisfactorySmartHub.Domain.Models.Enums;
using System.ComponentModel;

namespace SatisfactorySmartHub.Domain.Models;

public sealed class ProcessStepModel
{
    private RecipeModel? _recipe;
    private ItemWithAmount? _processStepTarget;
    private ICollection<ItemBalanceModel>? _plannedFlowOfMaterials;
    private ICollection<ItemBalanceModel>? _implementedFlowOfMaterials;
    private ICollection<MachineryConfigItemModel>? _plannedMachinery;
    private ICollection<MachineryConfigItemModel>? _implementedMachinery;
    private ProcessStepStatus _status = ProcessStepStatus.New;

    public RecipeModel? Recipe
    {
        get => _recipe;
        set => _recipe = value;
    }

    public ItemWithAmount? ProcessStepTarget
    {
        get => _processStepTarget;
        set => _processStepTarget = value;
    }

    public ICollection<ItemBalanceModel>? PlannedFlowOfMaterials
    {
        get => _plannedFlowOfMaterials;
        set => _plannedFlowOfMaterials = value;
    }

    public ICollection<ItemBalanceModel>? ImplementedFlowOfMaterials
    {
        get => _implementedFlowOfMaterials;
        set => _implementedFlowOfMaterials = value;
    }

    public ICollection<MachineryConfigItemModel>? PlannedMachinery
    {
        get => _plannedMachinery;
        set => _plannedMachinery = value;
    }

    public ICollection<MachineryConfigItemModel>? ImplementedMachinery
    {
        get => _implementedMachinery;
        set => _implementedMachinery = value;
    }

    public ProcessStepStatus Status
    {
        get => _status;
        set => _status = value;
    }
}

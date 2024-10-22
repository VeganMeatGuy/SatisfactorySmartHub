using ErrorOr;
using SatisfactorySmartHub.Application.DataTranferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Domain.Models;
using SatisfactorySmartHub.Domain.Models.Enums;
using System.Reflection.Metadata.Ecma335;

namespace SatisfactorySmartHub.Application.Services;


/// <inheritdoc cref="IProcessStepService"/>
internal sealed class ProcessStepService(
    IRepositoryService repositoryService) : IProcessStepService
{
    public ErrorOr<IProcessStepDto> AddProcessStep(Guid branchId)
    {
        ErrorOr<ProcessStep> CreateProcessStepResult = ProcessStep.Create(branchId);

        if (CreateProcessStepResult.IsError)
        {
            //do something to error handling
            // something like: return ApplicationErrors.CorporationService.CorporationWasNotInDb;
            return Error.Unexpected();
        }

        ProcessStep newProcessStep = CreateProcessStepResult.Value;

        ProcessStep? dbProcessStep = repositoryService.ProcessStepRepository.GetById(newProcessStep.Id);

        if (dbProcessStep != null)
        {
            return Error.Failure();
        }

        repositoryService.ProcessStepRepository.Create(newProcessStep);

        return ProcessStepDto.CreateFromEntity(newProcessStep);
    }

    public ErrorOr<Updated> UpdateProcessStep(IProcessStepDto processStep)
    {
        throw new NotImplementedException();
    }

    public ErrorOr<Deleted> DeleteProcessStep(IProcessStepDto processStep)
    {
        ProcessStep? dbProcessStep = repositoryService.ProcessStepRepository.GetById(processStep.Id);

        if (dbProcessStep == null)
            return Error.NotFound();

        repositoryService.ProcessStepRepository.Delete(dbProcessStep);
        return Result.Deleted;
    }


    public ErrorOr<IEnumerable<IProcessStepDto>> GetProcessStepsOfBranch(Guid branchId)
    {
        try
        {
            List<ProcessStepDto> result = [];
            var repoResult = repositoryService.ProcessStepRepository.GetManyByCondition(x => x.BranchId == branchId);

            foreach (ProcessStep processStep in repoResult)
                result.Add(ProcessStepDto.CreateFromEntity(processStep));

            return result;
        }
        catch (Exception ex)
        {
            return new List<ProcessStepDto>();
        }
    }

    #region old stuff
    /// <inheritdoc cref="IProcessStepService.GetNewProcessStep"/>
    public ProcessStepModel GetNewProcessStep()
    {
        return new ProcessStepModel();
    }
    public ProcessStepModel SetRecipe(ProcessStepModel processStepModel, RecipeModel recipe)
    {
        if (processStepModel == null) throw new ArgumentNullException(nameof(processStepModel));
        if (recipe == null) throw new ArgumentNullException(nameof(recipe));

        processStepModel.ProcessStepTarget = null;
        processStepModel.PlannedFlowOfMaterials = null;
        processStepModel.PlannedMachinery = null;
        processStepModel.ImplementedMachinery = null;
        processStepModel.ImplementedFlowOfMaterials = null;

        processStepModel.Recipe = recipe;
        processStepModel.Status = ProcessStepStatus.RecipeSet;

        return processStepModel;
    }
    public ProcessStepModel SetProcessStepTarget(ProcessStepModel processStepModel, Domain.Models.ItemWithAmount targetItemWithAmount, MachineryPlanningType machineryPlanningType)
    {
        //check parameters
        if (processStepModel == null)
            throw new ArgumentNullException(nameof(processStepModel));
        if (targetItemWithAmount ==
            null) throw new ArgumentNullException(nameof(targetItemWithAmount));

        //check requirements
        if (decimal.Round(targetItemWithAmount.Amount, 2) != targetItemWithAmount.Amount)
            throw new Exception("Input Menge darf maximal zwei Kommastellen haben.");
        if (processStepModel.Recipe == null)
            throw new Exception("Rezept muss zuerst gesetzt werden.");
        if (processStepModel.Recipe.GetItemUsageInRecipe(targetItemWithAmount.Item) == RecipeComponentType.NotIncluded)
            throw new Exception("Item ist nicht im Rezept vorhanden.");

        //logic
        processStepModel.ProcessStepTarget = targetItemWithAmount;
        processStepModel.PlannedFlowOfMaterials = PlanFlowOfMaterials(processStepModel);
        processStepModel.PlannedMachinery = PlanMachinery(processStepModel, machineryPlanningType);
        processStepModel.Status = ProcessStepStatus.TargetSet;
        return processStepModel;

    }
    private ICollection<MachineryConfigItemModel> PlanMachinery(ProcessStepModel processStepModel, MachineryPlanningType machineryPlanningType)
    {
        throw new NotImplementedException();
    }
    private ICollection<ItemBalanceModel> PlanFlowOfMaterials(ProcessStepModel processStepModel)
    {
        if (processStepModel.Recipe == null)
            throw new Exception("Rezept muss zuerst gesetzt werden.");

        if (processStepModel.ProcessStepTarget == null)
            return CalculateBalanceWithoutTarget();

        switch (processStepModel.Recipe.GetItemUsageInRecipe(processStepModel.ProcessStepTarget.Item))
        {
            case RecipeComponentType.MainProduct:
                return CalculateBalanceProductTarget();
            case RecipeComponentType.Ingredient:
                return CalculateBalanceIngredientTarget();
            case RecipeComponentType.ByProduct:
                return CalculateBalanceByProductTarget();
            default:
                return CalculateBalanceWithoutTarget();
        }
    }
    private ICollection<ItemBalanceModel> CalculateBalanceProductTarget()
    {
        throw new NotImplementedException();
        //ICollection<ItemBalanceModel> balance = new HashSet<ItemBalanceModel>();

        //decimal standardmenge = Recipe.MainProduct.Amount;
        //decimal multiplikator = ProcessStepTarget.Amount / standardmenge;

        //ItemBalanceModel MainProduct = new ItemBalanceModel();
        //MainProduct.Item = Recipe.MainProduct.Item;
        //MainProduct.ProducedAmount = ProcessStepTarget.Amount;

        //balance.Add(MainProduct);


        //foreach (ItemWithAmount bypitem in Recipe.Byproducts)
        //{
        //    ItemBalanceModel byProduct = new ItemBalanceModel();
        //    byProduct.Item = bypitem.Item;
        //    byProduct.ProducedAmount = decimal.Round(multiplikator * bypitem.Amount, 2, MidpointRounding.ToNegativeInfinity);
        //    balance.Add(byProduct);
        //}

        //foreach (ItemWithAmount inItem in Recipe.Ingredients)
        //{
        //    ItemBalanceModel ingredient = new ItemBalanceModel();
        //    ingredient.Item = inItem.Item;
        //    ingredient.NeededAmount = decimal.Round(multiplikator * inItem.Amount, 2, MidpointRounding.ToPositiveInfinity);
        //    balance.Add(ingredient);
        //}

        //return balance;
    }
    private ICollection<ItemBalanceModel> CalculateBalanceIngredientTarget()
    {
        throw new NotImplementedException();
        //ICollection<ItemBalanceModel> balance = new HashSet<ItemBalanceModel>();

        //ItemWithAmount target = Recipe.Ingredients.First(x => x.Item.Name == ProcessStepTarget.Item.Name);

        //decimal standardmenge = target.Amount;
        //decimal multiplikator = ProcessStepTarget.Amount / standardmenge;

        //ItemBalanceModel MainProduct = new ItemBalanceModel();
        //MainProduct.Item = Recipe.MainProduct.Item;
        //MainProduct.ProducedAmount = decimal.Round(multiplikator * Recipe.MainProduct.Amount, 2, MidpointRounding.ToNegativeInfinity);

        //balance.Add(MainProduct);


        //foreach (ItemWithAmount bypitem in Recipe.Byproducts)
        //{
        //    ItemBalanceModel byProduct = new ItemBalanceModel();
        //    byProduct.Item = bypitem.Item;
        //    byProduct.ProducedAmount = decimal.Round(multiplikator * bypitem.Amount, 2, MidpointRounding.ToNegativeInfinity);
        //    balance.Add(byProduct);
        //}

        //foreach (ItemWithAmount inItem in Recipe.Ingredients)
        //{
        //    ItemBalanceModel ingredient = new ItemBalanceModel();
        //    ingredient.Item = inItem.Item;
        //    if (inItem.Item.Name == target.Item.Name)
        //        ingredient.NeededAmount = ProcessStepTarget.Amount;
        //    else
        //        ingredient.NeededAmount = decimal.Round(multiplikator * inItem.Amount, 2, MidpointRounding.ToPositiveInfinity);
        //    balance.Add(ingredient);
        //}

        //return balance;
    }
    private ICollection<ItemBalanceModel> CalculateBalanceByProductTarget()
    {
        throw new NotImplementedException();
        //ICollection<ItemBalanceModel> balance = new HashSet<ItemBalanceModel>();

        //ItemWithAmount target = Recipe.Byproducts.First(x => x.Item.Name == ProcessStepTarget.Item.Name);

        //decimal standardmenge = target.Amount;
        //decimal multiplikator = ProcessStepTarget.Amount / standardmenge;

        //ItemBalanceModel MainProduct = new ItemBalanceModel();
        //MainProduct.Item = Recipe.MainProduct.Item;
        //MainProduct.ProducedAmount = decimal.Round(multiplikator * Recipe.MainProduct.Amount, 2, MidpointRounding.ToNegativeInfinity);

        //balance.Add(MainProduct);


        //foreach (ItemWithAmount bypitem in Recipe.Byproducts)
        //{
        //    ItemBalanceModel byProduct = new ItemBalanceModel();
        //    byProduct.Item = bypitem.Item;
        //    if (bypitem.Item.Name == target.Item.Name)
        //        byProduct.ProducedAmount = ProcessStepTarget.Amount;
        //    else
        //        byProduct.ProducedAmount = decimal.Round(multiplikator * bypitem.Amount, 2, MidpointRounding.ToNegativeInfinity);
        //    balance.Add(byProduct);
        //}

        //foreach (ItemWithAmount inItem in Recipe.Ingredients)
        //{
        //    ItemBalanceModel ingredient = new ItemBalanceModel();
        //    ingredient.Item = inItem.Item;
        //    ingredient.NeededAmount = decimal.Round(multiplikator * inItem.Amount, 2, MidpointRounding.ToPositiveInfinity);
        //    balance.Add(ingredient);
        //}

        //return balance;
    }
    private ICollection<ItemBalanceModel> CalculateBalanceWithoutTarget()
    {
        throw new NotImplementedException();
        //    ICollection<ItemBalanceModel> balance = new HashSet<ItemBalanceModel>();

        //    balance.Add(new ItemBalanceModel() { Item = Recipe.MainProduct.Item });

        //    foreach (ItemWithAmount bypitem in Recipe.Byproducts)
        //    {
        //        balance.Add(new ItemBalanceModel() { Item = bypitem.Item });
        //    }

        //    foreach (ItemWithAmount inItem in Recipe.Ingredients)
        //    {
        //        balance.Add(new ItemBalanceModel() { Item = inItem.Item });
        //    }

        //    return balance;
    }


    #endregion

}

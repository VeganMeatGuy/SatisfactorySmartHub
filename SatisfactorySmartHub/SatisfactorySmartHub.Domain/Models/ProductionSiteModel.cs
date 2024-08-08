using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Models;

public sealed class ProductionSiteModel
{
    private ObservableCollection<ProcessStepModel> _processSteps = new ObservableCollection<ProcessStepModel>();
    private bool _CalculationIsDone = false;

    public ObservableCollection<ProcessStepModel> ProcessSteps
    {
        get => _processSteps;
        set => _processSteps = value;
    }

    public bool CalculationIsDone
    {
        get => _CalculationIsDone;
        set => _CalculationIsDone = value;
    }

    public ICollection<ItemBalanceModel> GetBalance()
    {
        ICollection<ItemBalanceModel> result = new HashSet<ItemBalanceModel>();

        foreach (ProcessStepModel processStep in ProcessSteps)
        {

            foreach (ItemBalanceModel item in processStep.GetBalance())
                if (result.Any(x => x.Item.Name == item.Item.Name))
                {
                    result.First(x => x.Item.Name == item.Item.Name).ProducedAmount += item.ProducedAmount;
                    result.First(x => x.Item.Name == item.Item.Name).ProducedAmount += item.NeededAmount;
                }
                else
                    result.Add(item);
        }
        return result;
    }
}


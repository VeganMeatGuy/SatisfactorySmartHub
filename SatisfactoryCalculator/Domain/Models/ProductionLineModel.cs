using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactoryCalculator.Domain.Models
{
    internal class ProductionLineModel
    {
        private ICollection<ProcessStepModel> _processSteps = new HashSet<ProcessStepModel>();
        private bool _CalculationIsDone = false;

        public ICollection<ProcessStepModel> ProcessSteps
        {
            get => _processSteps;
            set => _processSteps = value;
        }

        public bool CalculationIsDone
        {
            get => _CalculationIsDone;
            set => _CalculationIsDone = value;
        }

        public ICollection<ItemBalanceModel> GetBalanceItemOnly()
        {
            ICollection<ItemBalanceModel> result = new HashSet<ItemBalanceModel>();

            foreach (ProcessStepModel processStep in this.ProcessSteps)
            {
                //hier weiter

                //ItemWithAmount pro = processStep.Recipe.MainProduct;
                //ICollection<ItemWithAmount> byp = processStep.Recipe.Byproducts;
                //ICollection<ItemWithAmount> ing = processStep.Recipe.Ingredients;

                //if (result.Any(x => x.Item.Name == pro.Item.Name))
                //    result.First(x => x.Item.Name == pro.Item.Name).OutAmount += 1;
                //else
                //    result.Add(new() { Item = pro.Item, OutAmount = 1 });

                //foreach (ItemWithAmount bypitem in byp)
                //{
                //    if (result.Any(x => x.Item.Name == bypitem.Item.Name))
                //        result.First(x => x.Item.Name == bypitem.Item.Name).OutAmount += 1;
                //    else
                //        result.Add(new() { Item = bypitem.Item, OutAmount = 1 });
                //}

                //foreach (ItemWithAmount ingitem in ing)
                //{
                //    if (result.Any(x => x.Item.Name == ingitem.Item.Name))
                //        result.First(x => x.Item.Name == ingitem.Item.Name).InAmount += 1;
                //    else
                //        result.Add(new() { Item = ingitem.Item, InAmount = 1 });
                //}
            }
            return result;
        }
    }
}


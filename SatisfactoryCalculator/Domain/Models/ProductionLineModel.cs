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
    }
}


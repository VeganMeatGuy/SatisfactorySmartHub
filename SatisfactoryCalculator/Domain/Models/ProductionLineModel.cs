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
        public ICollection<ProcessStepModel> ProcessSteps
        {
            get => _processSteps;
            set => _processSteps = value;
        }
    }
}


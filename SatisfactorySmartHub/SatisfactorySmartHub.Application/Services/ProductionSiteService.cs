using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Services;


/// <summary>
/// The production site service class.
/// It implements  the <see cref="IProductionSiteService"/> interface.
/// </summary>
internal sealed class ProductionSiteService : IProductionSiteService
{
    public void AddProcessStepToProductionSite(ProcessStepModel processStep, ProductionSiteModel productionSite)
    {
        productionSite.ProcessSteps.Add(processStep);
    }

    public bool RemoveProcessStepFromProductionSite(ProcessStepModel processStep, ProductionSiteModel productionSite)
    {
        return productionSite.ProcessSteps.Remove(processStep);
    }
}

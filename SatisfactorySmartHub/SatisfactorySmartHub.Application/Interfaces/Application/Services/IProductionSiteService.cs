using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;

/// <summary>
/// The production site  service interface.
/// </summary>
public interface IProductionSiteService
{
    /// <summary>
    /// Adds the given process step to the given production site.
    /// </summary>
    /// <param name="processStep">The process step which is added to the production site.</param>
    /// <param name="productionSite">The production site which the process step is added to.</param>
    void AddProcessStepToProductionSite(ProcessStepModel processStep, ProductionSiteModel productionSite);

    /// <summary>
    /// Removes the given process step from the given production site.
    /// </summary>
    /// <param name="processStep">The process step which is removed from the production site.</param>
    /// <param name="productionSite">The production site which the process step is removed from.</param>
    /// <returns></returns>
    bool RemoveProcessStepFromProductionSite(ProcessStepModel processStep, ProductionSiteModel productionSite);
}

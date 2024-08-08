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
    /// Adds the given production site to the given branch.
    /// </summary>
    /// <param name="processStep">The process step which is added to the production site.</param>
    /// <param name="productionSite">The production site which the process step is added to.</param>
    void AddProcessStepToProductionSite(ProcessStepModel processStep, ProductionSiteModel productionSite);
}

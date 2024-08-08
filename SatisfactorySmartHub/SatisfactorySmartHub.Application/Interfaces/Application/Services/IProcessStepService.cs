using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;

/// <summary>
/// The process step service interface.
/// </summary>
public interface IProcessStepService
{
    /// <summary>
    /// Returns an empty process step model.
    /// </summary>
    /// <returns><see cref="ProcessStepModel"/></returns>
    ProcessStepModel GetNewProcessStep();
}

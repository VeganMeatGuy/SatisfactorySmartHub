using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Services;


/// <inheritdoc cref="IProcessStepService"/>
internal sealed class ProcessStepService : IProcessStepService
{
    /// <inheritdoc cref="IProcessStepService.GetNewProcessStep"/>
    public ProcessStepModel GetNewProcessStep()
    {
        return new ProcessStepModel();
    }
}

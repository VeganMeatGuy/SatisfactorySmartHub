using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;

/// <summary>
/// The branch service interface.
/// </summary>
public interface IBranchService
{
    /// <summary>
    /// Returns an empty branch model.
    /// </summary>
    /// <returns><see cref="BranchModel"/></returns>
    BranchModel GetNewBranch();
}

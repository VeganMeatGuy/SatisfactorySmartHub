using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Services;

/// <summary>
/// The branch service class.
/// It implements  the <see cref="IBranchService"/> interface.
/// </summary>
internal sealed class BranchService : IBranchService
{
    /// <inheritdoc cref="IBranchService.GetNewBranch"/>
    public BranchModel GetNewBranch()
    {
        return new BranchModel() { Name = "unbenannter Industriekomplex"};
    }
}

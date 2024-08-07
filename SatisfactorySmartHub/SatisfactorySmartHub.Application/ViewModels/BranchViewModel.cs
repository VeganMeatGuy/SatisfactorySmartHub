using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.ViewModels.Base;
using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.ViewModels;

public sealed class BranchViewModel : ViewModelBase
{
    private readonly ICachingService _cachingService;

    public BranchViewModel(ICachingService cachingService)
    {
        _cachingService = cachingService;
    }

    public BranchModel ActiveBranch => _cachingService.ActiveBranch;


}

using CommunityToolkit.Mvvm.Input;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Services;
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
    private readonly IProductionSiteService _productionSiteService;
    private readonly IProcessStepService _processStepService;

    private IRelayCommand? _addProcessStepCommand;

    public BranchViewModel(ICachingService cachingService, IProductionSiteService productionSiteService, IProcessStepService processStepService)
    {
        _cachingService = cachingService;
        _productionSiteService = productionSiteService;
        _processStepService = processStepService;
    }

    public BranchModel ActiveBranch => _cachingService.ActiveBranch;

    public IRelayCommand AddProcessStepCommand => _addProcessStepCommand ?? new RelayCommand(new Action(AddProcessStep));


    private void AddProcessStep()
    {
        BranchModel? branch = _cachingService.ActiveBranch;

        if (branch == null)
            return;

        ProductionSiteModel productionSite = branch.ProductionSite;

        ProcessStepModel processStep = _processStepService.GetNewProcessStep();



        _productionSiteService.AddProcessStepToProductionSite(processStep, productionSite);

        _cachingService.SetActiveBranch(branch);
    }
}

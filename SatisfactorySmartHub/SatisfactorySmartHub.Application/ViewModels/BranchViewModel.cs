using CommunityToolkit.Mvvm.Input;
using SatisfactorySmartHub.Application.Common;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Services;
using SatisfactorySmartHub.Application.ViewModels.Base;
using SatisfactorySmartHub.Domain.Common;
using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.ViewModels;

public sealed class BranchViewModel : ViewModelBase
{
    private readonly ICachingService _cachingService;
    private readonly IProductionSiteService _productionSiteService;
    private readonly IProcessStepService _processStepService;
    
    
    private ProcessStepModel _activeProcessStepModel;
    private IRelayCommand? _addProcessStepCommand;
    private IRelayCommand? _removeProcessStepCommand;
    private ReadonlyObservableList<ProcessStepModel> _processSteps = new ReadonlyObservableList<ProcessStepModel>();

    public BranchViewModel(ICachingService cachingService, IProductionSiteService productionSiteService, IProcessStepService processStepService)
    {
        _cachingService = cachingService;
        _productionSiteService = productionSiteService;
        _processStepService = processStepService;

        if (ActiveBranch == null)
            return;

        _processSteps = new ReadonlyObservableList<ProcessStepModel>(ActiveBranch.ProductionSite.ProcessSteps);
    }

    public BranchModel ActiveBranch => _cachingService.ActiveBranch;

    public ProcessStepModel SelectedProcessStep
    {
        get => _activeProcessStepModel;
        set => SetProperty(ref _activeProcessStepModel, value);
    }


    public ReadonlyObservableList<ProcessStepModel> ProcessSteps => _processSteps;


    public IRelayCommand AddProcessStepCommand => _addProcessStepCommand ?? new RelayCommand(new Action(AddProcessStep));
    public IRelayCommand RemoveProcessStepCommand => _removeProcessStepCommand ?? new RelayCommand(new Action(RemoveProcessStep));


    private void AddProcessStep()
    {
        BranchModel? branch = _cachingService.ActiveBranch;

        if (branch == null)
            return;

        ProductionSiteModel productionSite = branch.ProductionSite;

        ProcessStepModel processStep = _processStepService.GetNewProcessStep();
        _productionSiteService.AddProcessStepToProductionSite(processStep, productionSite);

        ProcessSteps.Update();
    }

    private void RemoveProcessStep()
    {
        ProductionSiteModel? productionSite = _cachingService.ActiveBranch.ProductionSite;

        if (productionSite == null)
            return;

        _productionSiteService.RemoveProcessStepFromProductionSite(SelectedProcessStep, productionSite);

        ProcessSteps.Update();
    }
}

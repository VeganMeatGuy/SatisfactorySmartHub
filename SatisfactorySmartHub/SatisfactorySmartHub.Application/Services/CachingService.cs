using SatisfactorySmartHub.Application.DataTranferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Domain.Common;

namespace SatisfactorySmartHub.Application.Services;
internal class CachingService : ObservableObjectBase, ICachingService
{
    private CorporationDto? _activeCorporationModel;
    private IBranchDto? _activeBranchModel;
    private bool _ActiveCorporationIsSet = false;
    private bool _ActiveBranchIsSet = false;

    public CorporationDto? ActiveCorporation
    {
        get => _activeCorporationModel;
        private set => SetProperty(ref _activeCorporationModel, value);
    }

    public bool ActiveCorporationIsSet
    {
        get => _ActiveCorporationIsSet;
        private set => SetProperty(ref _ActiveCorporationIsSet, value);
    }

    public IBranchDto? ActiveBranch
    {
        get => _activeBranchModel;
        private set => SetProperty(ref _activeBranchModel, value);
    }

    public void SetActiveBranch(IBranchDto? activeBranch)
    {
        if (activeBranch == null)
            return;
        ActiveBranch = activeBranch;
        _ActiveBranchIsSet = true;
    }

    public void SetActiveCorporation(CorporationDto? activeCorporation)
    {
        if (activeCorporation == null)
            return;
        ActiveCorporation = activeCorporation;
        ActiveCorporationIsSet = true;
    }

}

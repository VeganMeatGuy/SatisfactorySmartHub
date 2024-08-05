using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Domain.Common;
using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Application.Services;
internal class CachingService : ObservableObjectBase, ICachingService
{
    private CorporationModel? _activeCorporationModel;
    private bool _ActiveCorporationIsSet = false;

    public CorporationModel? ActiveCorporation
    {
        get => _activeCorporationModel;
        private set => SetProperty(ref _activeCorporationModel, value);
    }

    public bool ActiveCorporationIsSet
    {
        get => _ActiveCorporationIsSet;
        private set => SetProperty(ref _ActiveCorporationIsSet, value);
    }

    public void SetActiveCorporation(CorporationModel? activeCorporation)
    {
        if (activeCorporation == null)
            return;
        ActiveCorporation = activeCorporation;
        ActiveCorporationIsSet = true;
    }

}

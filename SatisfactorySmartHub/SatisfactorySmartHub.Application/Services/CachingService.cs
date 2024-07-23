using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Domain.Common;
using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Application.Services;
internal class CachingService : ObservableObjectBase, ICachingService
{
    private CorporationModel? _activeCorporationModel;

    public CorporationModel? ActiveCorporation
    {
        get => _activeCorporationModel;
        set => SetProperty(ref _activeCorporationModel, value);
    }
}

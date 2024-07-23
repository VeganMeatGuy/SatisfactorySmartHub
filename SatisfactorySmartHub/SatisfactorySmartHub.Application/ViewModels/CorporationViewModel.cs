using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.ViewModels.Base;
using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Application.ViewModels;

public sealed class CorporationViewModel(ICachingService cachingService) : ViewModelBase
{
    public CorporationModel ActiveCorporation => cachingService.ActiveCorporation;
}

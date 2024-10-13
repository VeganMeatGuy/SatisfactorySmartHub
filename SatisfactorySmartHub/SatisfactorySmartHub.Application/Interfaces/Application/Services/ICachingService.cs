using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Domain.Models;
using System.ComponentModel;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;
public interface ICachingService : INotifyPropertyChanging, INotifyPropertyChanged
{
    ICorporationDto? ActiveCorporation { get; }
    BranchModel? ActiveBranch { get; }
    bool ActiveCorporationIsSet { get; }
    void SetActiveCorporation(ICorporationDto? corporationModel);
    void SetActiveBranch(BranchModel? branchModel);
}

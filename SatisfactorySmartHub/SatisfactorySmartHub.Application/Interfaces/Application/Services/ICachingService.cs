using SatisfactorySmartHub.Application.DataTranferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using System.ComponentModel;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;
public interface ICachingService : INotifyPropertyChanging, INotifyPropertyChanged
{
    CorporationDto? ActiveCorporation { get; }
    IBranchDto? ActiveBranch { get; }
    bool ActiveCorporationIsSet { get; }
    void SetActiveCorporation(CorporationDto? corporationModel);
    void SetActiveBranch(IBranchDto? branchModel);
}

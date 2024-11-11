using SatisfactorySmartHub.Application.DataTranferObjects;
using System.ComponentModel;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;
public interface ICachingService : INotifyPropertyChanging, INotifyPropertyChanged
{
    CorporationDto? ActiveCorporation { get; }
    BranchDto? ActiveBranch { get; }
    bool ActiveCorporationIsSet { get; }
    void SetActiveCorporation(CorporationDto? corporationModel);
    void SetActiveBranch(BranchDto? branchModel);
}

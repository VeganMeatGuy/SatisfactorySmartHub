using ErrorOr;
using SatisfactorySmartHub.Application.DataTranferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;

/// <summary>
/// The corporation service interface.
/// </summary>
public interface ICorporationService
{
    IEnumerable<CorporationDto> GetCorporations();
    ErrorOr<CorporationDto> AddCorporation(string corporationName);
    ErrorOr<Updated> UpdateCorporation(CorporationDto corporation);

    /// <summary>
    /// Adds the given branch to the given corporation.
    /// </summary>
    /// <param name="branch">The branch which is added to the corporation.</param>
    /// <param name="corporation">The corporation model which the branch is added to.</param>
    /// <returns><see cref="BranchModel"/></returns>
    ErrorOr<Success> AddBranchToCorporation(IBranchDto branch, CorporationDto corporation);
}

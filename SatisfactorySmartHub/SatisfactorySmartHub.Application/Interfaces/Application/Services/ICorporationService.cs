using ErrorOr;
using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;

/// <summary>
/// The corporation service interface.
/// </summary>
public interface ICorporationService
{
    IEnumerable<ICorporationDto> GetCorporations();
    ErrorOr<ICorporationDto> AddCorporation(string corporationName);
    ErrorOr<Updated> UpdateCorporation(ICorporationDto corporation);

    /// <summary>
    /// Adds the given branch to the given corporation.
    /// </summary>
    /// <param name="branch">The branch which is added to the corporation.</param>
    /// <param name="corporation">The corporation model which the branch is added to.</param>
    /// <returns><see cref="BranchModel"/></returns>
   ErrorOr<Success> AddBranchToCorporation(IBranchDto branch, ICorporationDto corporation);
}

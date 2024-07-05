using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories.FileBased;

namespace SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;

/// <summary>
/// The repository Service interface.
/// </summary>
public interface IRepositoryService
{
    /// <summary>
    /// The corporationmodel file repository instance.
    /// </summary>
    ICorporationModelFileRepository CorporationModelFileRepository { get; }
}

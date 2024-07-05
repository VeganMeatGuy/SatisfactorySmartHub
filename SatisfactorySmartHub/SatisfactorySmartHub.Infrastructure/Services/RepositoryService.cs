using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories.FileBased;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Infrastructure.Persistance.Repositories.FileRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Services;

internal sealed class RepositoryService :IRepositoryService
{
    private readonly Lazy<CorporationModelFileRepository> _lazyCorporationFileRepository = new();

   public ICorporationModelFileRepository CorporationModelFileRepository 
        => _lazyCorporationFileRepository.Value;

   
}

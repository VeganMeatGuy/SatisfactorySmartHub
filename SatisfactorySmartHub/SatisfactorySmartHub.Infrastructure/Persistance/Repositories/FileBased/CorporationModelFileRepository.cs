using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories.FileBased;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Repositories.FileRepository
{
    internal class CorporationModelFileRepository : ICorporationModelFileRepository
    {
        public CorporationModel GetCorporation(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}

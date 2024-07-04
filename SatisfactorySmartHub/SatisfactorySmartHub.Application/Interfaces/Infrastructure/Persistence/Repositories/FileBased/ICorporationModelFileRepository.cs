using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories.FileBased;

public interface ICorporationModelFileRepository
{
    CorporationModel GetCorporation(string filePath);
}
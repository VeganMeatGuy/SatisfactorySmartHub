using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Services;

internal sealed class CorporationService : ICorporationService
{
    public CorporationModel GetNewCorporation(string corporationName)
    {
        return new CorporationModel() { Name = corporationName };
    }
}

using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories.Base;
using SatisfactorySmartHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories;

public interface IBranchRepository : IIdentityRepository<Branch>
{
}

using SatisfactorySmartHub.Domain.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Interfaces.Entities.Base;

public interface IIdentityEntityBase : IEntityBase
{
    Guid Id { get; init; }
}

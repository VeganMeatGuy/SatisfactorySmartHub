using SatisfactorySmartHub.Domain.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Entities.Base;

public abstract class IdentityEntityBase : EntityBase, IIdentityEntityBase
{
    public Guid Id { get; init; }
}

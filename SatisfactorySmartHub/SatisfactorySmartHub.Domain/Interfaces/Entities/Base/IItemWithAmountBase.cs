using SatisfactorySmartHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Interfaces.Entities.Base;

public interface IItemWithAmountBase : IEntityBase
{
    public Guid ItemId { get; init; }
    public decimal Amount { get; init; }

    //navigational properties
    public Item Item { get; init; }
}

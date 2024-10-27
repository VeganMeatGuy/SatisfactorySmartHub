using SatisfactorySmartHub.Domain.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Entities.Base;

public abstract class ItemWithAmountBase : IdentityEntityBase, IItemWithAmountBase
{
    public Guid ItemId { get; init; }
    public decimal Amount { get; init; }

    //navigational properties
    public Item Item { get; init; }
};

using SatisfactorySmartHub.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Entities;

public sealed class MachineryConfigItem : IdentityEntityBase
{
    //empty constructor for EF core
    private MachineryConfigItem() { }

    public int Quantity { get; private set; }
    public int ClockSpeed { get; private set; }

    //foreign key
    public Guid ProcessStepId { get; private set; }

    //navigational properties

    public ProcessStep? ProcessStep { get; private set; }
}

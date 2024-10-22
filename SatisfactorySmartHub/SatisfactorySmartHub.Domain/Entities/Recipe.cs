using SatisfactorySmartHub.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Entities;

public sealed class Recipe : IdentityEntityBase
{
    //empty constructor for EF Core
    private Recipe() { }
}

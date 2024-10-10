using SatisfactorySmartHub.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Entities;

public sealed class Corporation : IdentityEntityBase
{
    //empty constructor for EF Core
    private Corporation() { }

    public string Name { get; private set; } = string.Empty;

    public static Corporation Create(string name)
    {
        var corporation = new Corporation
        {
            Id = Guid.NewGuid(),
            Name = name
        };
        return corporation;
    }

}

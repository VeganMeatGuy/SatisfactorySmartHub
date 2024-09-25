using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Entities;

public class Item
{
    //empty constructor for EF Core
    private Item() { }

    public Guid Id { get; init; }
    public string Name { get; private set; }

    public static Item Create(string name)
    {
        var item = new Item
        {
            Id = Guid.NewGuid(),
            Name = name
        };
        return item;
    }

}

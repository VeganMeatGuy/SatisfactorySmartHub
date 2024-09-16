using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Models;

public class MachineryConfigItemModel
{
    private int _quantity;
    private int _clockspeed;

    public int Quantity 
    {
        get => _quantity;
        set => _quantity = value;
    }

    public int Clockspeed
    {
        get => _clockspeed;
        set => _clockspeed = value;
    }
}

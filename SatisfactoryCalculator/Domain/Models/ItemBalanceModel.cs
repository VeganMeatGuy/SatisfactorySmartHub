using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Models;

internal class ItemBalanceModel
{
    private ItemModel _item = new();
    private decimal _inAmount = 0;
    private decimal _outAmount = 0;

    public ItemModel Item
    {
        get => _item;
        set => _item = value;
    }

    public decimal NeededAmount
    {
        get => _inAmount;
        set => _inAmount = value;
    }

    public decimal ProducedAmount
    {
        get => _outAmount;
        set => _outAmount = value;
    }
}

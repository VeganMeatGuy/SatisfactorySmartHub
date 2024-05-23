using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SatisfactoryCalculator.Domain.Models
{
    internal class ItemWithAmount
    {
        private ItemModel _item = new ();
        private decimal _amount = 0;

        public ItemModel Item
        {
            get => _item;
            set => _item = value;
        }

        public decimal Amount
        {
            get => _amount;
            set => _amount = value;
        }
    }
}

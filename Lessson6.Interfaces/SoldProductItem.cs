using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessson6.Interfaces
{
    public class SoldProductItem : IInfoItem
    {
        public int ItemId { get; }
        public string SupplierNumber { get; set; }
        public void PrintInfo()
        {
            Console.WriteLine(ToString());
        }

        public SoldProductItem(int itemId)
        {
            ItemId = itemId;
        }

        public override string ToString()
        {
            return $"ItemId: {ItemId}\nSupplier Number: {SupplierNumber}\n";
        }
    }
}

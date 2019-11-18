using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Existek_Lesson1_1.ExCommon;

namespace Lessson6.Interfaces
{
    public class ProductItem : IInfoItem, ISequence
    {
        public int ItemId { get; }
        public string SupplierNumber { get; set; }
        public int Sequence { get; set; }

        public ProductItem()
        {
            ItemId = IdHelper.GetNextId();
        }

        public void PrintInfo()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"ItemId: {ItemId}\nSupplier Number: {SupplierNumber}\n";
        }

    }
}

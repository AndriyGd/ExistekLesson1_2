using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessson6.Interfaces
{
    public interface IInfoItem
    {
        int ItemId { get; }
        string SupplierNumber { get; set; }
        void PrintInfo();
    }
}

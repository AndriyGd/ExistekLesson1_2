using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8.Generics
{
    public class ProductsRepository<TProduct> : BaseRepository<TProduct> where TProduct: class
    {
        public bool DeleteProduct(TProduct product)
        {
           return Entities.Remove(product);
        }
    }
}

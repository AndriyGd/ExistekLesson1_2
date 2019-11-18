using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessson6.Interfaces
{
    public class ProductRepository
    {
        private readonly List<IInfoItem> _products;

        public ProductRepository()
        {
            _products = new List<IInfoItem>();
        }

        public void AddProduct(IInfoItem infoItem)
        {
            _products.Add(infoItem);
        }

        public List<TItem> GetItemsBy<TItem>() where TItem: IInfoItem
        {
            var result = new List<TItem>();
            foreach (var infoItem in _products)
            {
                if (infoItem is TItem item)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<IInfoItem> GetItemsBy()
        {
            return _products;
        }
    }
}

namespace Lesson19.Patterns.SingletonModels
{
    using System.Collections.Generic;
    using System.Linq;

    class ReportOrder
    {
        private readonly List<Order> _orders;

        public ReportOrder()
        {
            _orders = new List<Order>
            {
                new Order{ManagerId = 3, OrderName = "Milk"},
                new Order{ManagerId = 7, OrderName = "Fanta"},
                new Order{ManagerId = 23, OrderName = "Pepsi"},
                new Order{ManagerId = 23, OrderName = "Orbit"},
                new Order{ManagerId = 13, OrderName = "Phone"},
            };
        }

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public List<Order> GetOrders()
        {
            return _orders.Where(o => o.ManagerId == ManagerSingleton.Instance.Manager.ManagerId).ToList();
        }
    }
}

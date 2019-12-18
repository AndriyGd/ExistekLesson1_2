namespace Lesson19.Patterns.SingletonModels
{
    class Order
    {
        public int ManagerId { get; set; }
        public string OrderName { get; set; }   
    }

    class CreateOrder
    {
        public Order CreteNew(string name)
        {
            var ord = new Order{ManagerId = ManagerSingleton.Instance.Manager.ManagerId, OrderName = name};

            return ord;
        }
    }
}

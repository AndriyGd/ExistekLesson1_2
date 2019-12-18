using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson19.Patterns
{
    using SingletonModels;

    class Program
    {
        static void Main(string[] args)
        {
#if false
            Console.WriteLine($"Manager Name: {ManagerSingleton.Instance.Manager.Name}; Manager Id: {ManagerSingleton.Instance.Manager.ManagerId}");

            var creator = new CreateOrder();
            var reporter = new ReportOrder();

            var ord = creator.CreteNew("Bananas");
            reporter.AddOrder(ord);

            var ordersForManager = reporter.GetOrders();

            Console.WriteLine("Orders====");
            foreach (var order in ordersForManager)
            {
                Console.WriteLine($"Order Name: {order.OrderName}; Manager Id: {order.ManagerId}");
            } 
#endif
            var woodenShop = new ToysShop(new WoodenToyFactory());
            var taddyShop = new ToysShop(new TaddyToyFactory());

            woodenShop.Print();
            Console.WriteLine();
            taddyShop.Print();

            Console.ReadLine();
        }
    }

    class ToysShop
    {
        private readonly IToyFactory _factory;

        public Bear Bear { get; set; }
        public Cat Cat { get; set; }

        public ToysShop(IToyFactory factory)
        {
            _factory = factory;

            Bear = _factory.GetBear("Hklpo");
            Cat = _factory.GetCat("Bnmop");
        }

        public void Print()
        {
            Console.WriteLine($"Bear: {Bear.Name}; Type: {Bear.GetType().Name}");
            Console.WriteLine($"Cat: {Cat.Name}; Type: {Cat.GetType().Name}");
        }
    }

    abstract class Animal
    {
        public string Name { get; set; }

        protected Animal(string name)
        {
            Name = name;    
        }
    }

    class Cat : Animal
    {
        public Cat(string name) : base(name)
        {
        }
    }

    class Bear : Animal
    {
        public Bear(string name) : base(name)
        {
        }
    }

    class WoodenCat : Cat
    {
        public WoodenCat(string name) : base(name)
        {
        }
    }

    class WoodenBear : Bear
    {
        public WoodenBear(string name) : base(name)
        {
        }
    }

    class TaddyCat : Cat
    {
        public TaddyCat(string name) : base(name)
        {
        }
    }

    class TaddyBear : Bear
    {
        public TaddyBear(string name) : base(name)
        {
        }
    }

    //Abstract Factory
    interface IToyFactory
    {
        Bear GetBear(string name);
        Cat GetCat(string name);
    }

    //Concrete Factory
    class WoodenToyFactory : IToyFactory
    {
        public Bear GetBear(string name)
        {
            return new WoodenBear(name);
        }

        public Cat GetCat(string name)
        {
            return new WoodenCat(name);
        }
    }

    //Concrete Factory
    class TaddyToyFactory: IToyFactory
    {
        public Bear GetBear(string name)
        {
            return new TaddyBear(name);
        }

        public Cat GetCat(string name)
        {
            return new TaddyCat(name);
        }
    }
}

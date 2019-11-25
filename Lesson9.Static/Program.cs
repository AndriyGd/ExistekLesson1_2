using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using ExtensionClasses;

namespace Lesson9.Static
{
    class Program
    {
        static void Main(string[] args)
        {
#if false
            Console.WriteLine($"Bonus: {Bank.Bonus}");
            var b1 = new Bank { Name = "BND", Balance = 8400 };
            var b2 = new MyBank { Name = "MNV", Balance = 9800, Address = "Nop, 80" };

            b1.PrintBonus();
            b2.PrintBonus();

            Console.WriteLine(b1);
            Console.WriteLine(b2);

            var bonusOfDeposit = b1.SetDeposit(2000);
            Console.WriteLine($"Deposit Profit: {bonusOfDeposit}");

            Console.WriteLine(b1);

            Bank.Bonus = 1.23;

            b1.PrintBonus();
            b2.PrintBonus();

            var creditSum = b2.GetCredit(3000);
            var cr = b1.GetCredit(50000);

            bonusOfDeposit = b2.SetDeposit(2000);
            Console.WriteLine($"Deposit Profit: {bonusOfDeposit}"); 
#endif
#if false
            var items = new List<int>
            {
                45, 67, 898, 357, 45, 787, 248, 89
            };

            var m = items.Max();
            Console.WriteLine($"Max: {m}");

            var ob = new ObservableCollection<int>();

            ob.AddRange(new[] { 56, 78, 25, 78 });

            foreach (var i in ob)
            {
                Console.WriteLine(i);
            }

            var title = "Lesson 9 Static Classes";

            var tmp = title.SplitBySpace(); 
#endif
            var repos = new BaseRepository();
            repos.Connect();
            repos.Disconnect();

            Console.ReadLine();
        }
    }

    class Bank
    {
        public static double Bonus { get; set; }
        public double Balance { get; set; }
        public string Name { get; set; }

        static Bank()
        {
            Bonus = 1.56;
        }

        public virtual double SetDeposit(double sum)
        {
            Console.WriteLine("Grate!");
            Balance += sum;
            return sum * Bonus;
        }

        public double GetCredit(double sum)
        {
            if (CheckCredit(Balance, sum))
            {
                Console.WriteLine($"You credit was confirmed! Sum {sum}");
                Balance -= sum;
                return sum;
            }

            Console.WriteLine("Your sum is more than Bank Balance!\nPlease enter other sum.");
            return 0;
        }

        protected static bool CheckCredit(double balance, double sum)
        {
            return balance - sum > 0;
        }

        public override string ToString()
        {
            return $"Name: {Name}; Balance: {Balance}\n";
        }

        public void PrintBonus()
        {
            Console.WriteLine($"Bonus: {Bonus}");
        }
    }

    class MyBank : Bank
    {
        public string Address { get; set; }

        public MyBank()
        {
            
        }

        protected static bool CheckCredit(double balance, double sum, int a)
        {
            return balance - sum > 0;
        }
    }

    interface ICarFinished
    {
        event EventHandler Finished;
    }

    abstract class Car
    {
        protected List<ICarFinished> Cars;

        protected Car(List<ICarFinished> cars)
        {
            Cars = new List<ICarFinished>(cars);
        }
    }

    class SportCar: Car, ICarFinished
    {
        public event EventHandler Finished;

        public SportCar(List<ICarFinished> cars) : base(cars)
        {
            Subscribe();
        }

        private void Subscribe()
        {
            Cars.ForEach(c =>
            {
                if (c == this) return;

                c.Finished += OtherCarFinished;
            });
        }

        public void Drive()
        {
            //TODO Driving

            OnFinished();
        }

        //Поточний учасник фінішував
        void OnFinished()
        {
            Finished?.Invoke(this, new EventArgs());
        }

        void OtherCarFinished(object sender, EventArgs e)
        {
            //TODO Gama Over. Cancel Driving
        }

    }
}

namespace ExtensionClasses
{
    using System.Collections.ObjectModel;

    public static class SplitEx
    {
        public static string[] SplitBySpace(this string str)
        {
            return str.Split(' ');
        }
    }

    public static class AddRangeEx
    {
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }
    }
}

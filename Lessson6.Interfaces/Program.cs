using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessson6.Interfaces
{
    delegate void PrintHello(string message);

    class Program
    {
        static void Main(string[] args)
        {
#if false
            ILogger lg = new LogXml();
            var worker = new HardWorker(lg);

            Console.Write("Enter a number: ");

            try
            {
                var n = int.Parse(Console.ReadLine());
                worker.Work(n);
            }
            catch (Exception e)
            {
                lg.LogException(e.Message);
            } 
#endif

#if false
            var repos = new ProductRepository();
            var p1 = new ProductItem { SupplierNumber = "00LL45", Sequence = 3 };
            var p2 = new ProductItem { SupplierNumber = "00LH71", Sequence = 1 };
            repos.AddProduct(p1);
            repos.AddProduct(new ProductItem { SupplierNumber = "00LL65", Sequence = 2 });
            repos.AddProduct(p2);
            repos.AddProduct(new ProductItem { SupplierNumber = "00NJ89", Sequence = 4 });

            ChangeSequence(p1, 5);
            ChangeSequence(p2, 9);

            repos.AddProduct(new SoldProductItem(34) { SupplierNumber = "00GN89" });
            repos.AddProduct(new SoldProductItem(67) { SupplierNumber = "00MV89" });
            repos.AddProduct(new SoldProductItem(5) { SupplierNumber = "00NWU9" });
            repos.AddProduct(new SoldProductItem(13) { SupplierNumber = "00NCN9" });

            var allItems = repos.GetItemsBy();
            Console.WriteLine("-----All Items------");
            allItems.ForEach(i => i.PrintInfo());

            Console.WriteLine();
            Console.WriteLine("======Specific Items=========");

            var sold = repos.GetItemsBy<ProductItem>();
            sold.ForEach(i => i.PrintInfo()); 
#endif
            var log = new LogXml();

            PrintHello print = new PrintHello(ShowMessage);

            print("Hello from there");

            print += log.LogInfo;

            print("Main Method. Hello World");

            print -= ShowMessage;
            Console.WriteLine();
            print("Lesson 6");

            Console.ReadLine();
        }

        private static void ShowMessage(string message)
        {
            Console.WriteLine($"Call ShowMessage: {message}");
        }

        private static void ChangeSequence(ISequence item, int newPos)
        {
            Console.WriteLine($"Current Sequence: {item.Sequence}; New Pos: {newPos}");
        }
    }
}

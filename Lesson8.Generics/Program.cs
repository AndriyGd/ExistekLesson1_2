using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8.Generics
{
    class Program
    {
        static void Main(string[] args)
        {
#if false
            var bookRepos = new BookRepository();
            bookRepos.AddItem(new Book { Name = "WPF" });
            bookRepos.AddItem(new Book { Name = "Linux" });
            var prodRepos = new ProductsRepository<Product>();

            prodRepos.AddItem(new Product());
            prodRepos.AddItem(new Product());
            prodRepos.AddItem(new Product());

            bookRepos.PrintAll();
            prodRepos.PrintAll(); 
#endif

#if false
            var hRep = new HumanRepository<IHuman>();
            var HRp = new HumanRepository<Employee>();

            hRep.AddItem(new Employee { Name = "John", Salary = 65657, Age = 28 });
            hRep.AddItem(new Student { Name = "Tom", Age = 19 });

            var h = hRep.SearchHumanBy("Tom");

            Console.WriteLine(h?.Age); 
#endif
#if false
            IRepository<Manager, Human> rp = new HRepository<Manager, Human>();
            IRepository<Human, Developer> rpH = new HRepository<Human, Developer>();

            rpH.Add(new Human());
            rpH.Add(new Developer());
            rp = rpH;

            //rp.Add(new Human());
            rp.Add(new Manager());
            //rp.Add(new Developer());
            var h = rp.Get("HL");

            Console.WriteLine(h.Age); 
#endif


            //foreach (var i in GetNext())
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine();

            var items = GetNext().ToList();

            //foreach (var item in items)
            //{
            //    Console.WriteLine(item);
            //}
            cw
            var it = GetNext();

            Console.WriteLine("JK");

            foreach (var i in it)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }

        static IEnumerable<int> GetNext()
        {
            Console.WriteLine("Start");
            yield return 56;
            Console.WriteLine("Hello");
            yield return 76;
            Console.WriteLine("Lesson");
            yield return 86;
            yield return 96;
            yield return 106;
            yield return 156;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Events
{
    public class Manager
    {
        public Manager(List<Person> persons)
        {
            foreach (var person in persons)
            {
                person.EndWork += OnPersonEndWork;
                person.Working += delegate (object sender, WorkStateEventArgs args)
                {
                    if (!(sender is Person p)) return;

                    Console.WriteLine($"Person: {p.Name}; Working state: {args.State}");
                };
            }
        }

        private void OnPersonEndWork()
        {
            Console.WriteLine("Manager. Good job Person.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12.Reflaection
{
    [UpperCase(IsUpper = true)]
    public class Human
    {
        private readonly List<string> _addresses;

        public string Name { get; set; }
        public int Age { get; set; }

        public Human()
        {
            _addresses = new List<string>();
        }

        public void AddAddress(string address)
        {
            if (_addresses.Contains(address)) return;

            _addresses.Add(address);
        }

        public void PrintAddresses()
        {
            Console.WriteLine("---Addresses---");
            foreach (var address in _addresses)
            {
                Console.WriteLine($"Address: {address}");
            }
        }
    }
}

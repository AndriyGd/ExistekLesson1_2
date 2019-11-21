using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8.Generics
{
    interface IRepository<in TInp, out TOut> where TInp: IHuman where TOut: IHuman
    {
        void Add(TInp item);
        TOut Get(string name);
    }

    class Human: IHuman
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Manager : Human
    {

    }

    class Developer : Human
    {

    }

    class HRepository<TI, TO> : IRepository<TI, TO> where TI: IHuman where TO: IHuman, new ()
    {
        private List<TI> _list;

        public HRepository()
        {
            _list = new List<TI>();
        }

        public void Add(TI item)
        {
            _list.Add(item);
        }

        public TO Get(string name)
        {
            return new TO{Name = name, Age = 29};
        }
    }
}

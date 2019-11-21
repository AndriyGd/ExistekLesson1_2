using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8.Generics
{
    public abstract class BaseRepository <TEntity> where TEntity: class
    {
        protected readonly List<TEntity> Entities;

        protected BaseRepository()
        {
            Entities = new List<TEntity>();
        }

        public void AddItem(TEntity entity)
        {
            Entities.Add(entity);
        }

        public void PrintAll()
        {
            Entities.ForEach(Console.WriteLine);
        }
    }
}

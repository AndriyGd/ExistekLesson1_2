using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8.Generics
{
    public struct MyStruct : IHuman
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class HumanRepository<TEntity> where TEntity: IHuman
    {
        protected readonly List<TEntity> Entities;

        public HumanRepository()
        {
            Entities = new List<TEntity>();
        }

        public void AddItem(TEntity entity)
        {
            Entities.Add(entity);
        }

        public TEntity SearchHumanBy(string name)
        {
            foreach (var entity in Entities)
            {
                if (entity.Name == name) return entity;
            }

            return default(TEntity);
        }
    }
}

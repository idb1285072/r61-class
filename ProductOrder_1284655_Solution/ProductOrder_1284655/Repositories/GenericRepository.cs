using ProductOrder_1284655.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOrder_1284655.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
    {
        List<T> list = new List<T>();
        public IEnumerable<T> GetAll()
        {
            return list;
        }
        public T Get(int id)
        {
            return this.list.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(T entity)
        {
            this.list.Add(entity);
        }
        public void InsertRange(IEnumerable<T> entities)
        {
            this.list.AddRange(entities);
        }
        public void Update(T entity)
        {
            var index = this.list.IndexOf(entity);
            if(index >= 0)
            {
                this.list.RemoveAt(index);
            }
            this.list.Insert(index, entity);
        }
        public void Delete(int id)
        {
            var entity = this.list.FirstOrDefault(x=> x.Id == id);
            if (entity !=null)
            {
                this.list.Remove(entity);
            }
        }

        
    }
}

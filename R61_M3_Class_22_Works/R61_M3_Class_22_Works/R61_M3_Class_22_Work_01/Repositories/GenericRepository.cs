using R61_M3_Class_22_Work_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_22_Work_01.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase, new()
    {
        List<T> entities = new List<T>();
        public IEnumerable<T> GetAll()
        {
            return entities;
        }
        public T GetById(int id)
        {
            return entities.FirstOrDefault(x=> x.Id  == id);
        }
        public void Insert(T entity)
        {
            entities.Add(entity);
        }        
        public void InsertRange(IEnumerable<T> entities)
        {
            this.entities.AddRange(entities);
        }        
        public void Update(T entity)
        {
            int index = entities.IndexOf(entity);
            entities.RemoveAt(index);
            entities.Insert(index, entity);
        }
        public void Delete(int id)
        {
            var o = entities.FirstOrDefault(x => x.Id == id);
            if (o != null) { entities.Remove(o); }
        }

        
    }
}

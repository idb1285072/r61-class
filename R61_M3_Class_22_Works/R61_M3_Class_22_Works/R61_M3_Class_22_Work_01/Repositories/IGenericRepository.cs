using R61_M3_Class_22_Work_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_22_Work_01.Repositories
{
    public interface IGenericRepository<T> where T : EntityBase, new()
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void InsertRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(int id);

    }
}

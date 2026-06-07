using ProductOrder_1284655.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductOrder_1284655.Repositories
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Insert(T entity);
        void InsertRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(int id);
    }
}

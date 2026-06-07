using ProductOrder_1284655.Model;
using ProductOrder_1284655.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOrder_1284655.Factories
{
    public class GenericRepositoryFactory : IGenericRepositoryFactory
    {
        public IGenericRepository<T> GetRepository<T>() where T : class, IEntity, new()
        {
            return new GenericRepository<T>();
        }

        
    }
}

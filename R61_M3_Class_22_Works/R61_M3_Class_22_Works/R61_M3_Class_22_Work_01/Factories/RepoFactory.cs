using R61_M3_Class_22_Work_01.Models;
using R61_M3_Class_22_Work_01.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_22_Work_01.Factories
{
    public class RepoFactory : IRepoFactory
    {
        public IGenericRepository<T> GetRepo<T>() where T : EntityBase, new()
        {
            return new GenericRepository<T>();
        }
    }
}

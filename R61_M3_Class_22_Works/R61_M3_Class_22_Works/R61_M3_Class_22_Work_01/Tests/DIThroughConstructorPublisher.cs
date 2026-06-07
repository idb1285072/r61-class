using R61_M3_Class_22_Work_01.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R61_M3_Class_22_Work_01.Models;

namespace R61_M3_Class_22_Work_01.Tests
{
    public class DIThroughConstructorPublisher
    {
        IGenericRepository<Publisher> repo;
        public DIThroughConstructorPublisher(IGenericRepository<Publisher> repo)
        {
            this.repo = repo;
        }
        public void Run()
        {

        }
    }
}

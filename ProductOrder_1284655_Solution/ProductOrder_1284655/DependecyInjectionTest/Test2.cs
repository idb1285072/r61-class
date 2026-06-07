using ProductOrder_1284655.Model;
using ProductOrder_1284655.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOrder_1284655.DependecyInjectionTest
{
    public class Test2
    {
        IGenericRepository<DebitCard> repository;
        public Test2(IGenericRepository<DebitCard> repository)
        {
            this.repository = repository;
        }
        public void RunTest()
        {
            Console.WriteLine("Data insert");
            this.repository.Insert(new DebitCard(1, "Tarikul Islam", new DateTime(2024,6, 1), 2000.00M));
            this.repository.InsertRange(new DebitCard[]
            {
                new DebitCard{ Id=2, HolderName="Hasib Mahmud", IssueDate=new DateTime(2024, 3, 1),CurrentBalance= 2000.00M},
                new DebitCard{ Id=3, HolderName="Sajib", IssueDate=new DateTime(2024, 3, 1),CurrentBalance= 3000.00M}
            });
            Console.WriteLine("Get all");
            this.repository.GetAll()
                .ToList()
                .ForEach(x => Console.WriteLine(x));
            Console.WriteLine("Get one entity");
            var dc = this.repository.Get(2);
            Console.WriteLine(dc.ToString());
            Console.WriteLine("Update");
            dc.CurrentBalance -= 500;
            this.repository.GetAll()
                .ToList()
                .ForEach(x => Console.WriteLine(x));
            Console.WriteLine("Delete");
            this.repository.Delete(2);
            this.repository.GetAll()
                .ToList()
                .ForEach(x => Console.WriteLine(x));

        }
    }
}

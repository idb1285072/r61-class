using ProductOrder_1284655.DependecyInjectionTest;
using ProductOrder_1284655.Factories;
using ProductOrder_1284655.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOrder_1284655
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test 1");
            GenericRepositoryFactory factory = new GenericRepositoryFactory();
            Test1 t1 = new Test1(factory.GetRepository<BankAccount>());
            t1.RunTest();
            Console.WriteLine("Test 2");
            Test2 t2 = new Test2(factory.GetRepository<DebitCard>());
            t2.RunTest();
            Console.ReadLine();
        }
    }
}

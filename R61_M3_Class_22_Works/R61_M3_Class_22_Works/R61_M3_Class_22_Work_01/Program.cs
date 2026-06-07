using R61_M3_Class_22_Work_01.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R61_M3_Class_22_Work_01.Models;
using R61_M3_Class_22_Work_01.Tests;
using R61_M3_Class_22_Work_01.Factories;

namespace R61_M3_Class_22_Work_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepoFactory factory = new RepoFactory();
            DIThroughConstructorBook test1 = new DIThroughConstructorBook(factory.GetRepo<Book>());
            test1.Run();
            Console.ReadLine();
        }
    }
}

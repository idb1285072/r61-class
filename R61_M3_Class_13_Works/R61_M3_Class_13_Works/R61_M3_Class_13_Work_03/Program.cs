using R61_M3_Class_13_Work_03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_13_Work_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InfoPrinter<Book> p1 = new InfoPrinter<Book>();
            Book b = new Book { Id = 1, Title = "C# Step By Step", Price = 1080.00M };
            p1.Info(b);
            InfoPrinter<Author> p2 = new InfoPrinter<Author>();
            Author a = new Author { Id = 1, Name = "A. B", Email = "ab@abc.com" };
            p2.Info(a);
            Console.ReadLine();
        }
    }
}

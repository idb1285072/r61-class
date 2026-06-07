using R61_M3_Class_09_Work_03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_09_Work_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box b1 = new Box() { Length = 9.5, Width = 7.5 };
           
            Console.WriteLine($"Area: {b1.GetArea()}, Circum={b1.Circumfrence()}");
            Box b2 = new Box(9.5, 8.5);
            b2.Length = 11.5;
            Console.WriteLine($"Area: {b2.GetArea()}, Circum={b2.Circumfrence()}");
            Perosn p = new Perosn { FirstName = "Aftab", LastName = "Hossain" };
            
            Console.WriteLine(p.FullName );
            Console.ReadLine();
        }
    }
}

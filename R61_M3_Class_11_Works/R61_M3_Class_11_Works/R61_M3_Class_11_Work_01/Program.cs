using R61_M3_Class_11_Work_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_11_Work_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle c = new Circle { Radius = 4.5 };
            Console.WriteLine(c);
            Console.WriteLine($"Area={c.Area()}");
            Rectangle r = new Rectangle { Length = 7, Width = 5 };
            Console.WriteLine(r);
            Console.WriteLine($"Area={r.Area()}");
            Console.ReadLine();
        }
    }
}

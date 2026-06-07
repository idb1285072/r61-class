using R61_M3_Class_10_Work_02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_10_Work_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle c = new Circle { Radius = 5.5 };
            Print(c);
            Rectangle r = new Rectangle { Length = 5.5, Width = 3.5 };
            Print(r);
            Triangle t = new Triangle { A=3, B=4, C=5 };
            Print(t);
            Console.ReadLine();
        }
        static void Print(Shape s)
        {
            Console.WriteLine($"Area={s.Area():0.00}");
        }
    }
}

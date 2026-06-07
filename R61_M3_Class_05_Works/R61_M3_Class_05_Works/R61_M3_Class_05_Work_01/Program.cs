using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_05_Work_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 15;
            int m = n++;
            Console.WriteLine(m);
            Console.WriteLine(n);
            int x = 15;
            int y = ++x;
            Console.WriteLine(y);
            Console.WriteLine(x);
            Console.WriteLine();
            Console.WriteLine("Post increment");
            int a = 15;
            Console.WriteLine($"a={a++}");
            //Console.WriteLine($"a={a}");
            Console.WriteLine("Pre increment");
            int b = 15;
            Console.WriteLine($"b={++b}");
            //Console.WriteLine($"b={b}");
            Console.ReadLine();
        }//Main
    }//Program
}

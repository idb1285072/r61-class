using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_02_Work_03
{
    internal class Program
    {
        static void Main()
        {
            /*
             * Operators
             * */
            int n = 14, m = 10;
            Console.WriteLine($"{n}+{m}={n + m}");
            Console.WriteLine($"{n}-{m}={n - m}");
            Console.WriteLine($"{n}*{m}={n * m}");
            Console.WriteLine($"{n}/{m}={(double)n / m}");
            Console.WriteLine($"{n}%{m}={n % m}");
            Console.ReadLine();
        }//Main
    }
}

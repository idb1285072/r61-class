using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_25_Work_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0b0_00000000_00000000_00000000_10011011;
            n |= (1 << 5);
            Console.WriteLine(Convert.ToString(n, 10));
            Console.WriteLine(Convert.ToString(n, 2));
            Console.ReadLine();

        }
    }
}

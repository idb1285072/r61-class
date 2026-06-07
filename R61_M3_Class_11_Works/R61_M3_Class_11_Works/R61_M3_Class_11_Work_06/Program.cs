using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_11_Work_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[][] cities = new string[][]{
                new string[]{ "Dhaka", "Rajshahi", "Sylhet", "Chittgong"},
                new string[]{ "Delhi", "Calcata", "Bombay"},
                new string[]{ "Islamabad", "Lahore"}
            };
            foreach (string[] c in cities)
            {
                foreach (string s in c)
                {
                    Console.Write($"{s}\t");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}

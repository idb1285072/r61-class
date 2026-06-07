using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_11_Work_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] cities = { "Dhaka", "Chittagong", "Sylhet", "Rajshahi" };
            for (int i = cities.Length-1; i >=0; i--)
            {
                Console.WriteLine(cities[i]);
            }
            Console.WriteLine();
            foreach (string c in cities) 
            { 
                Console.WriteLine(c);
            }
            Console.WriteLine();
            var data = new[] { 31.6, 21.1, 17.4 };
            for (int i = 0;i < data.Length;i++)
            {
                data[i] = data[i] * 1.1;
                Console.WriteLine(data[i]);
            }
            Console.WriteLine();
            foreach (var d in data) 
            {
                Console.WriteLine($"{d}");
            }
            Console.ReadLine();
        }
    }
}

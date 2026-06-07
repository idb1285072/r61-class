using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_03_Work_04
{
    internal class Program
    {
        static void Main()
        {
            if (DateTime.Now.Hour >= 12)
            {
                Console.WriteLine("Goood day");
                Console.WriteLine("Happy journey");
            }
            else
            {
                Console.WriteLine("Good Morning");
                Console.WriteLine("Happy programming");
            }
            Console.WriteLine();
            Console.Write("Enter a whole number: ");
            int n= int.Parse(Console.ReadLine());
            if (n % 2 == 0)
            {
                Console.WriteLine($"{n} is even");
            }
            else
            {
                Console.WriteLine($"{n} is odd");
            }
            Console.ReadLine();
        }//Main
    }
}

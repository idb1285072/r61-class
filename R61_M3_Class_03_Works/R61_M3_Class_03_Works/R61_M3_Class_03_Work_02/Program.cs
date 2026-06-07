using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_03_Work_02
{
    internal class Program
    {
        static void Main()
        {
            int luckyNumber = GetANumber();
            Console.WriteLine($"My Lucky number: {luckyNumber}");
            int anotherNumber = GetANumber(50, 100); //GetANumber(max:100, min:50);
            Console.WriteLine($"Random number:{anotherNumber}");
            Console.ReadLine();
        }//Main
        static int GetANumber(int min = 1)
        {
            Random rnd = new Random();
            return rnd.Next(min, min + 9);
        }
        static int GetANumber(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }
    }//Program
}

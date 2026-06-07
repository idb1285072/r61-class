using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_01_Work_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What is your name: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Thank you \"{name}\"");
            Console.Write("What is you age: ");
            int age = int.Parse( Console.ReadLine() );
            Console.WriteLine($"You will be {age+1} next year");
            Console.ReadLine();
        }//Main
    }//Program
}//namespace

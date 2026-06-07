using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_15_Work_01
{
    public delegate void del1(string s);
    public delegate long del2(int n);
   
    internal class Program
    {
        static void Main()
        {
            del1 d1 = new del1(Print);
            d1 += PrintReverse;
            // d1 -= PrintReverse;
            d1 += s =>
            {
                Console.WriteLine(s);
                Console.WriteLine(s);
            };
            d1("A message");
            del2 d2 = new del2(n=> n*n);
            Console.WriteLine(d2(5));
            Console.ReadLine(); 
        }
        static void Print(string msg)
        {
            Console.WriteLine(msg);
        }
        static void PrintReverse(string msg)
        {
            for (int i = msg.Length - 1; i >= 0; i--)
            {
                Console.Write(msg[i]);
            }
            Console.WriteLine();
        }
    }
}

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
            
            for(int n = 1; ; )
            {
                
                if (n == 3) { break; }
                n++;
            }
            for (int n = 1; n<=10;n++)
            {
                
                if (n == 5) { continue; }
                Console.Write($"{n}\t");

            }
            Console.WriteLine();
            Console.ReadLine();
        }//Main
    }
}

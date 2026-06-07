using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_03_Work_03
{
    internal class Program
    {
        static  string globalVar = "R61";
        static void Main()
        {
           string localVar = "ESAD-CS";
            
            {
                int scopedVar = 14;

                {
                    Console.WriteLine(globalVar);
                    Console.WriteLine(localVar);
                    Console.WriteLine(scopedVar);
                    Console.WriteLine();
                }
                
            }
            Console.WriteLine(globalVar);
            Console.WriteLine(localVar);


            Console.ReadLine();
        }//Main

    }//Program
}

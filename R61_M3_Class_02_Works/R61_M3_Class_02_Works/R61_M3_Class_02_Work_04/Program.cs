using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_02_Work_04
{
    internal class Program
    {
        static void Main()
        {
            Print("Methods");
            Print("Press <Enter> to exit");
            Pause();
        }//Main
        static void Pause()
        {
            Console.ReadLine();
        }
        static void Print(string text)
        {
            Console.WriteLine(text);
            return;
        }

    }//Program
}

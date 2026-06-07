using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_02_Work_02
{
    internal class Program
    {
        static void Main()
        {
            /*
             * Data types & Literals
             * */
            short s = 15;
            int n = 10;
            long l = 19L;
            Console.WriteLine("s="+s + " n="+n + " l="+l.ToString("0.00"));
            Console.WriteLine("s={0}, n={1}, l={2:0.00}", s, n, l);
            Console.WriteLine($"s={s}, n={n}, l={l:0.00}");
            Console.WriteLine();
            //
            float f = 1.99F;
            double d = 2.99;
            decimal m = 789.975M;
            Console.WriteLine($"f={f}, d={d}, m={m:c}");
            Console.WriteLine();
            //
            string str = "ESAD";
            char c = 'E';
            Console.WriteLine(str);
            Console.WriteLine(c);
            Console.WriteLine();
            //
            bool b = 2>1;
            Console.WriteLine(b);
            //
            DateTime dt = DateTime.Now;
            Console.WriteLine($"{dt:yyyy-MM-dd hh:mm tt}");
            Console.ReadKey();
        }//Main
    }//Program
}//namespace

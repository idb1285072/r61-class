using System;

namespace R61_M3_Class_03_Work_01
{
    internal class Program
    {
        static void Main()
        {
            int x = 1789, y = 76589;
            int total = Sum(x, y);
            Console.WriteLine($"{x}+{y}={total}");
            Console.WriteLine($"3+5={Sum(3, 5)}");
            Console.WriteLine($"3+5+7={Sum(Sum(3, 5), 7)}");
            Console.WriteLine($"22-11={Subtract(22, 1)}");
            Console.ReadLine();
        }//Main
        
        static int Sum(int a, int b)
        {
            //int r = a + b;
            //return r;
            return a + b;
        }
        static int Subtract(int a, int b)
        {
            //int r = a + b;
            //return r;
            return a - b;
        }
        
    }//Program
    
}

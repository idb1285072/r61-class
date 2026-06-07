using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_13_Work_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ValueContainer<string> value2 = new ValueContainer<string>() { Value = "R61" };
            ValueContainer<double> value3 = new ValueContainer<double>() { Value = 1.0 };
            double x = .9, y = .8;
            Swap<double>(ref x, ref y);
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.ReadLine();
        }//Main
        static void Swap<T>(ref T a, ref T b) 
        { 
            T tmp = a;
            a = b;
            b=tmp;
        }
    }//program
    public class ValueContainer<T>
    {
        public T Value { get; set; }
    }
}

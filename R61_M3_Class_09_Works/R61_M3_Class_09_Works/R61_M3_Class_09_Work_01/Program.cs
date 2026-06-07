using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_09_Work_01
{
    //public internal protected private
    internal class Program
    {
        static void Main(string[] args)
        {
            A obj = new A();
            obj.F = 20;
            Console.WriteLine(obj.GetF());
            Console.ReadLine();
        }
    }
    public class A
    {
        public int F;
        public int GetF()
        {
            return ++F;
        }
    }
}


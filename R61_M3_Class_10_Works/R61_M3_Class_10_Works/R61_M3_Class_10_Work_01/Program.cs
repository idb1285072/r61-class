using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_10_Work_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            B o1 = new B("rrrr", 61);
            o1.M4();
            Console.ReadLine();
            
        }
    }//Program
    public class A 
    {
        public A(string s)
        {
            Console.WriteLine($"Creating A with {s}");
        }
        public void M1() {
            Console.WriteLine("M1");
            this.M3();
        }
        protected void M2() {
            Console.WriteLine("M2");
            
        }
        private void M3() {
            Console.WriteLine("M3");
        }
    }
    public class B : A
    {
        public B(string s, int n):base(s)
        {
            Console.WriteLine($"Creating B with {n}");
        }
        public void M4()
        {
            Console.WriteLine("M4");
            base.M1();
        }
    }
}

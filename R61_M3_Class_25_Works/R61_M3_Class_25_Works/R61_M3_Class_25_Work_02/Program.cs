using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_25_Work_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DivisisbleFinder finder = new DivisisbleFinder();
            finder.foundDivisible += Finder_foundDivisible;
            finder.FindDivisible(100, 19);
            Console.ReadLine();
        }

        private static void Finder_foundDivisible(object sender, DivisbleFoundArgs e)
        {
            Console.WriteLine($"{e.Divisible} is divisble by {e.Divisor}");
        }
    }
    public class DivisbleFoundArgs 
    {
        public int Divisible { get; set; }
        public int Divisor { get; set; }
    }
    public delegate void DivisbleFound(object sender, DivisbleFoundArgs e);
    public class DivisisbleFinder
    {
        public event DivisbleFound foundDivisible;
        public void FindDivisible(int number, int divisor)
        {
            
            for (int i = 1; i <= number; i++)
            {
                if (i % divisor == 0)
                {
                    if(this.foundDivisible != null)
                    {
                        this.foundDivisible(this, new DivisbleFoundArgs { Divisible=i, Divisor=divisor});
                    }
                }
            }
        }
    }
}

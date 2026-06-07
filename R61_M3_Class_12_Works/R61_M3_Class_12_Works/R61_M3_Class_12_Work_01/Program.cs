using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_12_Work_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = new int[] { 1, 2, 3, 4, 5 };            
            var r=SumUp(data);
            Console.WriteLine(r);
            var r1 = SumUpParam(1, 2, 3);
            Console.WriteLine(r1);
            /////////////////////////
            var result =SumUpM(.69, .88, .66, .92);
           // Console.WriteLine(result.GetType());
            Console.WriteLine($"Sum={result.sum}, Avg={result.avg}, Highest={result.max}, Lowest={result.min}");
            Console.ReadLine();
        }//Main
        static long SumUp(int[] numbers)
        {
            long sum = numbers.Sum();
            return sum;
        }
        static long SumUpParam(params int[] numbers)
        {
            long sum = numbers.Sum();
            return sum;
        }
        static (double sum, double avg, double max, double min) SumUpM(params double[] numbers)
        {
            double sum = numbers.Sum();
            double avg = numbers.Average();
            return (sum, avg, numbers.Max(), numbers.Min());
        }
    }
}

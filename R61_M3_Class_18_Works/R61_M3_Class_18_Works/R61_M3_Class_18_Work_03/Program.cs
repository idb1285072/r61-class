using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_18_Work_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] values = { 45, 20, 40, 12 };
            
            for (int i = 0; i < values.Length; i++)
            {
                RunSum(values[i]);
              
            }
            
            Console.WriteLine("Done");
            Console.ReadLine();
        }
        static void RunSum(int n)
        {

          
                SumUp(n).ContinueWith(t =>
                {
                    Console.WriteLine($"1+2+3+...+{n}={t.Result}");
                });
           
            
        }
        static Task<long> SumUp(int n)
        {
            Console.WriteLine($"Summing up to {n}");
            long sum = 0;
            return Task<long>.Run(() =>
            {
                for (int i = 1; i <= n; i++)
                {
                    sum += i;
                    Task.Delay(100).Wait();
                }
                return sum;
            });
            
        }
    }
}

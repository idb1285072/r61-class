using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_18_Work_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] values = { 15, 10, 17, 12 };           
            for (int i = 0; i < values.Length; i++)
            {
                RunSumAsync(values[i]);
               
            }            
            Console.WriteLine("All task Started");
            Console.ReadLine();
        }
        static async void RunSumAsync(int n)
        {
            long r = await SumUpAsync(n);
            Console.WriteLine($"1+2+3+...+{n}={r}");
        }
        static async  Task<long> SumUpAsync(int n)
        {
            Console.WriteLine($"Summing up to {n}");
            long sum = 0;
            var start = DateTime.Now;//1
            await Task<long>.Run(async () =>
            {
                for (int i = 1; i <= n; i++)
                {
                    sum += i;
                    await Task.Delay(1000);
                }
            });
            var end = DateTime.Now;//2
            Console.WriteLine($"Processing time: {(end - start).TotalMilliseconds}");//3
            return sum;

        }
    }
}

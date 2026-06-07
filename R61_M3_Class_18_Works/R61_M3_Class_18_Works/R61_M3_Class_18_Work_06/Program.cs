using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_18_Work_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 12, 7, 8, 11 };
            List<Task> tasks = new List<Task>();
            foreach (int number in numbers)
            {
                var t = CallFactorialAsync(number);
                tasks.Add(t);
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("All done");
            Console.ReadLine();
        }
        static async Task CallFactorialAsync(int n)
        {
            long fact = await FactorialAsync(n);
            Console.WriteLine($"{n}!={fact}");
        }
        static async Task<long> FactorialAsync(int n)
        {
            Console.WriteLine($"Processing {n}!");
            long fact = 1;
           var start = DateTime.Now;//1
            await Task.Run(async () => {
                for (int i = n; i >= 1; i--) { 
                    fact *= i;
                    await Task.Delay(100);
                }
            });
            var end = DateTime.Now;//2
            Console.WriteLine($"Processing time: {(end - start).TotalMilliseconds}");//3
            return fact;
            
        }
    }
}

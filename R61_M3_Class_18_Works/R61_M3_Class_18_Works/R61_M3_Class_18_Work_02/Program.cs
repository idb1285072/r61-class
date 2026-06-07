using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace R61_M3_Class_18_Work_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task t1 = Task.Run(() => {
                for (int i = 1; i <= 50; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
                    Task.Delay(100).Wait();
                    
                }
            });
            Task t2 = Task.Run(() => {
                for (int i = 1; i <= 50; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
                    Task.Delay(100).Wait();

                }
            });
            //Task.WaitAll(t1, t2);
            for (int i = 1; i <= 50; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
                Task.Delay(100).Wait();
            }
            Console.ReadLine();
        }
    }
}

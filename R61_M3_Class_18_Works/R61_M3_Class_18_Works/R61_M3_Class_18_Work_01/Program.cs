using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace R61_M3_Class_18_Work_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Thread.CurrentThread.Name = "TM";
            Console.WriteLine("Starting");
            
            Thread t1 = new Thread(Run);
            //t.Name = "T1";
            t1.Start();
            Thread t2 = new Thread(Run);
            //t.Name = "T1";
            t2.Start();
            
            t2.Join();
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
                Thread.Sleep(100);
            }
            Console.ReadLine();
        }
        static void Run()
        {
            for (int i = 1; i <= 100; i++) 
            { 
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
                Thread.Sleep(100);
                if (i == 10 & Thread.CurrentThread.ManagedThreadId==4) Thread.CurrentThread.Abort();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_17_Work_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("SQL");
            stack.Push("C#");
            stack.Push("HTML");
            stack.Push("CSS");
            stack.Push("JavScript");
            stack.Push("jQuery");
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
            Console.WriteLine();
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("jQuery");
            queue.Enqueue("JavaScript");
            queue.Enqueue("CSS");
            queue.Enqueue("HTML");
            queue.Enqueue("C#");
            queue.Enqueue("SQL");
            while (queue.Count > 0)
            {
                Console.WriteLine($"{queue.Dequeue()}");
            }
            Console.ReadLine();
        }
    }
}

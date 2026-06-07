using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_15_Work_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
           
            list.Add(20);
            list.Add(30);
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);
            list.AddRange(new int[] {10, 40});
            list.Add(50);
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            list.Remove(10);
            list.RemoveAt(1);
            list.ForEach(n=>  Console.WriteLine(n));
            Console.WriteLine();
            List<string> names = new List<string>
            {
                "Fakquir", "Poor", "Miskin", "Nimno"
            };
            names.ForEach(s=> Console.WriteLine(s));
            Console.ReadLine();
        }
    }
}

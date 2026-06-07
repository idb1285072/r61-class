using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_11_Work_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[3];
            numbers[0] = 11;
            numbers[1] = 20;
            numbers[2] = 3;
            for (int i = 0; i < numbers.Length; i++) 
            { 
                Console.WriteLine(numbers[i]);
            }
            Console.WriteLine();
            double[] doubles = { 12.33, 7.55, 11.70};
            for (int i = 0; i < doubles.Length; i++)
            {
                Console.WriteLine(doubles[i]);
            }
            Console.ReadLine();
        }
    }
}

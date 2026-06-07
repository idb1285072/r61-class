using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_11_Work_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] numbers = new int[3, 4];
            numbers[0, 0] = 01;
            numbers[0, 1] = 1;
            numbers[0, 2] = 1;
            numbers[0, 3] = 1;

            numbers[1, 0] = 2;
            numbers[1, 1] = 2;
            numbers[1, 2] = 2;
            numbers[1, 3] = 2;

            numbers[2, 0] = 3;
            numbers[2, 1] = 3;
            numbers[2, 2] = 3;
            numbers[2, 3] = 3;
            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    Console.Write($"{numbers[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            int[,] tables = new int[10, 10];
            for (int i = 0; i < tables.GetLength(0); i++)
            {
                for (int j = 0; j < tables.GetLength(1); j++)
                {
                    tables[i, j] = (i + 1) * (j + 1);
                }
                
            }
            for (int i = 0; i < tables.GetLength(0); i++)
            {
                for (int j = 0; j < tables.GetLength(1); j++)
                {
                    Console.Write($"{tables[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_15_Work_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var marks = new[]
            {
                new  {Name="S1", Marks=39.5},
                new  {Name="S2", Marks=51.5},
                new  {Name="S3", Marks=85.0},
                new  {Name="S4", Marks=91.0},
                new  {Name="S5", Marks=45.5}
            };
            marks
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Name} Mark: {x.Marks}"));
            Console.WriteLine("Marks over 40");           
            Console.WriteLine("Foreach loop");
            foreach(var m in marks)
            {
                if (m.Marks > 40)
                {
                    Console.WriteLine($"{m.Name} Mark: {m.Marks}");
                }
            }
            Console.WriteLine("Query syntax");
            (from m in marks
             where m.Marks>40
            select m).ToList()
            .ForEach(x => Console.WriteLine($"{x.Name} Mark: {x.Marks}"));
            Console.WriteLine("Extension methods");
            marks.ToList()
                .Where(m=> m.Marks> 40)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Name} Mark: {x.Marks}"));
            
            Console.ReadLine();
        }
    }
}

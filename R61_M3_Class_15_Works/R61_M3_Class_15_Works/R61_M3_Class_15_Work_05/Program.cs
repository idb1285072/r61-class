using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_15_Work_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Production> riceProducts = new List<Production>
            {
                new Production{ District="Dhaka", TotalProductionInMetricTon=300000},
                new Production{ District="Mymensing", TotalProductionInMetricTon=750000},
                new Production{ District="Barishal", TotalProductionInMetricTon=940000},
                new Production{ District="Rajshai", TotalProductionInMetricTon=1080000},
                new Production{ District="Dhaka", TotalProductionInMetricTon=430000},
                new Production{ District="Comilla", TotalProductionInMetricTon=680000}
            };

            //Print list
            //Sort on Total production & print
            (from p in riceProducts
             orderby p.TotalProductionInMetricTon descending
             select p)
             .ToList()
             .ForEach(p => Console.WriteLine($"{p.District}-{p.TotalProductionInMetricTon}m ton"));
            Console.WriteLine();
            riceProducts.OrderByDescending(p=> p.TotalProductionInMetricTon)
                .ToList()
                .ForEach(p => Console.WriteLine($"{p.District}-{p.TotalProductionInMetricTon}m ton"));
            //int h = (from p in riceProducts
            // orderby p.TotalProductionInMetricTon descending

            //int h = (from p in riceProducts
            //         select p.TotalProductionInMetricTon)
            //         .Max();
            int h = riceProducts.Max(p => p.TotalProductionInMetricTon);
            int sum = riceProducts.Sum(p => p.TotalProductionInMetricTon);
            //Highest Product, Lowest production, sum, Average

            Console.ReadLine();
        }
    }
    public class Production
    {
        public string District { get; set; }
        public int TotalProductionInMetricTon { get; set; }
    }
}

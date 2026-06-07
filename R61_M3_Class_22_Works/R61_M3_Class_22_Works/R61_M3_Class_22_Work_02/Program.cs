using R61_M3_Class_22_Work_02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_22_Work_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NorthwindDbContext db = new NorthwindDbContext();
            (from c in db.Customers
            select new { c.CustomerID, c.CompanyName, c.Country })
            .ToList()
            .ForEach(c=> Console.WriteLine($"{c.CustomerID}, {c.CompanyName}, {c.Country}"));

            //var r= db.Regions.First(x => x.RegionID == 5);
            //db.SaveChanges();
            //r.RegionDescription = "NorthEast";
            //db.SaveChanges();
            //db.Regions.Remove(r);
            //db.SaveChanges();
            var alfki = db.Customers.First(x => x.CustomerID == "ALFKI");
            foreach (var o in alfki.Orders)
            {
                Console.WriteLine($"{o.OrderID}-{o.OrderDate:yyyy-MM-dd}");
            }
            Console.ReadLine();
        }
    }
}

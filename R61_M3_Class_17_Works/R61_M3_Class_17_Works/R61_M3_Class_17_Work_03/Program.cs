using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_17_Work_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                ["Bangladesh"] = "Dhaka",
                ["India"] = "Delhi"
            };
            dic["Nepal"] = "Kathmundu";
            dic.Add("Bhutan", "Thimphu");
            foreach (KeyValuePair<string, string> item in dic) {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            Console.WriteLine();
            foreach (string k in dic.Keys) 
            { 
                Console.WriteLine($"{k}: {dic[k]}");
            }
            Console.WriteLine();
            Dictionary<string, DateTime> holidays = new Dictionary<string, DateTime>
            {
                ["Martyr's day"] = new DateTime(2024, 2, 21),
                ["Shab-e-Barat"] = new DateTime(2024, 2, 26)
            };
            holidays.Add("Independance Day", new DateTime(2024, 3, 26));
            holidays["Jumatul Bida"] = new DateTime(2024, 4, 5);
            foreach (var k in holidays.Keys)
            {
                Console.WriteLine($"{k}: {holidays[k]: dd-MM-yyyy}");
            }
            Console.ReadLine();
        }
    }
}

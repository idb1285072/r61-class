using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //1
    public enum Course { ESAD=1, NT, DDD, GAVE, J2EE, WFPI}
    public enum ProductType { Essentials=1, Luxury, Exotic}
    internal class Program
    {
        static void Main(string[] args)
        {
            //3
            Console.WriteLine(Course.ESAD);
            Course c = Course.DDD;
            c++;
            Console.WriteLine(c);
            Console.WriteLine($"Vat={Vat(750, ProductType.Luxury)}");
            Console.WriteLine($"Vat={Vat(750, ProductType.Exotic)}");
            Console.Write("Enter price amount: ");
            decimal amt = decimal.Parse( Console.ReadLine() );
            Console.Write("Type [Essentials, Luxury, Exotic]: ");
            ProductType t = (ProductType)Enum.Parse(typeof(ProductType), Console.ReadLine());
            Console.WriteLine($"Vat={Vat(amt, t)}");
            Console.ReadLine();
        }
        //
        public static decimal Vat(decimal amount, ProductType t)
        {
            if(t == ProductType.Essentials)
            {
                return 0;
            }
            else if(t == ProductType.Luxury)
            {
                return amount*.025M;
            }
            else
            {
                return amount * .05M;
            }
        }

    }
}

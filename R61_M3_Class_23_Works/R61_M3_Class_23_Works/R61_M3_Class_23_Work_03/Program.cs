using R61_M3_Class_23_Work_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_23_Work_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PromoProduct p = new PromoProduct(1, "Lexus Biscuit", 90.00M, .10M, 5);
            Offer<PromoProduct> offer = new Offer<PromoProduct>(p);
            Console.WriteLine($"{p.Name} @ {p.StandardPrice}");
            Console.WriteLine("Exiciting offer");
            Console.WriteLine($"{offer.OriginalAmmount} for {p.MinimumOrderQuntity}");
            Console.WriteLine($"Cuurently {offer.CurrentAmmount}, you save {offer.TotalSave}");
            Console.ReadLine();
            
        }
    }
}

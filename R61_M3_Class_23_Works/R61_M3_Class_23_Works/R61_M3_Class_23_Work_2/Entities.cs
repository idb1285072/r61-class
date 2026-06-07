using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_23_Work_2
{
    public class Product
    {
        public Product() { }
        public Product(int id, string name, decimal standardPrice) 
        { 
            this.Id = id;
            this.Name = name;
            this.StandardPrice = standardPrice;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal StandardPrice { get; set; }
    }
    public class PromoProduct : Product
    {
       public PromoProduct(int id, string name, decimal standardPrice, decimal discount, int minOrderQty): base(id, name, standardPrice) 
        { 
            this.Discount = discount;
            this.MinimumOrderQuntity = minOrderQty;
        }
        public decimal Discount { get; private set; } = .05M;
        public int MinimumOrderQuntity { get; private set; }
    }

}

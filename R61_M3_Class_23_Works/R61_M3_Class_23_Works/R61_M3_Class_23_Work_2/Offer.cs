using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_23_Work_2
{
    public class Offer<T> : IOffer<T> where T : PromoProduct
    {
        T obj;
        public Offer(T obj)
        {
            this.obj = obj;
        }
        public decimal CurrentAmmount { get => this.OriginalAmmount* (1-this.obj.Discount); }
        public decimal OriginalAmmount { get => this.obj.StandardPrice*this.obj.MinimumOrderQuntity;  }
        public decimal TotalSave { get => this.OriginalAmmount - this.CurrentAmmount;  }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_23_Work_2
{
    public interface IOffer<T> where T : PromoProduct
    {
        decimal CurrentAmmount { get;  }
        decimal OriginalAmmount { get; }
        decimal TotalSave { get;  }
    }
}

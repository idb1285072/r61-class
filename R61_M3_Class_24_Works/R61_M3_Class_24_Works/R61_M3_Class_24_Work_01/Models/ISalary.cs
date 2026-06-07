using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_24_Work_01.Models
{
    public interface ISalary
    {
        decimal CalculateSalary<T>(T worker) where T: Worker;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_21_Work_02.Models
{
    public interface IGenericBehavior<T>
    {
        string GetBahivior<T1>(T1 obj);
    }
}

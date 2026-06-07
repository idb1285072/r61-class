using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_14_Work_01.Models.Generics
{
    public interface IVehiclInfo
    {
        string GetInfo<T>(T entity) where T : Vehicle, new();
    }
}

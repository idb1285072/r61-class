using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_21_Work_02.Models
{
    public interface ISpecificBehavior <T>
    {
        string GetBehavior<T1>(T1 obj) where T1 : Animal;
    }
}

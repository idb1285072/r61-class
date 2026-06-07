using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_13_Work_03.Models
{
    public class InfoPrinter<T> : IInfo<T> where T : EntityBase, new()
    {
        public void Info(T o)
        {
            Console.WriteLine(o.Info());
        }
    }
}

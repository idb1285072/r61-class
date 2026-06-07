using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_13_Work_03.Models
{
    public abstract class EntityBase
    {
        public abstract int Id { get; set; }
        public abstract string Info();
    }
}

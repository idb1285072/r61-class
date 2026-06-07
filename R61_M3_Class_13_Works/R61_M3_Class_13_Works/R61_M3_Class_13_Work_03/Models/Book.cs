using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_13_Work_03.Models
{
    public class Book : EntityBase
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public override int Id { get; set; }

        public override string Info()
        {
            return $"{Title}, {Price}";
        }
    }
}

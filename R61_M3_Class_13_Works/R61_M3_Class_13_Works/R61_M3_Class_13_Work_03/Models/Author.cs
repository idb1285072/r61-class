using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_13_Work_03.Models
{
    public class Author : EntityBase
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public string Email {  get; set; }
        public override string Info()
        {
            return $"{Name}, {Email}";
        }
    }
}

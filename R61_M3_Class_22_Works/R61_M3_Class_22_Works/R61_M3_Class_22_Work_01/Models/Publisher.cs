using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_22_Work_01.Models
{
    public class Publisher : EntityBase
    {
        public string Name { get; set; }
        public string Address {  get; set; }
        public string Contact {  get; set; }    
        public string WebUrl {  get; set; }
    }
}

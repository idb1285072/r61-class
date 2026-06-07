using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_22_Work_01.Models
{
    public class Book : EntityBase
    {
        public string Title {  get; set; }
        public decimal CoverPrice {  get; set; }
        public DateTime PublishDate {  get; set; }
    }
}

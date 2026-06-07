using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_23_Work_01.Models
{
    public enum BookType { EBook=1, Print}
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public BookType Type { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal Price { get; set; }
        public ICollection<string> Authors { get; set; }= new List<string>();
    }
}

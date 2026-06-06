using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace R61M11C03_w01.Models
{
    public class SalesMaster
    {
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

       

        public bool IsDelivered { get; set; }
        [NotMapped]
        public string CustomerName { get; set;
        }
        public  Customer Customer { get; set; }
        public virtual ICollection<SalesDetails> SalesDetails { get; set; } = new List<SalesDetails>();

    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace R61M11C03_w01.Models
{
    public class SalesDetails
    {
        public int Id { get; set; }
        [Required, ForeignKey(nameof(SalesMaster))]
        public int SalesID { get; set; }

        [Required, ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [Required, DataType(DataType.Currency)]
        public float Price { get; set; }
        [NotMapped]
        public string ProductName { get; set; }
        public virtual Product Product { get; set; }
        public virtual SalesMaster SalesMaster { get; set; }
    }
}

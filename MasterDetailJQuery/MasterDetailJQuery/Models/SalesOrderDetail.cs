using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MasterDetailJQuery.Models
{
    public class SalesOrderDetail
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(SalesOrder))]
        public int OrderId { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
    }
}
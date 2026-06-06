using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MasterDetailJQuery.Models
{
    public class SalesOrder
    {
        [Key]
        public int ID {  get; set; }
        public int Ordernumber {  get; set; }
        public string Customername { get; set; }
        public string Address { get; set; }
        public virtual List<SalesOrderDetail> Details { get; set; }
    }
 
    public class OrderContext:DbContext
    {
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderDetail> Details { get; set; }
    }
}
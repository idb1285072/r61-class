using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class modelEVD:DbContext
    {
        public DbSet<Product>   Products { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int Quantity { get; set; }
        //public double UnitPrice { get; set; }
        //public double Subtotal { get; set; }
    }
    public class SalesOrder
    {
        [Key]
        public int ID { get; set; }
        public string Ordernumber { get; set; }
        public string Customername { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public string Picture { get; set; }
        public bool ISCompleted { get; set; }
        public virtual List<SalesOrderDetail> Details { get; set; }
    }
    public class SalesOrderDetail
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(SalesOrder))]
        public int OrderId { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public Product Product { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
    }
}
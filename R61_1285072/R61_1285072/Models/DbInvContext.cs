using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace R61_1285072.Models
{
    public class DbInvContext : IdentityDbContext
    {
        public DbInvContext() : base("DbInvContext")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Details> Details { get; set; }
    }
    public class Product
    {
        public int ID { get; set; }
        [Required, MaxLength(128)]
        public string Name { get; set; }
    }
    public class Sales
    {
        public int ID { get; set; }
        [Required, MaxLength(20, ErrorMessage = "Name is must")]
        public string Name { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [MaxLength(200)]
        public string Picture { get; set; }

        public bool Status { get; set; }
        public List<Details> Details { get; set; }

    }
    public class Details
    {
        public int ID { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [ForeignKey(nameof(Sales))]
        public int OrderId { get; set; }
        [Required, DataType(DataType.Currency)]
        public double Price { get; set; }
        public Product Product { get; set; }
        public Sales Sales { get; set; }
    }
}
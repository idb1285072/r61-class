using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace M8_evd_Master_Token.Models
{
    public class DbInvContext:IdentityDbContext
    {
        public DbInvContext():base("DbInvContext")
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sales>Sales { get; set; }
        public DbSet<Details> Details { get; set; }
    }
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class Sales
    {
        public int ID { get; set; }
        [MaxLength(20)]

        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Odate { get; set; }
        [MaxLength(200)]
        public string Pic { get; set; }
   
        public bool Status { get; set; }
        public List<Details> Details { get; set; }

    }
    public class Details
    {
        public int ID { get; set; }
        [ForeignKey(nameof(Product))]
        public int Pid { get; set; }
        [ForeignKey(nameof(Sales))]

        public int Oid { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }
        public Sales Sales { get; set; }
    }

}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using R61M11C03_w01.Models;
using System.Reflection.Emit;

namespace R61M11C03_w01.Models
{
    public class ProductContext:IdentityDbContext<ApplicationUser> 
    {
        public ProductContext(DbContextOptions<ProductContext>options):base(options)
        {
                
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Product { get; set; }

        public DbSet<SalesMaster> SalesMasters { get; set; }
        public DbSet<SalesDetails> SalesDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SalesMaster>()
                        .Navigation(a => a.SalesDetails)
                        .AutoInclude();
            builder.Entity<SalesDetails>()
                      .Navigation(a => a.Product)
                      .AutoInclude();
            base.OnModelCreating(builder);
        }
    }
}

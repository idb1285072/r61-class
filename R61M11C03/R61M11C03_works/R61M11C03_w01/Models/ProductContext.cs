using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace R61M11C03_w01.Models
{
    public class ProductContext:IdentityDbContext<ApplicationUser> 
    {
        public ProductContext(DbContextOptions<ProductContext>options):base(options)
        {
                
        }
        public DbSet<Category> Categories { get; set; }
    }
}

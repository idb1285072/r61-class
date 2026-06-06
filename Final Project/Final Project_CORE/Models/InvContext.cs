using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_CORE.Models
{
    public class InvContext:IdentityDbContext<ApplicationUser>
    {
        public InvContext(DbContextOptions<InvContext>op):base(op)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= DESKTOP-PNALNN3\\SQLEXPRESS  ;Initial Catalog=DBInentoryManagement; Trusted_connection=true; TrustServerCertificate=true; ");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

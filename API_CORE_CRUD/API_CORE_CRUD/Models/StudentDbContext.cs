using Microsoft.EntityFrameworkCore;

namespace API_CORE_CRUD.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get;  set; }
    }
}

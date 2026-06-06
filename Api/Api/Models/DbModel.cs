using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;
        public DateTime AdmissionDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
    }
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class PersonContext:DbContext
    {
        public PersonContext(DbContextOptions<PersonContext>op):base(op)
        {

        }
        public DbSet<Person> Persons { get; set; }  
    }

    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}

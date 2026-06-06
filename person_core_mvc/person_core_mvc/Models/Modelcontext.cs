using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace person_core_mvc.Models
{
    public class Modelcontext:DbContext
    {
        public Modelcontext() : base()
        {
        }
        public Modelcontext(DbContextOptions<Modelcontext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(new List<Person>()
            {
                new Person(){ Id = 1, FirstName = "John", LastName = "Smith",
                EmailAddress = "john@smith.com"},
                new Person(){ Id = 2, FirstName = "Susan", LastName = "Jones",
                EmailAddress = "john@smith.com" }
            });

            modelBuilder.Entity<Address>().HasData(new List<Address>()
            {
                new Address() { Id = 1, AddressLine1 = "123 Test St", AddressLine2 = "",
                City = "Beverly Hills", State = "CA", ZipCode = "90210", PersonId = 1,
                Country = "USA"},
                new Address() { Id = 2, AddressLine1 = "123 Michigan Ave",
                AddressLine2 = "", City = "Chicago", State = "IL", ZipCode = "60612",
                PersonId = 2, Country = "USA"},
                new Address() { Id = 3, AddressLine1 = "100 1St St", AddressLine2 = "",
                City = "Chicago", State = "IL", ZipCode = "60612", PersonId = 2,
                Country = "USA"}
            });
        }


    }
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
    }
    public class Address
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        [ForeignKey(nameof(Person))]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}

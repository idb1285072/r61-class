using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> op) : base(op)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<LookUp> Lookups { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LookUp>().HasData(new List<LookUp>()
{
                        new LookUp() { Code = "AL", Description = "Alabama",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "AK", Description = "Alaska",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "AZ", Description = "Arizona",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "AR", Description = "Arkansas",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "CA", Description = "California",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "CO", Description = "Colorado",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "CT", Description = "Connecticut",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "DE", Description = "Delaware",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "DC", Description = "District of Columbia", LookUpType = LookUpType.State},
                        new LookUp() { Code = "FL", Description = "Florida",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "GA", Description = "Georgia",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "ID", Description = "Hawaii",
                        LookUpType = LookUpType.State},

                        new LookUp() { Code = "IL", Description = "Idaho",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "IN", Description = "Illinois",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "IA", Description = "Indiana",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "KS", Description = "Iowa",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "KY", Description = "Kansas",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "LA", Description = "Kentucky",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "ME", Description = "Louisiana",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "MD", Description = "Maine",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "MA", Description = "Maryland",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "MI", Description = "Massachusetts",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "MN", Description = "Michigan",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "MS", Description = "Minnesota",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "MO", Description = "Mississippi",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "MT", Description = "Missouri",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "NE", Description = "Montana",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "NV", Description = "Nevada",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "NH", Description = "New Hampshire",
                        LookUpType = LookUpType.State},

                        new LookUp() { Code = "NJ", Description = "New Jersey",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "NM", Description = "New Mexico",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "NY", Description = "New York",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "NC", Description = "New Carolina",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "ND", Description = "North Dakota",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "OH", Description = "Ohio",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "OK", Description = "Oklahoma",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "OR", Description = "Oregon",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "PA", Description = "Pennsylvania",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "RI", Description = "Rhode Island",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "SC", Description = "South Carolina",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "SD", Description = "South Dakota",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "TN", Description = "Tennessee",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "TX", Description = "Texas",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "UT", Description = "Utah",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "VT", Description = "Vermont",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "VA", Description = "Virginia",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "WA", Description = "Washington",
                        LookUpType = LookUpType.State},

                        new LookUp() { Code = "WV", Description = "West Virginia",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "WI", Description = "Wisconsis",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "WY", Description = "Wyoming",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "PR", Description = "Puerto Rico",
                        LookUpType = LookUpType.State},
                        new LookUp() { Code = "USA", Description = "United States of America", LookUpType = LookUpType.Country}
                        });
        }
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
        public int PersonId { get; set; }
    }
    public class LookUp
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
        public LookUpType LookUpType { get; set; }
    }
    public enum LookUpType
    {
        State = 0,
        Country = 1
    }
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}

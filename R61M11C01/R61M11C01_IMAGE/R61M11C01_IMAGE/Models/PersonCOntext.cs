using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace R61M11C01_IMAGE.Models
{
    public class PersonCOntext:DbContext
    {
        public PersonCOntext(DbContextOptions<PersonCOntext>op):base(op) 
        {
            
        }
        public DbSet<Person> Persons { get; set; } 
    }
    public class Person
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        [ValidateNever]
        public string ImagePath { get; set; }
         
    }
}

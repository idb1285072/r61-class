using System;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        private PersonContext _context;
        [SetUp]
        public void Setup()
        {

            _context = new PersonContext(new DbContextOptionsBuilder<PersonContext>()
            .UseSqlServer("Server=.\\SQLEXPRESS;Database=EfCore5WebApp;Trusted_Connection = True; MultipleActiveResultSets = true;Trust server certificate=true;")
            .Options);

        }

        [Test]
        public void GetAllPersons()
        {
            //Arrange & Act
            IEnumerable<Person> persons = _context.Persons.ToList();
            //assert
            Assert.AreEqual(2, persons.Count());

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void AddLookUpItemInterpolated()
        {
            string code = "CAN";
            string description = "Canada";
            LookUpType lookUpType = LookUpType.Country;
            _context.Database.ExecuteSqlInterpolated($"AddLookUpItem {code},{ description}, { lookUpType}   ");
var addedItem = _context.Lookups.Single(x => x.Code == "CANN");
            Assert.IsNotNull(addedItem);
            _context.Lookups.Remove(addedItem);
            _context.SaveChanges();
        }

        [TearDown]
       public void Dispose()
        {
            _context.Dispose();
        }

    }
}
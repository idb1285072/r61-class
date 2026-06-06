using Microsoft.AspNetCore.Mvc;
using person_core_mvc.Models;
using person_core_mvc.Viewmodels;

namespace person_core_mvc.Controllers
{
    public class PersonsController : Controller
    {
        private readonly Modelcontext _context;
        public PersonsController(Modelcontext context)
        {
            this._context = context;
            
        }
        public IActionResult Index(string  FirstName="")
        {
            var personAddresses = _context.Addresses.OrderBy(a=>a.AddressLine1).ToList();
            if (FirstName.Length > 0)
            {
                 personAddresses = (from p in _context.Persons
                                       where p.FirstName == FirstName
                                       select p.Addresses)
                                       .SelectMany(a => a).ToList();
                //return View(personAddresses);
            }
          
            return View(personAddresses);
        }
        public IActionResult PersonsInfo(string FirstName = "")
        {
           
          
            var person = (from p in _context.Persons
                         join a in _context.Addresses on p.Id equals a.PersonId
                         //where p.FirstName == "Susan"
                         select new PersoninfoVM
                         {
                              Person=p,
                              Addresses=a
                         }).ToList();
            if (FirstName.Length > 0)
            {
                person = person.Where(p => p.Person.FirstName == FirstName).ToList();

            }
            return View(person);
        }
    }
}

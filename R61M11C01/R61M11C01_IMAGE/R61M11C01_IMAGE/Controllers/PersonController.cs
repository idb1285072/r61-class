using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using R61M11C01_IMAGE.Models;

namespace R61M11C01_IMAGE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonCOntext _context;
        private readonly IWebHostEnvironment _environment;
        public PersonController(PersonCOntext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        [HttpPost]
        public IActionResult Post()
        {
            var requestedFile= HttpContext.Request.Form.Files[0];
            var Name= HttpContext.Request.Form["Name"];
            var ContactNumber = HttpContext.Request.Form["ContactNumber"];
            var EmailAddress = HttpContext.Request.Form["EmailAddress"];
            var insertedperson = new Person
            {
                ContactNumber = ContactNumber,
                Name = Name,
                EmailAddress = EmailAddress
            };
            try
            {
                if (requestedFile == null)
                {
                    string ext = Path.GetExtension(requestedFile.FileName).ToLower();
                    if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
                    {
                        string root = Path.Combine(_environment.WebRootPath, "Pictures");
                        if (!Directory.Exists(root))
                        {
                            Directory.CreateDirectory(root);
                        }
                        string fileToSave = Path.Combine(root, Name + ext);
                        using (var fs = new FileStream(fileToSave, FileMode.Create))
                        {
                            requestedFile.CopyTo(fs);
                        }
                        insertedperson.ImagePath = "~/Pictures/" + Name + ext;
                        _context.Persons.Add(insertedperson);
                        if (_context.SaveChanges() > 0)
                        {
                            return Created("", insertedperson);
                        }
                        else
                        {
                            return Problem("Save failed");
                        }
                    }
                    else
                    {
                        return Problem("Please provide valid pic like jpg|png|jpeg");
                    }
                }
            }
            catch (Exception ex) {
                return Problem(ex.Message);
            }
           
            
            return Ok();
        }
    
    }
}

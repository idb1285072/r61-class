using API_CORE_CRUD.DTOs;
using API_CORE_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace API_CORE_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly HospitalDbContext db;

        public PatientsController(HospitalDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            try
            {
               var model =await db.Patients
              .Include("Appointments")
              .Select(p => new
              {
                  p.Id,
                  p.Name,
                  p.BirthDate,
                  p.Picture,
                  p.IsAdmited,
                  Appointment = p.Appointments.Select(a => new
                  {
                      a.Id,
                      a.Location,
                      a.Fee,
                      DoctorName = a.Doctor.Name
                  })
              })
              .ToListAsync();

                if (!model.Any())
                    return Ok("No records are found");

                return Ok(model);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatientById(int id)
        {
            try
            {
                var model = await db.Patients
               .Include("Appointments")
               .Where(p => p.Id == id)
               .Select(p => new
               {
                   p.Id,
                   p.Name,
                   p.BirthDate,
                   p.Picture,
                   p.IsAdmited,
                   Appointment = p.Appointments.Select(a => new
                   {
                       a.Id,
                       a.Location,
                       a.Fee,
                       DoctorName = a.Doctor.Name
                   })
               }).FirstOrDefaultAsync();
                if(model == null) return NotFound();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var patient = await db.Patients.FindAsync(id);
            if (patient == null) return NotFound();
            db.Appointments.RemoveRange(db.Appointments.Where(a => a.PatientId == id));
            db.Patients.Remove(patient);
            await db.SaveChangesAsync();
            return Ok($"Deleted {id}");
        }
        [HttpPost]
        public IActionResult Post()
        {
            var requestedFile = HttpContext.Request.Form.Files[0];
            var p = HttpContext.Request.Form["Patient"];
            var entity = JsonConvert.DeserializeObject<PatientCreateDTO>(p);
            try
            {
                if (requestedFile != null)
                {
                    string ext = Path.GetExtension(requestedFile.FileName);
                    string fileName = DateTime.Now.ToString("yyyyMMddffff") + ext;
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Pictures", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        requestedFile.CopyTo(stream);
                    }
                    var patient = new Patient
                    {
                        Name = entity.Patient.Name,
                        BirthDate = entity.Patient.BirthDate,
                        IsAdmited = entity.Patient.IsAdmited,
                        Appointments = entity.Patient.Appointments,
                        Picture = fileName
                    };
                    db.Patients.Add(patient);
                    db.SaveChanges();
                }
                return Ok("Created succeed");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}

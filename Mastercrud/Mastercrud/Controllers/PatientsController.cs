using Mastercrud.DTOs;
using Mastercrud.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using static Mastercrud.Models.DbModel;

namespace Mastercrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly HospitalDbContext db;

        public PatientsController(HospitalDbContext  db)
        {
            this.db = db;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            //var patients = await db.Patients
            //                       .Include(a => a.Appointments)
            //                       .ThenInclude(d => d.Doctor)
            //                       .ToListAsync();

            //var patientDtos = patients.Select(p => new Patient
            //{
            //    Id = p.Id,
            //    Name = p.Name,
            //    BirthDate = p.BirthDate,
            //    Picture = p.Picture,
            //    IsAdmited = p.IsAdmited,
            //    Appointments = p.Appointments.Select(a => new Appointment
            //    {
            //        Id = a.Id,
            //        Location = a.Location,
            //        Fee = a.Fee,
            //        DoctorId = a.DoctorId
            //    }).ToList()
            //}).ToList();

            //return Ok(patientDtos);
            try
            {
                var model = db.Patients
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
                       DoctorName = a.Doctor.Name,
                   }).ToList()
               }).ToList();
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
            var p = await db.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).FirstOrDefaultAsync(p => p.Id == id);
            if (p == null) return NotFound();
            var data = new Patient
            {
                Id = p.Id,
                Name = p.Name,
                BirthDate = p.BirthDate,
                Picture = p.Picture,
                IsAdmited = p.IsAdmited,
                Appointments = p.Appointments.Select(a => new Appointment
                {
                    Id = a.Id,
                    Location = a.Location,
                    Fee = a.Fee,
                    DoctorId = a.DoctorId
                }).ToList()
            };
            
            return Ok(data);
        }
      
        
        [HttpPost]
        public IActionResult Post()
        {
            // Get form data
            var requestedFile = HttpContext.Request.Form.Files[0];
            //var name = HttpContext.Request.Form["Name"];
            //var birthdate = HttpContext.Request.Form["BirthDate"];
            //var isAdmited = HttpContext.Request.Form["IsAdmited"];
            var p = HttpContext.Request.Form["Patient"];
            var entity= JsonConvert.DeserializeObject<PatientCreateDTO>(p);
            //var appointments = HttpContext.Request.Form["Appointments"].ToString();
            //var appointmentList = JsonConvert.DeserializeObject<List<Appointment>>(appointments); // Deserialize the appointments JSON string

            //var insertedPatient = new Patient
            //{
            //    Name = name,
            //    BirthDate = Convert.ToDateTime(birthdate),
            //    IsAdmited = Convert.ToBoolean(isAdmited),
            //};
            

            try
            {
                
                if (requestedFile != null) {
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


                return Ok();


                //if (db.SaveChanges() > 0)
                //{

                //    foreach (var appointment in appointmentList)
                //    {

                //        appointment.PatientId = insertedPatient.Id;
                //        db.Appointments.Add(appointment);
                //    }


                //    db.SaveChanges();
                //    return Created("", insertedPatient);
                //}
                //else
                //{
                //    return Problem("Save failed");
                //}
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        


    }
}

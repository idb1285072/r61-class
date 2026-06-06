using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using API_CRUD.DAL;
using API_CRUD.Models;
 
namespace WebApplication1.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PatientAppointMentController : ApiController
    {
        private readonly HospitalDbContext db = new HospitalDbContext();
        public IEnumerable<PatientAppointment> Get()
        {
            return db.PatientAppointments.ToList();
        }
         public PatientAppointment Get(int id)
          {
            return db.PatientAppointments.Find(id);
          }
        public void Delete(int id)
        {
            db.Patients.Remove(db.Patients.Find(id));
            db.SaveChanges();
        }
        public void Put(PatientAppointment appointment)
        {
            db.Entry(appointment).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Post(PatientAppointment appointment)
        {
            db.PatientAppointments.Add(appointment);
            db.SaveChanges();
        }
    }
}

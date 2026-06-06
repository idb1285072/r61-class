using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using API_CRUD.DAL;
using API_CRUD.Models;


namespace apicrud1.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PatientController : ApiController
    {
        private readonly HospitalDbContext db = new HospitalDbContext();
        public IEnumerable<Patient> Get()
        {
            return db.Patients;
        }
        public Patient Get(int id)
        {
            return db.Patients.Find(id);
        }
        public string Post(Patient patient)
        {
            db.Patients.Add(patient);
            db.SaveChanges();
            return "Posted Successfully";
        }
        public void Put(Patient patient)
        {
            db.Entry(patient).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public string Delete(int id)
        {
            db.Patients.Remove(db.Patients.Find(id));
            db.SaveChanges();
            return "Deleted Successfully";
        }
    }
}

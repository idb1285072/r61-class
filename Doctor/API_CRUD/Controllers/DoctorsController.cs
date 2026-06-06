using API_CRUD.DAL;
using API_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace apicrud1.Controllers
{
    [EnableCors("*", "*", "*")]
    public class DoctorsController : ApiController
    {
        private readonly HospitalDbContext db =new HospitalDbContext();
        public DoctorsController() { }

        public IEnumerable<Doctor> Get()
        {
            return db.Doctors;
        }
        public Doctor Get(int Id)
        {
            return db.Doctors.Find(Id);

        }
        public string Post(Doctor doctor)
        {
            db.Doctors.Add(doctor);
            db.SaveChanges();
            return "save success";
        }
        public string Put(Doctor doctor)
        {
            db.Entry(doctor).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "upadate success";
        }
        public string Delete(int Id)
        {
            db.Doctors.Remove(db.Doctors.Find(Id));
            db.SaveChanges();
            return "delete success";
        }
    }
}

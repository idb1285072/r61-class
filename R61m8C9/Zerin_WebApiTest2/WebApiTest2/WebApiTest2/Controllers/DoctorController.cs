using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTest2.Models;
using static System.Net.WebRequestMethods;

namespace WebApiTest2.Controllers
{
    public class DoctorController : ApiController
    {
        private readonly DoctorContext db = new DoctorContext();
        public DoctorController() 
        { 

        }
        public IEnumerable<Doctor> Get()
        {
            return db.Doctors;
        }

        public Doctor Get(int id)
        {
            return db.Doctors.Find(id);
        }

        public void post(Doctor doctor)
        {
            db.Doctors.Add(doctor);
            db.SaveChanges();
        }

        public void put(Doctor doctor)
        {
            db.Entry(doctor).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
       
        public void delete(int id)
        { 
            db.Doctors.Remove(db.Doctors.Find(id));
            db.SaveChanges();
        }

    }
}

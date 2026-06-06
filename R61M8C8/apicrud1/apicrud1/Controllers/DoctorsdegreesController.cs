using apicrud1.Models;
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
    public class DoctorsdegreesController : ApiController
    {
        private readonly modelcontext db=new modelcontext();
        public DoctorsdegreesController() { }

        public IEnumerable<DoctorsDegree> Get()
        {
            return db.DoctorsDegrees;
        }
        public DoctorsDegree Get(int Id)
        {
            return db.DoctorsDegrees.Find(Id);

        }
        public string Post(DoctorsDegree doctorsDegree)
        {
            db.DoctorsDegrees.Add(doctorsDegree);
            db.SaveChanges();
            return "save success";
        }
        public string Put(DoctorsDegree doctorsDegree)
        {
            db.Entry(doctorsDegree).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "upadate success";
        }
        public string Delete(int Id)
        {
            db.DoctorsDegrees.Remove(db.DoctorsDegrees.Find(Id));
            db.SaveChanges();
            return "delete success";
        }
    }
}

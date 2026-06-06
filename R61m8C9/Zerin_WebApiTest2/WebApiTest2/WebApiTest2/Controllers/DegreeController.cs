using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiTest2.Models;

namespace WebApiTest2.Controllers
{
    [EnableCors("*", "*", "*")]
    public class DegreeController : ApiController
    {
        private readonly DoctorContext db = new DoctorContext();
        public DegreeController()
        {

        }
        public IEnumerable<Degree> Get()
        {
            return db.Degrees;
        }

        public Degree Get(int id)
        {
            return db.Degrees.Find(id);
        }

        public void post(Degree degree)
        {
            db.Degrees.Add(degree);
            db.SaveChanges();
        }

        public void put(Degree degree)
        {
            db.Entry(degree).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void delete(int id)
        {
            db.Degrees.Remove(db.Degrees.Find(id));
            db.SaveChanges();
        }
    }
}

 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using apicrud1.Models;


namespace apicrud1.Controllers
{
    [EnableCors("*", "*", "*")]
    public class DegreesController : ApiController
    {
        private readonly modelcontext db = new modelcontext();
        public IEnumerable<Degree> Get()
        {
            return db.Degrees.ToList();
        }
        public Degree Get(int id)
        {
            return db.Degrees.Find(id);
        }
        public void Delete(int id)
        {
            db.Degrees.Remove(db.Degrees.Find(id));
            db.SaveChanges();
        }
        public void Put(Degree degree)
        {
            db.Entry(degree).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Post(Degree degree)
        {
            db.Degrees.Add(degree);
            db.SaveChanges();
        }
    }
}
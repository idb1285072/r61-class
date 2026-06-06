using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using apicrud1.Models;
 

namespace apicrud1.Controllers
{
    [EnableCors("*", "*", "*")]
    public class DesignationsController : ApiController
    {
        private readonly modelcontext db = new modelcontext();
        public IEnumerable<Designation> Get()
        {
            return db.Designations.ToList();
        }
        public Designation Get(int id)
        {
            return db.Designations.Find(id);
        }
        public void Delete(int id)
        {
            db.Designations.Remove(db.Designations.Find(id));
            db.SaveChanges();
        }
        public void put(Designation Designation)
        {
            db.Entry(Designation).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Post(Designation Designation)
        {
            db.Designations.Add(Designation);
            db.SaveChanges();
        }
    }
}

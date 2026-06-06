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
    public class InstituteController : ApiController
    {
        private readonly HospitalDbContext db = new HospitalDbContext();
        public IEnumerable<Institute> Get()
        {
            return db.Institutes;
        }
        public Institute Get(int id)
        {
            return db.Institutes.Find(id);
        }
        public string Post(Institute Institute)
        {
            db.Institutes.Add(Institute);
            db.SaveChanges();
            return "Posted Successfully";
        }
        public void Put(Institute Institute)
        {
            db.Entry(Institute).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public string Delete(int id)
        {
            db.Institutes.Remove(db.Institutes.Find(id));
            db.SaveChanges();
            return "Deleted Successfully";
        }
    }
}

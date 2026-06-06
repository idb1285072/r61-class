using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using R61M6C5_Security.Models;


namespace R61M6C5_Security.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Employees
        public ActionResult Index()
        {
            var model = db.Departments.OrderBy(n => n.Name).ToList();
            return View(model);
        }
        
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Department department )
        {
            db.Departments.Add(department);
            if(db.SaveChanges()>0)
            {
                return RedirectToAction("Index");
            }

            return View(department);
        }
        public ActionResult Edit()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Edit(Department department)
        {
            db.Entry(department).State=  System.Data.Entity.EntityState.Modified;
            if (db.SaveChanges() > 0)
            {
                return RedirectToAction("Index");
            }

            return View(department);
        }
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var emp = db.Employees.Find(id);
            db.Employees.Remove(emp);
            if (db.SaveChanges() > 0)
            {
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

    }
}
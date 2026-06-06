using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using R61M6C3wORKS.Models;

namespace R61M6C3wORKS.Controllers
{
    public class CourseController : Controller
    {
        DbschoolContext context = new DbschoolContext();
        // GET: Course
        public ActionResult Index()
        {
            var model = context.Courses.OrderBy(c=>c.Name).ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                context.Courses.Add(course);
                if (context.SaveChanges() > 0)
                {
                    return RedirectToAction("index");
                }
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                                 .SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage));
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, message);
            }
            return View(course);
        }
        public ActionResult Edit(int id)
        {
            var model = context.Courses.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
               context.Entry(course).State=  System.Data.Entity.EntityState.Modified;
                if (context.SaveChanges() > 0)
                {
                    return RedirectToAction("index");
                }
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                                 .SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage));
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, message);
            }
            return View(course);
        }
        public ActionResult Delete(int id)
        {
            var model = context.Courses.Find(id);
            context.Courses.Remove(model);
            if (context.SaveChanges() > 0)
            {
                return RedirectToAction("index");
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Delete failed");
        }

    }
}
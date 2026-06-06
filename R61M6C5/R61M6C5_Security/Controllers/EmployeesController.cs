using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using R61M6C5_Security.Models;


namespace R61M6C5_Security.Controllers
{
    [Authorize(Users ="b@b.com")]
    public class EmployeesController : Controller
    {
        ApplicationDbContext  db=new ApplicationDbContext();
        // GET: Employees
        public ActionResult Index()
        {
            var model= db.Employees.Include("Department").OrderBy(n=>n.Name).ToList();
            return View(model);
        }
        public ActionResult Create() {

            ViewBag.Department = new SelectList(db.Departments.OrderBy(d => d.Name), "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee,HttpPostedFileBase EmployeePic)
        {

            if (EmployeePic == null) {
                ModelState.AddModelError("", "Please Provide valid pic");
                
              //  return View(EmployeePic);
            }
            else
            {
                if (ModelState.IsValid) {
                string ext= Path.GetExtension(EmployeePic.FileName);
                if(ext ==".jpg"||  ext ==".png"|| ext == ".jpeg")
                {
                   string root= Server.MapPath("~/");
                        string dir = Path.Combine(root, "EmpImages");
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }
                        string fileTosave = Path.Combine(dir,employee.Name+ext);

                    EmployeePic.SaveAs(fileTosave);
                    employee.ImagePath = "~/EmpImages/" + employee.Name + ext;
                    db.Employees.Add(employee);
                    if (db.SaveChanges() > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please Provide valid pic .jpg|.png|.jpeg");
                    return View(EmployeePic);
                }
                }
                else
                {
                    return View(EmployeePic);
                }
            }
            ViewBag.Department = new SelectList(db.Departments.OrderBy(d => d.Name), "Id", "Name");
            return View();
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.Department = new SelectList(db.Departments.OrderBy(d => d.Name), "Id", "Name");
            if (id == 0)
            {
                return HttpNotFound();
            }
            var model = db.Employees.Find(id);
            if(model==null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee, HttpPostedFileBase EmployeePic)
        {
            
                if (ModelState.IsValid)
                {
                if (EmployeePic != null)
                {
                  
                    string ext = Path.GetExtension(EmployeePic.FileName);
                    if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
                    {
                        string root = Server.MapPath("~/");
                        string old = employee.ImagePath.Substring(2, employee.ImagePath.Length - 2);
                        string oldpic =  root+ old;
                        string dir = Path.Combine(root, "EmpImages");
                        if(!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }
                        string fileTosave = Path.Combine(dir, employee.Name + ext);
                        EmployeePic.SaveAs(fileTosave);
                        employee.ImagePath = "~/EmpImages/" + employee.Name + ext;

                        if (System.IO.File.Exists(oldpic))
                        {
                           // Directory.Delete(oldpic);
                            System.IO.File.Delete(oldpic);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please Provide valid pic .jpg|.png|.jpeg");
                        return View(EmployeePic);
                    }
                }
                else
                {
                    employee.ImagePath = employee.ImagePath;
                }
                //db.Employee.Add(employee);
                db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    return RedirectToAction("Index");
                }
            }
                else
                {
                    return View(EmployeePic);
                }
            
            ViewBag.Department = new SelectList(db.Departments.OrderBy(d => d.Name), "Id", "Name");
            return View();
        }
        public ActionResult Delete(int id)
        {
            if (id == 0) { 
                return HttpNotFound();
            }
            var emp= db.Employees.Find(id);

            db.Employees.Remove(emp);
           if(db.SaveChanges() > 0)
            {
                string root = Server.MapPath("~/");
                string old = emp.ImagePath.Substring(2, emp.ImagePath.Length - 2);
                string oldpic = root + old;

                if (System.IO.File.Exists(oldpic))
                {
                    
                    System.IO.File.Delete(oldpic);
                }
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
        

    }
}
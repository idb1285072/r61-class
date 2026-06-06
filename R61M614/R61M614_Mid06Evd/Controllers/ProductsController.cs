using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using R61M614_Mid06Evd.Models;

namespace R61M614_Mid06Evd.Controllers
{
    public class ProductsController : Controller
    {
       private readonly dbmidExam06Entities db = new dbmidExam06Entities();
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            var model = new Category();
            model.Products.Add(new Product());
            return View(model);
        }
        public PartialViewResult CreateDetail()
        {
            var model = new Category();
            model.Products.Add(new Product());
            return PartialView("_CreateDetail",model);
        }
        [HttpPost]
        public ActionResult Create(Category entity,HttpPostedFileBase Picture,string operation="")
        {
            if(operation.ToLower() =="add")
            {
                entity.Products.Add(new Product());
                foreach (var e in ModelState.Values)
                {
                    e.Errors.Clear();
                    e.Value = null;
                }
            }
            if (operation.StartsWith("del"))
            {
                int pos = operation.IndexOf("_");
                int index = int.Parse(operation.Substring(pos + 1));
                entity.Products.RemoveAt(index);
                foreach (var e in ModelState.Values)
                {
                    e.Errors.Clear();
                    e.Value = null;
                }
            }
            if (operation == "insert")
            {
                if (ModelState.IsValid)
                {
                    try
                    {

                        string ext = Path.GetExtension(Picture.FileName);
                        if(ext==".png"|| ext==".jpg" || ext == ".jpeg")
                        {

                       
                        string f = entity.Name + ext;
                        string savePath = Path.Combine(Server.MapPath("~/Pictures"), f);
                        Picture.SaveAs(savePath);
                        entity.Picture = "~/Pictures/" + f;

                        //var newProducts = entity.Products.Select(s => new Product { Name = s.Name, Price = s.Price }).ToList();
                        //entity.Products.AddRange(newProducts);
                        db.Categories.Add(entity);
                        if (db.SaveChanges() > 0)
                        {
                            return RedirectToAction("Index","Products");
                        }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Please Provide Valid image");
                        }
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                }
            }

            return View("_CreateDetail",entity);
        }

        [HttpGet]
        
        public ActionResult Edit(int id)
        {
            var model = db.Categories.Include("Products").Where(c=>c.Id==id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]

        public ActionResult Edit(Category entity, HttpPostedFileBase Picture, string operation = "")
        {
            if (operation.ToLower() == "add")
            {
                entity.Products.Add(new Product());
                foreach (var e in ModelState.Values)
                {
                    e.Errors.Clear();
                    e.Value = null;
                }
            }
            if (operation.StartsWith("del"))
            {
                int pos = operation.IndexOf("_");
                int index = int.Parse(operation.Substring(pos + 1));
                entity.Products.RemoveAt(index);
                foreach (var e in ModelState.Values)
                {
                    e.Errors.Clear();
                    e.Value = null;
                }
            }
            if (operation == "update")
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        if (Picture != null)
                        {
                        string ext = Path.GetExtension(Picture.FileName);
                        if (ext == ".png" || ext == ".jpg" || ext == ".jpeg")
                        {
                            string f = entity.Name + ext;
                            string savePath = Path.Combine(Server.MapPath("~/Pictures"), f);
                            Picture.SaveAs(savePath);
                            entity.Picture = "~/Pictures/" + f;

                            //var newProducts = entity.Products.Select(s => new Product { Name = s.Name, Price = s.Price }).ToList();
                            //entity.Products.AddRange(newProducts);
                           
                        }
                        else
                        {
                                ModelState.AddModelError("", "Please provide valid image");
                        }
                            //db.Categories.Add(entity);
                           
                        }

                        else
                        {
                            entity.Picture = entity.Picture;
                        }
                        db.Products.RemoveRange(db.Products.Where(p => p.CatId == entity.Id).ToList());
                        db.SaveChanges();
                        var newProducts = entity.Products.Select(s => new Product { Name = s.Name, Price = s.Price, CatId = entity.Id }).ToList();
                        entity.Products = newProducts;

                        db.Products.AddRange(newProducts);
                        //db.Products.AddRange(entity.Products);
                        db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                        if (db.SaveChanges() > 0)
                        {
                            return RedirectToAction("Index", "Products");
                        }
                    }

                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                }
            }
            return View(entity);
        }
        public PartialViewResult LoadProduct()
        {
            var model = db.Categories.Include("Products")
                        .OrderByDescending(c=>c.Id).ToList();
            return PartialView("_LoadProduct", model);
        }
        public ActionResult Delete(int id)
        {
            try
            {
                var model = db.Products.Where(p => p.CatId == id).ToList();
                db.Products.RemoveRange(model);
                db.Categories.Remove(db.Categories.Find(id));
                if (db.SaveChanges() > 0)
                {
                    ViewBag.err = "Deleted succefully";
                }
            }
            catch(Exception ex)
            {
                ViewBag.err = ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
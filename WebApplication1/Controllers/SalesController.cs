using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class SalesController : Controller
    {
        modelEVD db=new modelEVD();
        // GET: Sales
        public ActionResult Index()
        {
            var model = db.SalesOrders.OrderByDescending(o=>o.ID).ToList();
            return View(model);
        }
        public ActionResult Delete(int Id)
        {
            db.SalesOrderDetails.RemoveRange(db.SalesOrderDetails
                                .Where(o => o.OrderId == Id));
            db.SalesOrders.Remove(db.SalesOrders.Find(Id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult LoadOrderDetails(int orderNumber)
        {
            var model = db.SalesOrderDetails.Include("Product")
                        .Where(c => c.OrderId==orderNumber).ToList()
                        .Select(s=> new SalesDetailsVM
                        {
                             ProductName=s.Product.Name,
                             OrderId=s.OrderId,
                             Discount=s.Discount,
                              Quantity=s.Quantity,
                              Total=s.Total,
                              UnitPrice=s.UnitPrice,
                                
                        });
            return PartialView("_LoadOrderDetails", model);
        }

        [HttpGet]
    public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products.OrderBy(p=>p.Name).ToList(),"Id","Name" );
            return View();
        }
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalesOrder salesOrder)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imageHeader = Request.Headers["Image-Data"];

                    if (!string.IsNullOrEmpty(imageHeader))
                    {
                        var imageData = Convert.FromBase64String(imageHeader);
                        var filePath = Path.Combine(Server.MapPath("~/Pictures/"), salesOrder.Ordernumber + ".png");// "uploadedImage.png"
                        System.IO.File.WriteAllBytes(filePath, imageData);
                        salesOrder.Picture = "~/Pictures/" + salesOrder.Ordernumber + ".png";
                        db.SalesOrders.Add(salesOrder);
                        int x = db.SaveChanges();
                        if (x > 0)
                        {
                            return Json(data: new { Success = true, Message = "Data Successfully Added" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { Success = false, Message = "Please Provide valid Image" });
                        }
                    }
                    else
                    {
                        return Json(new { Success = false, Message = "Please Provide valid Image" });
                    }
                }
                else
                {
                    var message = string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    return Json(new { Success = false, msg =message });
                }
            }
            catch (Exception ex)
            {
                return Json(data: new { Success = false, Message = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            
            var model = db.SalesOrders.Where(s=>s.ID==Id).Include("SalesDetails").FirstOrDefault();
            ViewBag.ProductId = new SelectList(db.Products.OrderBy(p => p.Name).ToList(), "Id", "Name",
                model.SalesDetails.Select(s=>s.ProductId));
            return View(model);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(SalesOrder salesOrder,HttpPostedFileBase Picture,string operation="")
        {
            if (operation.ToLower() == "add")
            {
                salesOrder.SalesDetails = salesOrder.SalesDetails?? new List<SalesOrderDetail>();
                salesOrder.SalesDetails.Add(new SalesOrderDetail());
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
                salesOrder.SalesDetails.RemoveAt(index);
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
                                string f = salesOrder.Ordernumber + ext;
                                string savePath = Path.Combine(Server.MapPath("~/Pictures"), f);
                                Picture.SaveAs(savePath);
                                salesOrder.Picture = "~/Pictures/" + f;

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
                            salesOrder.Picture = salesOrder.Picture;
                        }
                        db.SalesOrderDetails.RemoveRange(db.SalesOrderDetails
                            .Where(p => p.OrderId == salesOrder.ID).ToList());
                        db.SaveChanges();
                        var neworders = salesOrder.SalesDetails.Select(s => new SalesOrderDetail
                        { OrderId= salesOrder.ID, ProductId = s.ProductId, UnitPrice = s.UnitPrice, Quantity = s.Quantity,Discount=s.Discount,Total=s.Total }).ToList();
                        salesOrder.SalesDetails = neworders;

                        db.SalesOrderDetails.AddRange(neworders);
                        //db.Products.AddRange(entity.Products);
                        db.Entry(salesOrder).State = System.Data.Entity.EntityState.Modified;
                        if (db.SaveChanges() > 0)
                        {
                            return RedirectToAction("Index", "Sales");
                        }
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                
                
                }
                else
                {
                    var message = string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                   
                }
            }


            ViewBag.ProductId = new SelectList(db.Products.OrderBy(p => p.Name).ToList(), "Id", "Name",
                salesOrder.SalesDetails.Select(s => s.ProductId));
            return View(salesOrder);

            
        }

    }
}
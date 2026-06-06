using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SalesDTController : Controller
    {
        modelEVD db = new modelEVD();
        // GET: SalesDT
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products.OrderBy(p => p.Name).ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(SalesOrder salesOrder)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
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
                    var message = string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    return Json(new { Success = false, msg = message });
                }
            }
            catch (Exception ex)
            {
                return Json(data: new { Success = false, Message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult UploadFile()
        {
           
                var Ordernumber=  Request.Form["Ordernumber"];
            var ImageFile = Request.Files[0];
                var fileName = Path.GetFileName(ImageFile.FileName);
                var fileExt = Path.GetExtension(ImageFile.FileName);
                var path = Path.Combine(Server.MapPath("~/Pictures"), Ordernumber+fileExt);
                ImageFile.SaveAs(path);
                return Json(new { success = true, FilePAth = "~/Pictures/" + Ordernumber + fileExt });
           
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}
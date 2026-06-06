using MasterDetailJQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterDetailJQuery.Controllers
{
    public class HomeController : Controller
    {
        private OrderContext db;
        public HomeController() { db = new OrderContext(); }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(SalesOrder  salesOrder)
        {
            try
            {
                
                SalesOrder objsal = new SalesOrder();
                objsal.Customername = salesOrder.Customername;
                objsal.Address = salesOrder.Address;
                objsal.Ordernumber = salesOrder.Ordernumber;
                 
                db.SalesOrders.Add(salesOrder);
                int x= db.SaveChanges();
                
              //  objsal = db.SalesOrders.Single(model => model.Ordernumber == salesOrder.Ordernumber);
                //foreach (var item in details )
                //{
                //    SalesOrderDetail detail = new SalesOrderDetail();
                //    detail.ItemName = item.ItemName;
                //    detail.OrderId = salesOrder.ID;
                //    detail.Quantity = item.Quantity;
                //    detail.Discount = item.Discount;
                //    detail.Total = item.Total;
                //    detail.UnitPrice = item.UnitPrice;
                //    db.Details.Add(detail);
                //    db.SaveChanges();
                //}
                return Json(data: new { Success = true, Message = "Data Successfully Added" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) {
                return Json(data: new { Success = false, Message=ex.Message });
            }
        }

    }
}
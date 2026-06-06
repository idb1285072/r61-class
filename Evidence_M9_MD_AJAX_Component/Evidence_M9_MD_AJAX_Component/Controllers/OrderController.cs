using Evidence_M9_MD_AJAX_Component.Models;
using Evidence_M9_MD_AJAX_Component.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Evidence_M9_MD_AJAX_Component.Controllers
{
    public class OrderController : Controller
    {
        private readonly DbEv7Context db;
        IWebHostEnvironment webHost;
        public OrderController(DbEv7Context db, 
            IWebHostEnvironment webHost)
        {
            this.db = db;
            this.webHost = webHost; 
        }
        public IActionResult Index()
        {
            var model = db.Orders.Include(o => o.OrderDetails)
                                    .OrderByDescending(r=>r.Id)
                                        .ToList();
            return View(model);
        }
        public IActionResult Create()
        {
           // ViewBag.ProductId = new SelectList(db.Products.ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Edit([FromBody] OrderInfoVm order)
        {
            ViewBag.ProductId = new SelectList(db.Products.ToList(), "Id", "Name");
            try
            {
                if (ModelState.IsValid)
                {
                    var imageHeader = Request.Headers["Image-Data"];
                    string picPath = "";
                    if (!string.IsNullOrEmpty(imageHeader))
                    {
                        var imageData = Convert.FromBase64String(imageHeader);
                        var rootfolder = webHost.WebRootPath;
                        var filePath = Path.Combine( rootfolder,"Pictures", order.OrderNumber + ".png");// "uploadedImage.png"
                        System.IO.File.WriteAllBytes(filePath, imageData);
                        picPath = "~/Pictures/" + order.OrderNumber + ".png";
                    }
                    else
                    {
                        picPath = order.Picture;
                    }
                    var insertModel = db.Orders.Find(order.Id);
                    insertModel.CustomerName = order.CustomerName;
                    insertModel.Picture = picPath;
                    insertModel.OrderNumber = order.OrderNumber;
                    insertModel.OrderDetails = order.OrderDetails;
                    insertModel.IsDelivered = order.IsDelivered;
                    insertModel.OrderDate = order.OrderDate;
                      insertModel.Id = order.Id;

                    // db.Orders.Add(insertModel);
                    db.OrderDetails.RemoveRange(db.OrderDetails.Where(d => d.OrderId.Equals(order.Id)));
                    db.SaveChanges();

                    db.Entry(insertModel).State= EntityState.Modified;
                        int x = db.SaveChanges();
                        if (x > 0)
                        {
                            return Json(new { Success = true, Message = "Data Successfully updated" } );
                        }
                        else
                        {
                            return Json(new { Success = false, Message = "update failed" });
                        }
                   
                }
                else
                {
                    var message = string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    return Json(new { Success = false, Message = message });
                }
            }
            catch (Exception ex)
            {
                return Json(data: new { Success = false, Message = ex.Message });
            }
             
        }


        public IActionResult Edit(int id)
        {
          //  ViewBag.ProductId = new SelectList(db.Products.ToList(), "Id", "Name");
            ViewBag.ProductId = new SelectList(db.Products.ToList(), "Id", "Name");
            //var model = db.Orders.Include(o => o.OrderDetails)
            //        .Where(d => d.Id == id).FirstOrDefault();
            return View();
        }

        public IActionResult GetbyId(int id)
        {
            ViewBag.ProductId = new SelectList(db.Products.ToList(), "Id", "Name");
            var model = db.Orders.Include(o => o.OrderDetails)
                    .Where(d => d.Id == id).FirstOrDefault();
            return Json(model);
        }
        [HttpPost]
        public IActionResult Create([FromBody] OrderInfoVm order)
        {
            ViewBag.ProductId = new SelectList(db.Products.ToList(), "Id", "Name");
            try
            {
                if (ModelState.IsValid)
                {
                    var imageHeader = Request.Headers["Image-Data"];
                    if (!string.IsNullOrEmpty(imageHeader))
                    {
                        var imageData = Convert.FromBase64String(imageHeader);
                        var rootfolder = webHost.WebRootPath;
                        var filePath = Path.Combine(rootfolder, "Pictures", order.OrderNumber + ".png");// "uploadedImage.png"
                        System.IO.File.WriteAllBytes(filePath, imageData);
                        var insertModel = new Order
                        {
                            CustomerName = order.CustomerName,
                            Picture = "~/Pictures/" + order.OrderNumber + ".png",
                            OrderNumber = order.OrderNumber,
                            OrderDetails = order.OrderDetails,
                            IsDelivered = order.IsDelivered,
                            OrderDate = order.OrderDate
                        };
                        db.Orders.Add(insertModel);
                        int x = db.SaveChanges();
                        if (x > 0)
                        {
                            return Json(new { Success = true, Message = "Data Successfully Added" });
                        }
                        else
                        {
                            return Json(new { Success = false, Message = "Save failed" });
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
                    return Json(new { Success = false, Message = message });
                }
            }
            catch (Exception ex)
            {
                return Json(data: new { Success = false, Message = ex.Message });
            }

        }
    
    
    public IActionResult Delete(int id)
        {
            db.OrderDetails.RemoveRange(db.OrderDetails.Where(d => d.OrderId == id));
            db.SaveChanges();
            db.Orders.Remove(db.Orders.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using Newtonsoft.Json;
using R61_1285072.DTOs;
using R61_1285072.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace R61_1285072.Controllers
{
    [Authorize]
    public class SalesController : ApiController
    {
        private readonly DbInvContext db = new DbInvContext();
        
        public IHttpActionResult Get()
        {
            try
            {
                var model = db.Sales
              .Include("Details")
              .Select(s => new
              {
                  s.ID,
                  s.Name,
                  s.OrderDate,
                  s.Status,
                  s.Picture,
                  Details = s.Details.Select(d => new
                  {
                      d.ProductId,
                      d.OrderId,
                      d.Price,
                      ProductName = d.Product.Name
                  })
              })
              .ToList();

                if (!model.Any())
                    return Ok("No records are found");

                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var model = db.Sales
                    .Include("Details")
                    .Where(s => s.ID == id)
                    .Select(s => new
                    {
                        s.ID,
                        s.Name,
                        s.OrderDate,
                        s.Status,
                        s.Picture,
                        Details = s.Details.Select(d => new
                        {
                            d.ProductId,
                            d.OrderId,
                            d.Price,
                            ProductName = d.Product.Name
                        })
                    })
                    .FirstOrDefault();

                if (model == null)
                    return NotFound();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); 
            }
        }


        public IHttpActionResult Post()
        {
            try
            {
                string filePath = "";
                var httpRequest = HttpContext.Current.Request;
                var f = httpRequest.Files[0];
                var o = httpRequest.Form["sales"];
                var entity = JsonConvert.DeserializeObject<SalesDTO>(o);
                if (f.FileName.Length > 0)
                {
                    string root = HttpContext.Current.Server.MapPath("~/Pictures");
                    string filetoSave = Path.Combine(root, f.FileName);
                    f.SaveAs(filetoSave);
                    filePath = "~/Pictures/" + f.FileName;

                    var sales = new Sales
                    {
                        Name = entity.Sales.Name,
                        OrderDate = entity.Sales.OrderDate,
                        Status = entity.Sales.Status,
                        Details = entity.Sales.Details,
                        Picture = filePath
                    };
                    db.Sales.Add(sales);
                    if (db.SaveChanges() > 0)
                    {
                        return Ok("Saved Successfully");
                    }
                    else
                    {
                        return BadRequest("Save failed");
                    }
                }
                else
                {
                    return BadRequest("no pic found");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        public IHttpActionResult Put()
        {
            try
            {
                string filePath = string.Empty;
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Form["sales"] == null)
                {
                    return BadRequest("Sales data is missing.");
                }
                var entity = JsonConvert.DeserializeObject<SalesDTO>(httpRequest.Form["sales"]);
                var existingSales = db.Sales.Find(entity.Sales.ID);
                if (existingSales == null)
                {
                    return NotFound();
                }
                if (httpRequest.Files.Count > 0)
                {
                    var file = httpRequest.Files[0];

                    if (file.FileName.Length > 0)
                    {
                        string rootPath = HttpContext.Current.Server.MapPath("~/Pictures");
                        string uniqueFileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                        string fileToSave = Path.Combine(rootPath, uniqueFileName);
                        file.SaveAs(fileToSave);
                        filePath = "~/Pictures/" + uniqueFileName;
                    }
                }
                existingSales.Name = entity.Sales.Name;
                existingSales.OrderDate = entity.Sales.OrderDate;
                existingSales.Status = entity.Sales.Status;
                db.Details.RemoveRange(db.Details.Where(d => d.OrderId == existingSales.ID).ToList());
                existingSales.Details = entity.Sales.Details;
                existingSales.Picture = string.IsNullOrEmpty(filePath) ? existingSales.Picture : filePath;
                db.Entry(existingSales).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    return Ok("Updated successfully.");
                }
                else
                {
                    return BadRequest("Failed to update sales record.");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                var salesRecord = db.Sales.Find(id);

                if (salesRecord == null)
                {
                    return NotFound();
                }
                db.Sales.Remove(salesRecord);
                if (db.SaveChanges() > 0)
                {
                    return Ok("Deleted Successfully");
                }
                return BadRequest("Delete Failed");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}

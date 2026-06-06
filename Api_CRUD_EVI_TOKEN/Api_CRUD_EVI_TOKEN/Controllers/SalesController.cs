using Api_CRUD_EVI_TOKEN.DTO;
using Api_CRUD_EVI_TOKEN.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Api_CRUD_EVI_TOKEN.Controllers
{

    public class SalesController : ApiController
    {
        private readonly DbInvContext db = new DbInvContext();


        public IHttpActionResult Get()
        {

            var model = db.Sales
                                        .Include("Details")
                                        .ToList();
            return Ok(model);
        }
        public IHttpActionResult Post()
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
                    Odate = entity.Sales.Odate,
                    Status = entity.Sales.Status,
                    Details = entity.Sales.Details,
                    Pic = filePath
                };
                db.Sales.Add(sales);
                if (db.SaveChanges() > 0)
                {
                    return Created("", entity);
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
        public IHttpActionResult Put()
        {
            string filePath = "";
            var sales = new Sales();
            var httpRequest = HttpContext.Current.Request;
            var o = httpRequest.Form["sales"];
            var entity = JsonConvert.DeserializeObject<SalesDTO>(o);
            if (httpRequest.Files.Count > 0)
            {

                var f = httpRequest.Files[0];

                if (f.FileName.Length > 0)
                {
                    string root = HttpContext.Current.Server.MapPath("~/Pictures");
                    string filetoSave = Path.Combine(root, f.FileName);
                    f.SaveAs(filetoSave);
                    filePath = "~/Pictures/" + f.FileName;
                }
            }
            else
            {
                sales.Pic = entity.Sales.Pic;
            }
            
                sales.Name = entity.Sales.Name;
                sales.Odate = entity.Sales.Odate;
                sales.Status = entity.Sales.Status;
                sales.Details = entity.Sales.Details;
                sales.Pic = filePath;

                db.Sales.Add(sales);
                if (db.SaveChanges() > 0)
                {
                    return Created("", entity);
                }
                else
                {
                    return BadRequest("Save failed");
                }
            
          

        }

        //public IHttpActionResult Put()
        //{
        //    string filePath = "";
        //    if (entity.PicFile != null)
        //    {
        //        string root = HttpContext.Current.Server.MapPath("~/Pictures");
        //        string filetoSave = Path.Combine(root, entity.PicFile.FileName);
        //        entity.PicFile.SaveAs(filetoSave);
        //        filePath = "~/Pictures/" + entity.PicFile.FileName;
        //    }
        //    else
        //    {
        //        entity.Sales.Pic = entity.Sales.Pic;
        //    }

        //    var sales = new Sales
        //    {
        //        ID = entity.Sales.ID,
        //        Name = entity.Sales.Name,
        //        Odate = entity.Sales.Odate,
        //        Status = entity.Sales.Status,
        //        Details = entity.Sales.Details,
        //        Pic = filePath
        //    };
        //    db.Sales.Add(sales);
        //    if (db.SaveChanges() > 0)
        //    {
        //        return Created("", entity);
        //    }
        //    else
        //    {
        //        return BadRequest("Save failed");
        //    }

        //}
        public Sales GetByID(int id)
        {

            var model = db.Sales.Include("Details")
                                            .FirstOrDefault(s => s.ID == id);
            return model;
        }
        public IHttpActionResult Delete(int id)
        {
            db.Sales.Remove(db.Sales.Find(id));
            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            return BadRequest("Delete Failed");

        }
    }
}

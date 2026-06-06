using Newtonsoft.Json;
using R61_1285072.DTO;
using R61_1285072.Models;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace R61_1285072.Controllers
{
    public class SalesController : ApiController
    {
        private readonly DbInvContext dbInvContext = new DbInvContext();
        public IHttpActionResult Get()
        {

            var model = dbInvContext.Sales
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
                dbInvContext.Sales.Add(sales);
                if (dbInvContext.SaveChanges() > 0)
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


        public IHttpActionResult Put(SalesDTO entity)
        {
            string filePath = "";
            if (entity.PicFile != null)
            {
                string root = HttpContext.Current.Server.MapPath("~/Pictures");
                string filetoSave = Path.Combine(root, entity.PicFile.FileName);
                entity.PicFile.SaveAs(filetoSave);
                filePath = "~/Pictures/" + entity.PicFile.FileName;
            }
            else
            {
                entity.Sales.Pic = entity.Sales.Pic;
            }

            var sales = new Sales
            {
                ID = entity.Sales.ID,
                Name = entity.Sales.Name,
                Odate = entity.Sales.Odate,
                Status = entity.Sales.Status,
                Details = entity.Sales.Details,
                Pic = filePath
            };
            dbInvContext.Sales.Add(sales);
            if (dbInvContext.SaveChanges() > 0)
            {
                return Created("", entity);
            }
            else
            {
                return BadRequest("Save failed");
            }
        }
        public Sales GetByID(int id)
        {

            var model = dbInvContext.Sales.Include("Details")
                                            .FirstOrDefault(s => s.ID == id);
            return model;
        }
        public IHttpActionResult Delete(int id)
        {
            dbInvContext.Sales.Remove(dbInvContext.Sales.Find(id));
            if (dbInvContext.SaveChanges() > 0)
            {
                return Ok();
            }
            return BadRequest("Delete Failed");
        }
    }
}

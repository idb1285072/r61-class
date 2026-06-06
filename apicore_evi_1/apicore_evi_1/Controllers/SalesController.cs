using apicore_evi_1.DTO;
using apicore_evi_1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace apicore_evi_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalesController : ControllerBase
    {
        private readonly ModelContext db;
        IWebHostEnvironment webHost;
        public SalesController(ModelContext db, IWebHostEnvironment webHost)
        {
            this.db = db;
            this.webHost = webHost;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await db.Orders
                                   .Include(a => a.Details)
                                   .ThenInclude(d => d.Product)
                                   .ToListAsync();

            var orderDtos = orders.Select(p => new Order
            {
                Id = p.Id,
                CustomerName = p.CustomerName,
                OrderDate = p.OrderDate,
                Picture = p.Picture,
                IsDelivered = p.IsDelivered,
                Details = p.Details.Select(a => new Detail
                {
                    Id = a.Id,
                    Price = a.Price,
                    OrderId = a.OrderId,
                    ProductId = a.ProductId,
                    ProductName = a.Product.Name

                }).ToList()
            }).ToList();

            return Ok(orderDtos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            var p = await db.Orders.Include(p => p.Details).ThenInclude(a => a.Product).FirstOrDefaultAsync(p => p.Id == id);
            if (p == null) return NotFound();
            var data = new Order
            {
                Id = p.Id,
                CustomerName = p.CustomerName,
                OrderDate = p.OrderDate,
                Picture = p.Picture,
                IsDelivered = p.IsDelivered,
                Details = p.Details.Select(a => new Detail
                {
                    Id = a.Id,
                    OrderId = a.OrderId,
                    Price = a.Price,
                    ProductId = a.ProductId
                }).ToList()
            };

            return Ok(data);
        }



        [HttpPost]
        public IActionResult Post()
        {
            var requestedFile = HttpContext.Request.Form.Files[0];
            var p = HttpContext.Request.Form["orderdata"];
            var entity = JsonConvert.DeserializeObject<Order>(p);
            try
            {

                if (requestedFile != null)
                {
                    string ext = Path.GetExtension(requestedFile.FileName);
                    string fileName = entity.CustomerName + ext;
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Pictures", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        requestedFile.CopyTo(stream);
                    }
                    var order = new Order
                    {
                        CustomerName = entity.CustomerName,
                        OrderDate = entity.OrderDate,
                        IsDelivered = entity.IsDelivered,
                        Details = entity.Details,
                        Picture = "/Pictures/" + fileName

                    };
                    db.Orders.Add(order);
                    db.SaveChanges();

                }

                return Ok();

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put()
        {
            var p = HttpContext.Request.Form["orderdata"];
            var entity = JsonConvert.DeserializeObject<Order>(p);
            var existing = db.Orders.Find(entity.Id);
            if (HttpContext.Request.Form.Files.Count > 0)
            {
                var requestedFile = HttpContext.Request.Form.Files[0];
                if (requestedFile != null)
                {
                    string ext = Path.GetExtension(requestedFile.FileName);
                    string fileName = entity.CustomerName + ext;
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Pictures", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        requestedFile.CopyTo(stream);
                    }
                    existing.Picture = "/Pictures/" + fileName;
                }
            }
            else
            {
                existing.Picture = entity.Picture;
            }

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                
                    existing.CustomerName = entity.CustomerName;
                    existing.OrderDate = entity.OrderDate;
                    existing.IsDelivered = entity.IsDelivered;
                    existing.Id = entity.Id;
                    existing.Details = entity.Details;
                    db.Entry(existing).State = EntityState.Modified;
                    if (db.SaveChanges() > 0)
                    {
                        transaction.Commit();
                        return Ok(existing);
                    }
                    else
                    {
                        transaction.Rollback();
                        return Problem("Save fialed");
                    }
                
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Problem(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                }
            }
            return Problem("Problem occured during Update");
        }


        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> Delete(int id)
        {
            var p = await db.Orders.Include(p => p.Details).FirstOrDefaultAsync(p => p.Id == id);
            if (p == null) return NotFound();
            db.Orders.Remove(p);
            if (db.SaveChanges() > 0)
            {
                return Ok();
            }
            return Problem("Deletion failed");
        }
    }
}

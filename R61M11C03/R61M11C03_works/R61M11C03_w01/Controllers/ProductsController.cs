using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using R61M11C03_w01.Models;

namespace R61M11C03_w01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        [HttpPut]
        public async Task<ActionResult<Product>> PutProduct()
        {
            string ImagePath = "";
           
            var name = HttpContext.Request.Form["name"];
            var Cat = HttpContext.Request.Form["category"];
            var id = HttpContext.Request.Form["id"];
            var picPath = HttpContext.Request.Form["picPath"];
            try
            {
                if (HttpContext.Request.Form.Files.Count > 0)
                {
                    var requestedFile = HttpContext.Request.Form.Files[0];
                    if (requestedFile != null)
                    {
                        string ext = Path.GetExtension(requestedFile.FileName);
                        string fileName = name + ext;
                        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Pictures", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            requestedFile.CopyTo(stream);
                        }
                        ImagePath = "/Pictures/" + fileName;

                    }
                }
                
                
               else
                {
                    ImagePath = picPath;
                }
                
                
                  
                 
                var product = _context.Product.Find(int.Parse(id));
                product.CatId = int.Parse(Cat);
                    product.Name = name;
                product.Picture = ImagePath;
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProduct(int id, Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(product).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct( )
        {
        //    _context.Product.Add(product);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProduct", new { id = product.Id }, product);
         var requestedFile = HttpContext.Request.Form.Files[0];
        var name = HttpContext.Request.Form["name"];
            var Cat = HttpContext.Request.Form["category"];
            try
            {
                if (requestedFile != null)
               {
                    string ext = Path.GetExtension(requestedFile.FileName);
                    string fileName = name + ext;
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Pictures", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        requestedFile.CopyTo(stream);
                    }
                    var product = new Product
                    {
                        CatId = int.Parse(Cat),
                        Name = name,
                        Picture = "/Pictures/" + fileName,
                    };
                    _context.Product.Add(product);
                    _context.SaveChanges();

                }
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using R61M9C2_Inv.Data;

namespace R61M9C2_Inv.Controllers
{
    [Authorize]
    public class PurchaseMastersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseMastersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.PurchaseMasters.ToListAsync());
        }

        // GET: PurchaseMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseMaster = await _context.PurchaseMasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseMaster == null)
            {
                return NotFound();
            }

            return View(purchaseMaster);
        }

        // GET: PurchaseMasters/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: PurchaseMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,PurchaseDate,PurchaseNumber,VendorName,VendorContact,TotalAmount")] PurchaseMaster purchaseMaster)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(purchaseMaster);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(purchaseMaster);
        //}

        public IActionResult Save ([FromBody] PurchaseMaster entity)
        {
            //int stockQty = db.Stocks.Where(s => s.PoductId == purchase.ProductId).Select(s => s.StockQty).FirstOrDefault();

            if (entity == null) {
                
                return View("Create");

            }
            using (var dbTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    //PurchaseMaster objsal = new PurchaseMaster();
                    //objsal.CustomerName = salesOrder.CustomerName;
                    ////objsal.Address = salesOrder.Address;
                    //objsal.OrderNumber = salesOrder.OrderNumber;
                    //objsal.SalesDate = salesOrder.SalesDate;
                    _context.PurchaseMasters.Add(entity);
                    int x = _context.SaveChanges();

                    foreach (var item in entity.PurchaseDetails)
                    {
                        var stocktoUpdate = _context.Stocks.FirstOrDefault(p => p.PoductId == item.ProductId);
                        if (stocktoUpdate != null)
                        {
                            // var stocktoUpdate = db.Stocks.FirstOrDefault(p => p.Id == item.ProductId);
                            stocktoUpdate.StockQty = stocktoUpdate.StockQty + item.Quantity;
                            stocktoUpdate.StockPrice = stocktoUpdate.StockPrice + item.Total;
                            _context.Entry(stocktoUpdate).State =  EntityState.Modified;
                        }
                        else
                        {
                            var stocktoInsert = new Stock
                            {
                                PoductId = item.ProductId,
                                StockQty = item.Quantity,
                                //StockPrice = (_context.Products.FirstOrDefault(p => p.Id == item.ProductId).Price) * item.Quantity
                                StockPrice = (item.UnitPrice) * item.Quantity
                            };
                            _context.Stocks.Add(stocktoInsert);

                        }
                        x = _context.SaveChanges();
                    }
                    if (x > 0)
                    {
                        dbTransaction.Commit();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        dbTransaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    return BadRequest(ex.Message);
                }
                finally
                {

                }
            }
            return BadRequest("Save failed");

        }
        // GET: PurchaseMasters/Edit/5
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseMaster = await _context.PurchaseMasters.FindAsync(id);
            if (purchaseMaster == null)
            {
                return NotFound();
            }
            return View(purchaseMaster);
        }

        // POST: PurchaseMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PurchaseDate,PurchaseNumber,VendorName,VendorContact,TotalAmount")] PurchaseMaster purchaseMaster)
        {
            if (id != purchaseMaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseMasterExists(purchaseMaster.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseMaster);
        }

        // GET: PurchaseMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseMaster = await _context.PurchaseMasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseMaster == null)
            {
                return NotFound();
            }

            return View(purchaseMaster);
        }

        // POST: PurchaseMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseMaster = await _context.PurchaseMasters.FindAsync(id);
            if (purchaseMaster != null)
            {
                _context.PurchaseMasters.Remove(purchaseMaster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseMasterExists(int id)
        {
            return _context.PurchaseMasters.Any(e => e.Id == id);
        }
    }
}

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
    public class SalesMastersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesMastersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalesMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesMasters.ToListAsync());
        }

        // GET: SalesMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesMaster = await _context.SalesMasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesMaster == null)
            {
                return NotFound();
            }

            return View(salesMaster);
        }

        // GET: SalesMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,SalesDate,SaleNumber,CustomerName,CustomerContact,TotalPrice")] SalesMaster salesMaster)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(salesMaster);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(salesMaster);
        //}

        public IActionResult Save([FromBody] SalesMaster entity)
        {
            //int stockQty = db.Stocks.Where(s => s.PoductId == purchase.ProductId).Select(s => s.StockQty).FirstOrDefault();

            if (entity == null)
            {

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
                    _context.SalesMasters.Add(entity);
                    int x = _context.SaveChanges();

                    foreach (var item in entity.SalesDetails)
                    {
                        var stocktoUpdate = _context.Stocks.FirstOrDefault(p => p.PoductId == item.ProductId);
                        if (stocktoUpdate != null)
                        {
                            // var stocktoUpdate = db.Stocks.FirstOrDefault(p => p.Id == item.ProductId);
                            stocktoUpdate.StockQty = stocktoUpdate.StockQty + item.Quantity;
                            stocktoUpdate.StockPrice = stocktoUpdate.StockPrice + item.SubTotal;
                            _context.Entry(stocktoUpdate).State = EntityState.Modified;
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


        // GET: SalesMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesMaster = await _context.SalesMasters.FindAsync(id);
            if (salesMaster == null)
            {
                return NotFound();
            }
            return View(salesMaster);
        }

        // POST: SalesMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SalesDate,SaleNumber,CustomerName,CustomerContact,TotalPrice")] SalesMaster salesMaster)
        {
            if (id != salesMaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesMasterExists(salesMaster.Id))
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
            return View(salesMaster);
        }

        // GET: SalesMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesMaster = await _context.SalesMasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesMaster == null)
            {
                return NotFound();
            }

            return View(salesMaster);
        }

        // POST: SalesMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesMaster = await _context.SalesMasters.FindAsync(id);
            if (salesMaster != null)
            {
                _context.SalesMasters.Remove(salesMaster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesMasterExists(int id)
        {
            return _context.SalesMasters.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using R61M9C12_HTTPCLIENT.Models;

namespace R61M9C12_HTTPCLIENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseMastersController : ControllerBase
    {
        private readonly CourtDbContext _context;

        public CaseMastersController(CourtDbContext context)
        {
            _context = context;
        }

        // GET: api/CaseMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseMaster>>> GetCaseMasters()
        {
            return await _context.CaseMasters.ToListAsync();
        }

        // GET: api/CaseMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseMaster>> GetCaseMaster(int id)
        {
            var caseMaster = await _context.CaseMasters.FindAsync(id);

            if (caseMaster == null)
            {
                return NotFound();
            }

            return caseMaster;
        }

        // PUT: api/CaseMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaseMaster(int id, CaseMaster caseMaster)
        {
            if (id != caseMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(caseMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseMasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CaseMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CaseMaster>> PostCaseMaster(CaseMaster caseMaster)
        {
            _context.CaseMasters.Add(caseMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaseMaster", new { id = caseMaster.Id }, caseMaster);
        }

        // DELETE: api/CaseMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaseMaster(int id)
        {
            var caseMaster = await _context.CaseMasters.FindAsync(id);
            if (caseMaster == null)
            {
                return NotFound();
            }

            _context.CaseMasters.Remove(caseMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaseMasterExists(int id)
        {
            return _context.CaseMasters.Any(e => e.Id == id);
        }
    }
}

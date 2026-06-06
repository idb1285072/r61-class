using CaseMasterDetails_APICore_consume.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseMasterDetails_APICore_consume.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MasterController : ControllerBase
	{
		private readonly CaseContext _context;
		private readonly IWebHostEnvironment _env;
		public MasterController(CaseContext context, IWebHostEnvironment env)
		{
			_context = context;
			_env = env;
		}

		// GET: api/master
		[HttpGet]
		public async Task<ActionResult<IEnumerable<CaseMaster>>> GetCase()
		{
			if (_context.CaseMasters == null)
			{
				return NotFound();
			}
			return await _context.CaseMasters.ToListAsync();
		}
		[HttpGet("CaseDetails/Include")]
		public async Task<ActionResult<IEnumerable<CaseMaster>>> GetcaseWithDetails()
		{
			if (_context.CaseMasters == null)
			{
				return NotFound();
			}
			return await _context.CaseMasters.Include(x => x.CaseDetails).ToListAsync();
		}
		// GET: api/master/5
		[HttpGet("{id}")]
		public async Task<ActionResult<CaseMaster>> GetCase(int id)
		{
			if (_context.CaseMasters == null)
			{
				return NotFound();
			}
			var device = await _context.CaseMasters.FindAsync(id);

			if (device == null)
			{
				return NotFound();
			}

			return device;
		}
		[HttpGet("CaseDetails/Include/{id}")]
		public async Task<ActionResult<CaseMaster>> GetcaseWithDetails(int id)
		{
			if (_context.CaseMasters == null)
			{
				return NotFound();
			}
			var device = await _context.CaseMasters.Include(x => x.CaseDetails).FirstOrDefaultAsync(x => x.Id == id);

			if (device == null)
			{
				return NotFound();
			}

			return device;
		}

		// PUT: api/master/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutCase(int id, CaseMaster master)
		{
			if (id != master.Id)
			{
				return BadRequest();
			}

			var existing = await _context.CaseMasters.Include(x => x.CaseDetails).FirstOrDefaultAsync(x => x.Id == id);
			if (existing == null) { return NotFound(); }
			existing.CaseNumber = master.CaseNumber;
			existing.CaseDetails = master.CaseDetails;
			existing.CaseDate = master.CaseDate;
			existing.Picture = master.Picture;
			existing.Status = master.Status;
			
			
			await _context.Database.ExecuteSqlInterpolatedAsync($"DELETE FROM details where Id={id}");
			foreach (var s in master.CaseDetails)
			{
				_context.CaseDetails.Add(new CaseDetail { CurrentHearingDate = s.CurrentHearingDate, NextHearingDate = s.NextHearingDate, Id = id });
			}
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MasterExists(id))
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

		// POST: api/master
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<CaseMaster>> Postcase(CaseMaster master)
		{
			if (_context.CaseMasters == null)
			{
				return Problem("Entity  is null");
			}
			try
			{
				_context.CaseMasters.Add(master);
				await _context.SaveChangesAsync();
			}
			catch(Exception ex)
			{

			}
			return CreatedAtAction("GetCase", new { id = master.Id }, master);
		}
		[HttpPost("Image/Upload")]
		public async Task<ActionResult<string>> Upload(IFormFile pic)
		{
			string ext = Path.GetExtension(pic.FileName);
			string f = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
			string savePath = Path.Combine(_env.WebRootPath, "Pictures", f);
			FileStream fs = new FileStream(savePath, FileMode.Create);
			await pic.CopyToAsync(fs);
			fs.Close();
			return f;
		}
		// DELETE: api/master/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCase(int id)
		{
			if (_context.CaseMasters == null)
			{
				return NotFound();
			}
			var caseMaster = await _context.CaseMasters.FindAsync(id);
			if (caseMaster == null)
			{
				return NotFound();
			}

			_context.CaseMasters.Remove(caseMaster);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool MasterExists(int id)
		{
			return (_context.CaseMasters?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}

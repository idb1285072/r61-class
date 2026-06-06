using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCore_MasterDetail.Models;

namespace MvcCore_MasterDetail.Controllers
{
    public class CaseController : Controller
    {
        private readonly CaseContext db;
        private readonly IWebHostEnvironment env;
        public CaseController(CaseContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var data = await db.Applicants.Include(a => a.Qualifications).ToListAsync();
        //    return View(data);
        //}
        public async Task<IActionResult> Index()
        {
            var data = await db.CaseMasters
                .Include(a => a.CaseDetails)
                .ToListAsync();

            return View(data);
        }
        public IActionResult Create()
        {
            var model = new DTO.CaseMaster();
            model.CaseDetails.Add(new DTO.CaseDetail());
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(DTO.CaseMaster model, string act = "")
        {
            if (act == "add")
            {
                model.CaseDetails.Add(new DTO. CaseDetail());
            }
            if (act.StartsWith("remove"))
            {

                int index = int.Parse(act.Substring(act.IndexOf("_") + 1));
                model.CaseDetails.RemoveAt(index);
            }
            if (act == "insert")
            {
                if (ModelState.IsValid)
                {
                    CaseMaster a = new CaseMaster
                    {
                        CaseNumber = model.CaseNumber,
                    
                        Status = model.Status,
                     Source=model.Source,
                        CaseDate = model.CaseDate,
                        Details = model.Details,
                    };
                    string ext = Path.GetExtension(model.Picture.FileName);
                    string fn = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                    string sp = Path.Combine(env.WebRootPath, "Pictures", fn);
                    FileStream fs = new FileStream(sp, FileMode.Create);
                    await model.Picture.CopyToAsync(fs);
                    fs.Close();
                    a.Picture = fn;
                    foreach (var x in model.CaseDetails)
                    {
                        a.CaseDetails.Add(new CaseDetail { CurrentHearingDate = x.CurrentHearingDate, Comment = x.Comment, NextHearingDate = x.NextHearingDate });
                    }
                    await db.CaseMasters.AddAsync(a);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    var message = string.Join(" | ", ModelState.Values
        .SelectMany(v => v.Errors)
        .Select(e => e.ErrorMessage));
                    ModelState.AddModelError("", message);

                }
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var a = await db.CaseMasters.Include(x => x.CaseDetails).FirstOrDefaultAsync(x => x.Id == id);


            return View(a);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DoDelete(int id)
        {
            var a = await db.CaseMasters.Include(x => x.CaseDetails).FirstOrDefaultAsync(x => x.Id == id);
            if (a == null) { return NotFound(); }
            db.CaseMasters.Remove(a);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //Qualifications
        public IActionResult CreateDetails(int id)
        {
            ViewBag.CaseMasters = db.CaseMasters.Select(x => new { x.Id, x.CaseNumber }).ToList();
            ViewBag.CaseMasterId = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDetails(CaseDetail model)
        {
            if (ModelState.IsValid)
            {
                await db.CaseDetails.AddAsync(new CaseDetail { Comment = model.Comment, CurrentHearingDate = model.CurrentHearingDate, NextHearingDate = model.NextHearingDate, CaseMasterId = model.Id });
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Applicants = db.CaseMasters.Select(x => new { x.Id, x.CaseNumber }).ToList();
            ViewBag.Id = model.CaseMasterId;
            return View(model);
        }
        public async Task<IActionResult> DeleteDetails(int id)
        {
            var a = await db.CaseDetails.Include(x => x.CaseMaster).FirstOrDefaultAsync(x => x.Id == id);


            return View(a);
        }
        [HttpPost, ActionName("DeleteDetails")]
        public async Task<IActionResult> DoDeleteQualification(int id)
        {
            var a = await db.CaseDetails.Include(x => x.CaseMaster).FirstOrDefaultAsync(x => x.Id == id);
            if (a == null) { return NotFound(); }
            db.CaseDetails.Remove(a);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}

